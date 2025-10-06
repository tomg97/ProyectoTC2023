using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUL.Entidades;
using DAL.Metodos;
using Servicios.Metodos;
using static DAL.ComercializARDataSet;

namespace BLL.Metodos {
    public class ManejaUsuarios {
        ManejaDbUsuarios manejaDb = new ManejaDbUsuarios();
        BitacoraBLL bitacora = new BitacoraBLL();
        ManejaPermisos manejaPerfil = new ManejaPermisos();
        Encriptador encriptador = new Encriptador();
        Mensajeria mensajeria = new Mensajeria();
        public string loginProcedimiento(Usuario usuario) {
            try {
                usuario.pass = encriptador.encriptarIrreversible(usuario.pass);
                string mensaje;
                if (!SingletonSesion.getInstance.estaLogged) {
                    int resultado = manejaDb.authUsuario(usuario);
                    switch (resultado) {
                        case 3:
                            mensaje = "Exito";
                            SingletonSesion.getInstance.logIn(usuario);
                            bitacora.persistirMensajeLogged(EventoEnum.LoginExitoso, Modulo.Login, Criticidad.Uno);
                            break;
                        case 2:
                            mensaje = "Contraseña";
                            bitacora.persistirMensajeNoLogged(EventoEnum.LoginNoExitoso, Modulo.Login, Criticidad.Uno, usuario.nomUsu);
                            break;
                        case 1:
                            mensaje = "Usuario";
                            bitacora.persistirMensajeNoLogged(EventoEnum.LoginNoExitoso, Modulo.Login, Criticidad.Uno, usuario.nomUsu);
                            break;
                        case 0:
                            mensaje = "Bloqueado";
                            bitacora.persistirMensajeNoLogged(EventoEnum.LoginNoExitoso, Modulo.Login, Criticidad.Uno, usuario.nomUsu);
                            break;
                        default:
                            mensaje = "Desconocido";
                            bitacora.persistirMensajeNoLogged(EventoEnum.LoginNoExitoso, Modulo.Login, Criticidad.Uno, usuario.nomUsu);
                            break;
                    }
                } else {
                    mensaje = "Sesion previamente iniciada.";
                    bitacora.persistirMensajeLogged(EventoEnum.LoginNoExitoso, Modulo.Login, Criticidad.Uno);
                }
                return mensaje;
            } catch (Exception ex) {
                mensajeria.mostrarMensaje(ex.Message);
                bitacora.persistirMensajeNoLogged(EventoEnum.LoginNoExitoso , Modulo.Login, Criticidad.Uno, usuario.nomUsu);
                return "Sesion no iniciada";
            }
        }
        public string lookupUsuario(string usuario) {
            string mensaje;
            int resultado = manejaDb.lookupUsuario(usuario);
            switch (resultado) {
                case 1:
                    mensaje = "Usuario Encontrado";
                    bitacora.persistirMensajeLogged(EventoEnum.LookupUsuarioOk, Modulo.AdminUsuarios, Criticidad.Tres);
                    break;
                case 0:
                    mensaje = "Usuario No Encontrado";
                    bitacora.persistirMensajeLogged(EventoEnum.LookupUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Tres);
                    break;
                default:
                    mensaje = "Desconocido";
                    bitacora.persistirMensajeLogged(EventoEnum.LookupUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Tres);
                    break;
            }
            return mensaje;
        }
        public string crearUsuario(Usuario usuario) {
            string mensaje; 
            try {
                usuario.pass = encriptador.encriptarIrreversible(usuario.pass);
                bitacora.persistirMensajeLogged(EventoEnum.CreaUsuarioOk, Modulo.AdminUsuarios, Criticidad.Uno);
                mensaje = manejaDb.crearUsuario(usuario);
            } catch (Exception ex) {
                bitacora.persistirMensajeLogged(EventoEnum.CreaUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
                mensajeria.mostrarMensaje("Intento de creacion de usuario fallido. Motivo: " + ex.Message);
                mensaje = "Error";
            }
            return mensaje;
        }
        public string modificarNombreUsuario(string usuViejo, string usuNuevo) {
            string mensaje;
            try {
                int resultado = manejaDb.modificarNombreUsuario(usuViejo, usuNuevo);
                if (resultado == 1) {
                    mensaje = "Exito";
                    bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioOk, Modulo.AdminUsuarios, Criticidad.Uno);
                } else if (resultado == 0) {
                    mensaje = "Usuario Existente";
                    bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
                } else {
                    bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
                    throw new Exception("Error inesperado.");
                }
            } catch (Exception ex) {
                mensaje = "Error inesperado. " + ex.Message;
                bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
            }
            return mensaje;
        }
        public List<Usuario> getUsuariosBloqueados() {
            return manejaDb.getUsuariosBloqueados();
        }
        public void desbloquearUsuario(string usuario) {
            manejaDb.desbloquearUsuario(usuario);
        }
        public string cambioContraseña(string passActual, string passNueva) {
            passNueva = encriptador.encriptarIrreversible(passNueva);
            passActual = encriptador.encriptarIrreversible(passActual);

            if(manejaDb.cambioContraseña(passActual, passNueva) == 1) {
                return "Cambio Exitoso";
            } else {
                return "Contraseña Equivocada";
            }
        }
        public List<Usuario> traerTodosUsuarios() {
            return manejaDb.traerTodosUsuarios();
        }
        public void guardarPermisos(Usuario u) {
            manejaDb.guardarPermisos(u);
        }
    }
}
