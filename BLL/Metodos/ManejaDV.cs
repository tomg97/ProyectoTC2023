using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Servicios.Metodos;
using CUL.Entidades;

namespace BLL.Metodos {
    public class ManejaDV {
        ManejaDVDb manejaDb = new ManejaDVDb();
        Encriptador encriptador = new Encriptador();
        private DV calcularDV() {
            DataTable dt = manejaDb.traerDTNegocio();
            DV dV = new DV {
                DVV = HashColumnValues(dt),
                DVH = HashRowValues(dt)
            };
            return dV;
        }
        private string HashColumnValues(DataTable dt) {
            StringBuilder sb = new StringBuilder();

            List<string> valoresColumnas = new List<string>();

            for (int i = 0; i < dt.Columns.Count; i++) {
                for (int j = 0; j < dt.Rows.Count; j++) {
                    sb.Append(dt.Rows[i][j].ToString());
                }
                valoresColumnas.Add(sb.ToString());
            }

            foreach (var item in valoresColumnas) {
                sb.Append(item);
            }

            return encriptador.encriptarIrreversible(sb.ToString());
        }

        private string HashRowValues(DataTable dt) {
            StringBuilder sb = new StringBuilder();

            List<string> valoresColumnas = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++) {
                for (int j = 0; j < dt.Columns.Count; j++) {
                    sb.Append(dt.Rows[j][i].ToString());
                }
                valoresColumnas.Add(sb.ToString());
            }

            foreach (var item in valoresColumnas) {
                sb.Append(item);
            }

            return encriptador.encriptarIrreversible(sb.ToString());
        }

        public bool loginStep() {
            DV DVActual = calcularDV();
            DV dvDB = manejaDb.traerDV();
            return DVActual.DVH == dvDB.DVH && DVActual.DVV == dvDB.DVV;
        }
        public void almacenarDV() {
            DV dV = calcularDV();
            manejaDb.almacenarDV(dV);
        }
    }
}
