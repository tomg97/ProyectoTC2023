using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
