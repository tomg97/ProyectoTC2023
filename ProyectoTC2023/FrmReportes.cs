using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUL.Entidades;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using Servicios.Metodos;

namespace ProyectoTC2023 {
    public partial class FrmReportes : Form {
        public FrmReportes() {
            InitializeComponent();
        }
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        private void FrmReportes_Load(object sender, EventArgs e) {

            this.rvReportes.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e) {
            Encriptador encriptador = new Encriptador();
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Venta";
            using(SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(ds);
            }
            DataTable dt = ds.Tables[0];

            double montoTotal = 0;

            foreach (DataRow row in dt.Rows) {
                string jsonVenta = row["productosVendidos"].ToString();
                List<Producto> productosInner = JsonConvert.DeserializeObject<List<Producto>>(jsonVenta);
                string mostrarProducto = string.Join(", ", productosInner.Select(p => $"{p.nombreProducto} cantidad: {p.cantidad}" ));
                row["productosVendidos"] = mostrarProducto;

                string montoEncriptado = row["monto"].ToString();
                string montoDesencriptado = encriptador.desencriptarReversible(montoEncriptado);
                string montoDesencriptadoConSigno = montoDesencriptado.Insert(0, "$");
                row["monto"] = montoDesencriptadoConSigno;

                montoTotal += double.Parse(montoDesencriptado);
            }

            string montoTotalConSigno = montoTotal.ToString();
            montoTotalConSigno = montoTotalConSigno.Insert(0, "$");

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            
            ReportParameter montoTotalParam = new ReportParameter("MontoTotal", montoTotalConSigno);

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(montoTotalParam);

            rvReportes.LocalReport.DataSources.Clear();
            rvReportes.LocalReport.ReportPath = @"C:\Users\TOMG97PC\Desktop\Facultad\3er año\Primer Cuatrimestre\TC\Proyecto\ProyectoTC2023\ProyectoTC2023\ProyectoTC2023\Reporte1.rdlc";
            rvReportes.LocalReport.DataSources.Add(rds);
            rvReportes.LocalReport.SetParameters(rpc);
            rvReportes.RefreshReport();
        }

        private void rvReportes_Load(object sender, EventArgs e) {

        }
    }
}
