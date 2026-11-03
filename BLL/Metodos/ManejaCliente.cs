using CUL.Entidades;
using DAL.Metodos;
using Servicios.Interfaces;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ManejaCliente : IDVManejadores {
        ManejaDbClientes manejaDbClientes = new ManejaDbClientes();
        BitacoraBLL bitacora = new BitacoraBLL();
        public string crearCliente(Cliente cliente) {
            string resultado;
            try {
                resultado = manejaDbClientes.crearCliente(cliente);
                bitacora.persistirMensajeLogged(EventoEnum.CreaClienteOk, Modulo.Clientes, Criticidad.Dos);                
            } catch (Exception e) {
                resultado = "Error al crear cliente. " + e.ToString();
                bitacora.persistirMensajeLogged(EventoEnum.CreaClienteNoOk, Modulo.Clientes, Criticidad.Dos);
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
                    bitacora.persistirMensajeLogged(EventoEnum.LookupClienteOk, Modulo.Clientes, Criticidad.Cuatro);
                    break;
                case 0:
                    mensaje = "Cliente no encontrado";
                    bitacora.persistirMensajeLogged(EventoEnum.LookupClienteNoOk, Modulo.Clientes, Criticidad.Cuatro);
                    break;
                default:
                    mensaje = "Desconocido";
                    bitacora.persistirMensajeLogged(EventoEnum.LookupClienteNoOk, Modulo.Clientes, Criticidad.Dos);
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
        public void recalcularDV() {
            manejaDbClientes.actualizarTodosDV();
            manejaDbClientes.actualizarDVV();
        }

        public List<string> chequearIntegridad() {
            List<String> errores = new List<String>();
            List<Cliente> clientes = manejaDbClientes.traerTodosClientes();

            clientes.ForEach(c => {
                if (!c.dvh.Equals(manejaDbClientes.calcularDVH(c))) {
                    errores.Add($"En la tabla Clientes, el cliente id : {c.id} fue modificada");
                }
            });
            if (!manejaDbClientes.calcularDVV(clientes).Equals(manejaDbClientes.obtenerDVV())) {
                errores.Add("En la tabla Clientes, el DVV es incorrecto");
            }
            return errores;
        }
    }
}
