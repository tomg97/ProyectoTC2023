using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUL.Entidades;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using Servicios.Metodos;
using System.Resources;
using Servicios.Idioma;

namespace ProyectoTC2023 {
    public partial class FrmReportes : Form {
        public FrmReportes() {
            InitializeComponent();
            actualizarIdioma();
        }
        private readonly string _connectionString = DAL.Metodos.DbConfig.Instance.ConnectionString;
        private void FrmReportes_Load(object sender, EventArgs e) {

            this.rvReportes.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (cbReportes.SelectedItem == null) {
                new Mensajeria().mostrarConfirmacion("Seleccione un reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LimpiarVistaReporte();

            if (cbReportes.SelectedItem.ToString() == "Reporte 2") {
                GenerarReporteProveedores();
                return;
            } else if (cbReportes.SelectedItem.ToString() == "Reporte Inteligente") {
                GenerarReporteInteligente();
                return;
            } else if (cbReportes.SelectedItem.ToString() == "Reporte 1") {
                GenerarReporteVentas();
                return;
            }
        }

        private void GenerarReporteVentas() {
            Encriptador encriptador = new Encriptador();
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Venta";
            using(SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(ds);
            }
            DataTable dt = ds.Tables[0];

            decimal montoTotal = 0m;

            foreach (DataRow row in dt.Rows) {
                string jsonVenta = row["productosVendidos"].ToString();
                List<Producto> productosInner = JsonConvert.DeserializeObject<List<Producto>>(jsonVenta);
                string mostrarProducto = string.Join(", ", productosInner.Select(p => $"{p.nombreProducto} cantidad: {p.cantidad}" ));
                row["productosVendidos"] = mostrarProducto;

                string montoEncriptado = row["monto"].ToString();
                string montoDesencriptado = encriptador.desencriptarReversible(montoEncriptado);
                string montoDesencriptadoConSigno = montoDesencriptado.Insert(0, "$");
                row["monto"] = montoDesencriptadoConSigno;

                if (!decimal.TryParse(montoDesencriptado, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal monto)
                    && !decimal.TryParse(montoDesencriptado, NumberStyles.Number, CultureInfo.CurrentCulture, out monto)) {
                    throw new FormatException("El monto almacenado no tiene un formato numerico valido.");
                }

                montoTotal += monto;
            }

            string montoTotalConSigno = montoTotal.ToString();
            montoTotalConSigno = montoTotalConSigno.Insert(0, "$");

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            
            ReportParameter montoTotalParam = new ReportParameter("MontoTotal", montoTotalConSigno);

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(montoTotalParam);

            rvReportes.LocalReport.DataSources.Clear();
            LoadReportDefinition("ProyectoTC2023.Reporte1.rdlc");
            rvReportes.LocalReport.DataSources.Add(rds);
            rvReportes.LocalReport.SetParameters(rpc);
            rvReportes.RefreshReport();
        }

        private void GenerarReporteProveedores() {
            DataTable ordenes = new DataTable();
            const string query = @"SELECT oc.cuitProveedor, p.nombre, oc.total
                                   FROM OrdenCompra oc
                                   INNER JOIN Proveedor p ON p.CUIT = oc.cuitProveedor";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection)) {
                dataAdapter.Fill(ordenes);
            }

            DataTable resumen = new DataTable();
            resumen.Columns.Add("CUIT", typeof(string));
            resumen.Columns.Add("NombreProveedor", typeof(string));
            resumen.Columns.Add("CantidadCompras", typeof(int));
            resumen.Columns.Add("TotalComprado", typeof(decimal));

            var proveedores = ordenes.AsEnumerable()
                .GroupBy(row => new {
                    CUIT = row["cuitProveedor"] == DBNull.Value ? "" : row["cuitProveedor"].ToString(),
                    Nombre = row["nombre"] == DBNull.Value ? "Proveedor sin nombre" : row["nombre"].ToString()
                })
                .Select(grupo => new {
                    grupo.Key.CUIT,
                    grupo.Key.Nombre,
                    Cantidad = grupo.Count(),
                    Total = grupo.Sum(row => {
                        string valor = row["total"] == DBNull.Value ? "0" : row["total"].ToString();
                        if (decimal.TryParse(valor, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal monto)
                            || decimal.TryParse(valor, NumberStyles.Number, CultureInfo.CurrentCulture, out monto)) {
                            return monto;
                        }
                        return 0m;
                    })
                })
                .OrderByDescending(proveedor => proveedor.Cantidad)
                .ThenByDescending(proveedor => proveedor.Total)
                .ThenBy(proveedor => proveedor.Nombre);

            foreach (var proveedor in proveedores) {
                resumen.Rows.Add(proveedor.CUIT, proveedor.Nombre, proveedor.Cantidad, proveedor.Total);
            }

            ReportDataSource rds = new ReportDataSource("DataSetProveedorCompras", resumen);

            rvReportes.LocalReport.DataSources.Clear();
            LoadReportDefinition("ProyectoTC2023.Reporte2.rdlc");
            rvReportes.LocalReport.DataSources.Add(rds);
            rvReportes.LocalReport.SetParameters(new ReportParameterCollection());
            rvReportes.RefreshReport();
        }

        private void GenerarReporteInteligente() {
            DataTable ventas = new DataTable();
            const string ventasQuery = "SELECT fecha, monto FROM Venta";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(ventasQuery, connection)) {
                dataAdapter.Fill(ventas);
            }

            DataTable compras = new DataTable();
            const string comprasQuery = "SELECT fecha, total FROM OrdenCompra";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comprasQuery, connection)) {
                dataAdapter.Fill(compras);
            }

            Dictionary<string, decimal> ventasPorMes = new Dictionary<string, decimal>();
            Encriptador encriptador = new Encriptador();

            foreach (DataRow row in ventas.Rows) {
                if (!ObtenerMes(row["fecha"], out string mes)) {
                    continue;
                }

                string montoEncriptado = row["monto"] == DBNull.Value ? null : row["monto"].ToString();
                if (string.IsNullOrWhiteSpace(montoEncriptado)) {
                    continue;
                }

                try {
                    string montoDesencriptado = encriptador.desencriptarReversible(montoEncriptado);
                    if (ParsearMonto(montoDesencriptado, out decimal monto)) {
                        AnadirMontoMensual(ventasPorMes, mes, monto);
                    }
                } catch (FormatException) {
                    // Ignore rows with an invalid reversible-amount encoding.
                }
            }

            Dictionary<string, decimal> comprasPorMes = new Dictionary<string, decimal>();

            foreach (DataRow row in compras.Rows) {
                if (!ObtenerMes(row["fecha"], out string mes)) {
                    continue;
                }

                string valor = row["total"] == DBNull.Value ? null : row["total"].ToString();
                if (ParsearMonto(valor, out decimal monto)) {
                    AnadirMontoMensual(comprasPorMes, mes, monto);
                }
            }

            DataTable resumen = new DataTable();
            resumen.Columns.Add("Mes", typeof(string));
            resumen.Columns.Add("TotalVentas", typeof(decimal));
            resumen.Columns.Add("TotalCompras", typeof(decimal));
            resumen.Columns.Add("Balance", typeof(decimal));
            resumen.Columns.Add("Interpretacion", typeof(string));

            HashSet<string> meses = new HashSet<string>(ventasPorMes.Keys);
            meses.UnionWith(comprasPorMes.Keys);

            foreach (string mes in meses.OrderByDescending(value => value)) {
                decimal ventasMes = ventasPorMes.ContainsKey(mes) ? ventasPorMes[mes] : 0m;
                decimal comprasMes = comprasPorMes.ContainsKey(mes) ? comprasPorMes[mes] : 0m;
                decimal balance = ventasMes - comprasMes;

                string interpretacion;
                if (balance > 0m) {
                    interpretacion = "Las ventas superaron a las compras";
                } else if (balance < 0m) {
                    interpretacion = "Las compras superaron a las ventas";
                } else {
                    interpretacion = "Ventas y compras equilibradas";
                }

                resumen.Rows.Add(mes, ventasMes, comprasMes, balance, interpretacion);
            }

            ReportDataSource rds = new ReportDataSource("DataSetReporteInteligente", resumen);

            rvReportes.LocalReport.DataSources.Clear();
            LoadReportDefinition("ProyectoTC2023.ReporteInteligente.rdlc");
            rvReportes.LocalReport.DataSources.Add(rds);
            rvReportes.LocalReport.SetParameters(new ReportParameterCollection());
            rvReportes.RefreshReport();
        }

        private static bool ParsearMonto(string valor, out decimal monto) {
            if (string.IsNullOrWhiteSpace(valor)) {
                monto = 0m;
                return false;
            }

            return decimal.TryParse(valor, NumberStyles.Number, CultureInfo.InvariantCulture, out monto)
                || decimal.TryParse(valor, NumberStyles.Number, CultureInfo.CurrentCulture, out monto);
        }

        private static bool ObtenerMes(object fechaValor, out string mes) {
            mes = null;
            if (fechaValor == null || fechaValor == DBNull.Value) {
                return false;
            }

            if (fechaValor is DateTime fechaDateTime) {
                mes = fechaDateTime.ToString("yyyy-MM");
                return true;
            }

            if (DateTime.TryParse(fechaValor.ToString(), CultureInfo.CurrentCulture,
                    DateTimeStyles.AllowWhiteSpaces, out DateTime fecha)) {
                mes = fecha.ToString("yyyy-MM");
                return true;
            }

            return false;
        }

        private static void AnadirMontoMensual(Dictionary<string, decimal> totals, string mes, decimal amount) {
            if (totals.ContainsKey(mes)) {
                totals[mes] += amount;
            } else {
                totals.Add(mes, amount);
            }
        }

        private void LoadReportDefinition(string resourceName) {
            Stream reportStream = typeof(FrmReportes).Assembly.GetManifestResourceStream(resourceName);
            if (reportStream == null) {
                throw new InvalidOperationException("No se encontró el reporte embebido: " + resourceName);
            }

            using (reportStream) {
                rvReportes.LocalReport.LoadReportDefinition(reportStream);
            }
        }

        private void rvReportes_Load(object sender, EventArgs e) {

        }

        private void cbReportes_SelectedIndexChanged(object sender, EventArgs e) {
            LimpiarVistaReporte();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            cbReportes.SelectedIndex = -1;
            LimpiarVistaReporte();
        }

        private void LimpiarVistaReporte() {
            rvReportes.Reset();
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmReportes", typeof(FrmReportes), codigoIdioma);
            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmReportes", typeof(FrmReportes).Assembly);
            this.Text = _resourceManager.GetString("FrmReportes");
        }
    }
}
