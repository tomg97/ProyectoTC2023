using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ManejaDVDb {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        ManejaDbMaestro manejaDbMaestro = new ManejaDbMaestro();
        public DataTable traerDTNegocio() {
            return cargarDataTableProductos(manejaDbMaestro.traerTodosProductos());
        }

        private DataTable cargarDataTableProductos(List<Producto> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre Producto", typeof(string));
            dataTable.Columns.Add("Marca Producto", typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(int));
            dataTable.Columns.Add("Precio", typeof(string));
            dataTable.Columns.Add("Id", typeof(string));

            foreach (var producto in list) {
                DataRow row = dataTable.NewRow();
                row["Nombre Producto"] = producto.nombreProducto;
                row["Marca Producto"] = producto.marcaProducto;
                row["Cantidad"] = producto.cantidad; ;
                row["Precio"] = producto.precio;
                row["Id"] = producto.id;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        public void almacenarDV(DV dV) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM DV", connection);
                SqlCommand insertCommand = new SqlCommand("INSERT INTO DV (DVH, DVV) VALUES (@DVH, @DVV)", connection);
                insertCommand.Parameters.AddWithValue("@DVH", dV.DVH);
                insertCommand.Parameters.AddWithValue("@DVV", dV.DVV);

                connection.Open();
                deleteCommand.ExecuteNonQuery();
                insertCommand.ExecuteNonQuery();
            }
        }
        public DV traerDV() {
            DV dV = new DV();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("SELECT * FROM DV", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    dV.DVH = reader["DVH"].ToString();
                    dV.DVV = reader["DVV"].ToString();
                }
                reader.Close();
            }
            return dV;
        }
    }
}
