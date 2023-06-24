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
        public bool validarMayor0(int valor) {
            return valor > 0;
        }
        public bool validarSoloNumero(string valor) {
            return Regex.IsMatch(valor, @"^[0-9]+$");
        }
        public bool validarSoloTexto(string valor) {
            return Regex.IsMatch(valor, @"^[A-Za-z]+$");
        }
    }
}
