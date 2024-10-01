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
        BitacoraBLL bitacora = new BitacoraBLL();
        public string crearCliente(Cliente cliente) {
            string resultado;
            try {
                resultado = manejaDbClientes.crearCliente(cliente);
                bitacora.persistirMensajeLogged("Cliente creado. Id de cliente: " + cliente.id, Modulo.Clientes, Criticidad.Dos);                
            } catch (Exception e) {
                resultado = "Error al crear cliente. " + e.ToString();
                bitacora.persistirMensajeLogged("Creacion de cliente fallida. Motivo: " + e.ToString(), Modulo.Clientes, Criticidad.Dos);
            }
            return resultado;
        }
        public string lookupCliente(string id) {
            Encriptador encriptador = new Encriptador();
            string mensaje;
            int resultado = manejaDbClientes.lookupCliente(encriptador.encriptarReversible(id));
            switch (resultado) {
                case 1:
                    mensaje = "Cliente encontrado";
                    bitacora.persistirMensajeLogged(mensaje + ". Con Id: " + id, Modulo.Clientes, Criticidad.Cuatro);
                    break;
                case 0:
                    mensaje = "Cliente no encontrado";
                    bitacora.persistirMensajeLogged(mensaje + ". Con Id: " + id, Modulo.Clientes, Criticidad.Cuatro);
                    break;
                default:
                    mensaje = "Desconocido";
                    bitacora.persistirMensajeLogged("Error desconocido en lookup de cliente. Id de cliente: " + id, Modulo.Clientes, Criticidad.Dos);
                    break;
            }
            return mensaje;
        }
        public List<Cliente> lookupTodosClientes() {
            List<Cliente> clientes = manejaDbClientes.traerTodosClientes();
            Encriptador encriptador = new Encriptador();
            foreach (Cliente cliente in clientes) {
                cliente.id = encriptador.desencriptarReversible(cliente.id);
                cliente.domicilio = encriptador.desencriptarReversible(cliente.domicilio);
                cliente.telefono = encriptador.desencriptarReversible(cliente.telefono);
            }
            return clientes;
        }
    }
}
