using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Metodos;
using CUL.Entidades;

namespace BLL.Metodos {
    public class ManejaDV {
        ManejaDVDb manejaDb = new ManejaDVDb();

        /// <summary>
        /// Calcula el DVH y DVV de la base de datos según el requisito
        /// </summary>
        private DV calcularDV() {
            DataTable dt = manejaDb.traerDTNegocio();
            
            DV dV = new DV {
                DVH = CalcularDVH(dt),
                DVV = CalcularDVV(dt)
            };
            return dV;
        }

        /// <summary>
        /// Calcula el DVH (Dígito Verificador Horizontal)
        /// 1. Para cada registro: suma valores hex de todas sus columnas -> DVH del registro
        /// 2. Suma todos los DVH de los registros -> DVH de la tabla
        /// 3. Suma DVH de todas las tablas -> DVH de la BD (actualmente solo una tabla)
        /// </summary>
        private string CalcularDVH(DataTable dt) {
            long sumaTotalDVH = 0;

            // Para cada fila (registro)
            foreach (DataRow row in dt.Rows) {
                long dvhFila = 0;
                
                // Suma valores hex de todas las columnas del registro (cálculo horizontal)
                foreach (DataColumn col in dt.Columns) {
                    string valor = row[col].ToString();
                    dvhFila += ConvertirAHexadecimalSuma(valor);
                }
                
                // Acumula el DVH de este registro
                sumaTotalDVH += dvhFila;
            }

            // Retorna la suma total en formato hexadecimal
            return sumaTotalDVH.ToString("X");
        }

        /// <summary>
        /// Calcula el DVV (Dígito Verificador Vertical)
        /// 1. Para cada columna: suma valores hex de todos sus registros -> DVV de la columna
        /// 2. Suma todos los DVV de las columnas -> DVV de la tabla
        /// 3. Suma DVV de todas las tablas -> DVV de la BD (actualmente solo una tabla)
        /// </summary>
        private string CalcularDVV(DataTable dt) {
            long sumaTotalDVV = 0;

            // Para cada columna
            foreach (DataColumn col in dt.Columns) {
                long dvvColumna = 0;
                
                // Suma valores hex de todos los registros de la columna (cálculo vertical)
                foreach (DataRow row in dt.Rows) {
                    string valor = row[col].ToString();
                    dvvColumna += ConvertirAHexadecimalSuma(valor);
                }
                
                // Acumula el DVV de esta columna
                sumaTotalDVV += dvvColumna;
            }

            // Retorna la suma total en formato hexadecimal
            return sumaTotalDVV.ToString("X");
        }

        /// <summary>
        /// Convierte un string a su equivalente numérico sumando bytes
        /// Cada byte representa el valor hexadecimal de cada carácter
        /// </summary>
        private long ConvertirAHexadecimalSuma(string valor) {
            if (string.IsNullOrEmpty(valor)) return 0;

            byte[] bytes = Encoding.UTF8.GetBytes(valor);
            long suma = 0;
            
            foreach (byte b in bytes) {
                suma += b;
            }
            
            return suma;
        }

        /// <summary>
        /// Verifica la integridad de los datos comparando DVH y DVV actuales con los almacenados
        /// </summary>
        public bool loginStep() {
            DV DVActual = calcularDV();
            DV dvDB = manejaDb.traerDV();
            return DVActual.DVH == dvDB.DVH && DVActual.DVV == dvDB.DVV;
        }

        /// <summary>
        /// Almacena los valores DVH y DVV calculados en la base de datos
        /// Debe llamarse después de cada operación de persistencia
        /// </summary>
        public void almacenarDV() {
            DV dV = calcularDV();
            manejaDb.almacenarDV(dV);
        }
    }
}
