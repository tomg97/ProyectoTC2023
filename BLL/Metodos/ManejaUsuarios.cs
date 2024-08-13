using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUL.Entidades;
using DAL.Metodos;
using Servicios.Metodos;

namespace BLL.Metodos {
    public class ManejaUsuarios {
        ManejaDbUsuarios manejaDb = new ManejaDbUsuarios();
        //BitacoraBLL bitacora = new BitacoraBLL();
        ManejaPermisos manejaPerfil = new ManejaPermisos();
        Encriptador encriptador = new Encriptador();
        Mensajeria mensajeria = new Mensajeria();
        public string loginProcedimiento(Usuario usuario) {
            try {
                usuario.pass = encriptador.encriptarIrreversible(usuario.pass);
                string mensaje;
                int resultado = manejaDb.authUsuario(usuario);
                switch (resultado) {
                    case 3:
                        mensaje = "Exito";
                        SingletonSesion.getInstance.logIn(usuario);
                        //bitacora.persistirMensaje("Se realizó un intento de login exitoso", Tabla.Usuarios, 0);
                        break;
                    case 2:
                        mensaje = "Contraseña";
                        //bitacora.persistirMensaje("Se realizó un intento de login no exitoso. Contraseña equivocada", Tabla.Usuarios, 2);
                        break;
                    case 1:
                        mensaje = "Usuario";
                        //bitacora.persistirMensaje("Se realizó un intento de login no exitoso. Usuario inexistente", Tabla.Usuarios, 1);
                        break;
                    case 0:
                        mensaje = "Bloqueado";
                        //bitacora.persistirMensaje("Se realizó un intento de login no exitoso. El usuario se encuentra bloqueado", Tabla.Usuarios, 3);
                        break;
                    default:
                        mensaje = "Desconocido";
                        //bitacora.persistirMensaje("Se realizó un intento de login no exitoso. Error desconocido", Tabla.Usuarios, 3);
                        break;
                }
                return mensaje;
            } catch (InvalidOperationException ex) {
                mensajeria.mostrarMensaje(ex.Message);
                return "Sesion iniciada";
            }
        }
        public string lookupUsuario(string usuario) {
            string mensaje;
            int resultado = manejaDb.lookupUsuario(usuario);
            switch (resultado) {
                case 1:
                    mensaje = "Usuario Encontrado";
                    break;
                case 0:
                    mensaje = "Usuario No Encontrado";
                    break;
                default:
                    mensaje = "Desconocido";
                    break;
            }
            return mensaje;
        }
        public string crearUsuario(Usuario usuario) {
            usuario.pass = encriptador.encriptarIrreversible(usuario.pass);
            return manejaDb.crearUsuario(usuario);
        }
        public string modificarNombreUsuario(string usuViejo, string usuNuevo) {
            string mensaje;
            int resultado = manejaDb.modificarNombreUsuario(usuViejo, usuNuevo);
            if (resultado == 1) {
                mensaje = "Exito";
            } else if (resultado == 0) {
                mensaje = "Usuario Existente";
            } else {
                mensaje = "Error inesperado";
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
