using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ManejaCliente {
        ManejaDbClientes manejaDbClientes = new ManejaDbClientes();
        public string crearCliente(Cliente cliente) {
            return manejaDbClientes.crearCliente(cliente);
        }
        public string lookupCliente(string id) {
            string mensaje;
            int resultado = manejaDbClientes.lookupCliente(id);
            switch (resultado) {
                case 1:
                    mensaje = "Cliente Encontrado";
                    break;
                case 0:
                    mensaje = "Cliente No Encontrado";
                    break;
                default:
                    mensaje = "Desconocido";
                    break;
            }
            return mensaje;
        }
    }
}
