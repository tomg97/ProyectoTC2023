using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Servicios.Metodos {
    public class ValidarCampos {
        public bool validarNoNuloNoVacio(params string[] campos) {
            foreach (string str in campos) {
                if (string.IsNullOrEmpty(str)) {
                    return false;
                }
            }
            return true;
        }
        public bool validarListaNoNulaNoVacia<T>(List<T> listaAChequear) {
            return listaAChequear != null && listaAChequear.Count > 0;
        }
        public bool validarMayor0(params int[] valores) {
            return !valores.Any(valor => valor < 0);
        }
        public bool validarSoloNumero(string valor) {
            return Regex.IsMatch(valor, @"^[0-9]+$");
        }
        public bool validarSoloMes(string valor) {
            return Regex.IsMatch(valor, @"^[1-12]+$");
        }
        public bool validarSoloTexto(string valor) {
            return Regex.IsMatch(valor, @"^[A-Za-z]+$");
        }
        public bool validarCuotas(string valor) {
            return Regex.IsMatch(valor, @"^(1|3|6|9|12)$");
        }
        public bool validarFechaNoVencida(string valor) {
            bool esValido = false;
            if(valor.Length == 4) {
                int mes = int.Parse(valor.Substring(0, 2));
                int año = int.Parse(valor.Substring(2, 2));

                int mesActual = DateTime.Now.Month;
                int añoActual = DateTime.Now.Year % 100;

                if(año > añoActual || (año == añoActual && mes >= mesActual)) {
                    esValido = true;
                }
            }
            return esValido;
        }
        public bool validarCCV(string CCV) {
            return validarSoloNumero(CCV) && CCV.Length == 3;
        }
    }
}
