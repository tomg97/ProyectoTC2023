using CUL.Entidades;
using DAL.Metodos;
using Servicios.Metodos;
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
            Encriptador encriptador = new Encriptador();
            string mensaje;
            int resultado = manejaDbClientes.lookupCliente(encriptador.encriptarReversible(id));
            switch (resultado) {
                case 1:
                    mensaje = "Cliente encontrado";
                    break;
                case 0:
                    mensaje = "Cliente no encontrado";
                    break;
                default:
                    mensaje = "Desconocido";
                    break;
            }
            return mensaje;
        }
    }
}
