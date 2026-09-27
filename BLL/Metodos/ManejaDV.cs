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
using Servicios.Interfaces;

namespace BLL.Metodos {
    public class ManejaDV {
        List<IDVManejadores> manejadores = new List<IDVManejadores>();
        public ManejaDV() {
            manejadores.Add(new ManejaUsuarios());
            manejadores.Add(new ManejaVenta());
            manejadores.Add(new ManejaMaestro("Productos")); 
        }

        public List<String> check() {
            List<String> resultados = new List<string>();

            resultados.AddRange(chequearDV());
            return resultados;
        }
        public void recalcularDV() {
            manejadores.ForEach(m => m.recalcularDV());
        }
        private List<String> chequearDV() {
            List<String> resultado = new List<string>();

            try {
                manejadores.ForEach(m => resultado.AddRange(m.chequearIntegridad()));
            }
            catch (Exception) {
                resultado.Add("Errores al obtener información de la db");
            }
            return resultado;
        }
    }
}
