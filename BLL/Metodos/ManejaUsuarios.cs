using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUL.Entidades;
using DAL.Metodos;
using Servicios.Metodos;

namespace BLL.Metodos
{
    public class ManejaUsuarios
    {
        private readonly ManejaDbUsuarios manejaDb;
        private readonly BitacoraBLL bitacora;
        private readonly PerfilBLL perfilBLL;
        private readonly Encriptador encriptador;
        private readonly Mensajeria mensajeria;

        public ManejaUsuarios()
        {
            manejaDb = new ManejaDbUsuarios();
            bitacora = new BitacoraBLL();
            perfilBLL = new PerfilBLL();
            encriptador = new Encriptador();
            mensajeria = new Mensajeria();
        }

        #region Métodos de Autenticación

        /// <summary>
        /// Procesa el login de un usuario
        /// </summary>
        public string loginProcedimiento(Usuario usuario)
        {
            if (usuario == null)
            {
                return "Usuario inválido";
            }

            if (string.IsNullOrWhiteSpace(usuario.nomUsu) || string.IsNullOrWhiteSpace(usuario.pass))
            {
                return "Debe completar todos los campos";
            }

            try
            {
                usuario.pass = encriptador.encriptarIrreversible(usuario.pass);
                string mensaje;

                if (!SingletonSesion.getInstance.estaLogged)
                {
                    int resultado = manejaDb.authUsuario(usuario);
                    mensaje = procesarResultadoLogin(resultado, usuario);
                }
                else
                {
                    mensaje = "Sesion previamente iniciada.";
                    bitacora.persistirMensajeLogged(EventoEnum.LoginNoExitoso, Modulo.Login, Criticidad.Uno);
                }

                return mensaje;
            }
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje(ex.Message);
                bitacora.persistirMensajeNoLogged(EventoEnum.LoginNoExitoso, Modulo.Login, Criticidad.Uno, usuario.nomUsu);
                return "Sesion no iniciada";
            }
        }

        private string procesarResultadoLogin(int resultado, Usuario usuario)
        {
            string mensaje;

            switch (resultado)
            {
                case 3:
                    mensaje = "Exito";
                    SingletonSesion.getInstance.logIn(usuario);
                    cargarPermisosUsuario(usuario);
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

            return mensaje;
        }

        /// <summary>
        /// Carga los permisos de un usuario en el objeto Usuario
        /// </summary>
        private void cargarPermisosUsuario(Usuario usuario)
        {
            try
            {
                perfilBLL.FillUserComponents(usuario);
            }
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje($"Error al cargar permisos del usuario: {ex.Message}");
                bitacora.persistirMensajeLogged(EventoEnum.ErrorGeneral, Modulo.Login, Criticidad.Dos);
            }
        }

        /// <summary>
        /// Cambia la contraseña del usuario actual
        /// </summary>
        public string cambioContraseña(string passActual, string passNueva)
        {
            if (string.IsNullOrWhiteSpace(passActual) || string.IsNullOrWhiteSpace(passNueva))
            {
                return "Debe completar todos los campos";
            }

            if (!SingletonSesion.getInstance.estaLogged)
            {
                return "Debe iniciar sesión";
            }

            try
            {
                string passNuevaEncriptada = encriptador.encriptarIrreversible(passNueva);
                string passActualEncriptada = encriptador.encriptarIrreversible(passActual);

                int resultado = manejaDb.cambioContraseña(passActualEncriptada, passNuevaEncriptada);

                if (resultado == 1)
                {
                    bitacora.persistirMensajeLogged(EventoEnum.CambioContraseñaOk, Modulo.Usuarios, Criticidad.Uno);
                    return "Cambio Exitoso";
                }
                else
                {
                    bitacora.persistirMensajeLogged(EventoEnum.CambioContraseñaNoOk, Modulo.Usuarios, Criticidad.Uno);
                    return "Contraseña Equivocada";
                }
            }
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje($"Error al cambiar contraseña: {ex.Message}");
                bitacora.persistirMensajeLogged(EventoEnum.CambioContraseñaNoOk, Modulo.Usuarios, Criticidad.Uno);
                return "Error al cambiar contraseña";
            }
        }

        #endregion

        #region Métodos de Administración de Usuarios

        /// <summary>
        /// Busca si existe un usuario por nombre
        /// </summary>
        public string lookupUsuario(string usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                return "Debe ingresar un nombre de usuario";
            }

            try
            {
                int resultado = manejaDb.lookupUsuario(usuario);
                string mensaje;

                switch (resultado)
                {
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
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje($"Error al buscar usuario: {ex.Message}");
                bitacora.persistirMensajeLogged(EventoEnum.LookupUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Tres);
                return "Error";
            }
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        public string crearUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return "Usuario inválido";
            }

            if (string.IsNullOrWhiteSpace(usuario.nomUsu) || string.IsNullOrWhiteSpace(usuario.pass))
            {
                return "Debe completar todos los campos obligatorios";
            }

            string mensaje;
            try
            {
                usuario.pass = encriptador.encriptarIrreversible(usuario.pass);
                mensaje = manejaDb.crearUsuario(usuario);

                if (mensaje == "Exito" || mensaje == "Usuario creado correctamente")
                {
                    bitacora.persistirMensajeLogged(EventoEnum.CreaUsuarioOk, Modulo.AdminUsuarios, Criticidad.Uno);
                }
                else
                {
                    bitacora.persistirMensajeLogged(EventoEnum.CreaUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
                }
            }
            catch (Exception ex)
            {
                bitacora.persistirMensajeLogged(EventoEnum.CreaUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
                mensajeria.mostrarMensaje("Intento de creacion de usuario fallido. Motivo: " + ex.Message);
                mensaje = "Error";
            }

            return mensaje;
        }

        /// <summary>
        /// Modifica el nombre de usuario
        /// </summary>
        public string modificarNombreUsuario(string usuViejo, string usuNuevo)
        {
            if (string.IsNullOrWhiteSpace(usuViejo) || string.IsNullOrWhiteSpace(usuNuevo))
            {
                return "Debe completar todos los campos";
            }

            if (usuViejo.Equals(usuNuevo, StringComparison.OrdinalIgnoreCase))
            {
                return "El nombre nuevo debe ser diferente al actual";
            }

            string mensaje;
            try
            {
                int resultado = manejaDb.modificarNombreUsuario(usuViejo, usuNuevo);

                if (resultado == 1)
                {
                    mensaje = "Exito";
                    bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioOk, Modulo.AdminUsuarios, Criticidad.Uno);
                }
                else if (resultado == 0)
                {
                    mensaje = "Usuario Existente";
                    bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
                }
                else
                {
                    bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
                    throw new Exception("Error inesperado.");
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado. " + ex.Message;
                bitacora.persistirMensajeLogged(EventoEnum.ModificacionUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
            }

            return mensaje;
        }

        /// <summary>
        /// Obtiene la lista de todos los usuarios del sistema
        /// </summary>
        public List<Usuario> traerTodosUsuarios()
        {
            try
            {
                return manejaDb.traerTodosUsuarios();
            }
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje($"Error al obtener usuarios: {ex.Message}");
                bitacora.persistirMensajeLogged(EventoEnum.ErrorGeneral, Modulo.AdminUsuarios, Criticidad.Dos);
                return new List<Usuario>();
            }
        }

        /// <summary>
        /// Obtiene la lista de usuarios bloqueados
        /// </summary>
        public List<Usuario> getUsuariosBloqueados()
        {
            try
            {
                return manejaDb.getUsuariosBloqueados();
            }
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje($"Error al obtener usuarios bloqueados: {ex.Message}");
                bitacora.persistirMensajeLogged(EventoEnum.ErrorGeneral, Modulo.AdminUsuarios, Criticidad.Dos);
                return new List<Usuario>();
            }
        }

        /// <summary>
        /// Desbloquea un usuario específico
        /// </summary>
        public void desbloquearUsuario(string usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                mensajeria.mostrarMensaje("Debe especificar un usuario");
                return;
            }

            try
            {
                manejaDb.desbloquearUsuario(usuario);
                bitacora.persistirMensajeLogged(EventoEnum.DesbloqueoUsuarioOk, Modulo.AdminUsuarios, Criticidad.Uno);
            }
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje($"Error al desbloquear usuario: {ex.Message}");
                bitacora.persistirMensajeLogged(EventoEnum.DesbloqueoUsuarioNoOk, Modulo.AdminUsuarios, Criticidad.Uno);
            }
        }

        #endregion

        #region Métodos de Gestión de Permisos

        /// <summary>
        /// Guarda los permisos asignados a un usuario
        /// </summary>
        public void guardarPermisos(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(usuario.nomUsu))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío", nameof(usuario));
            }

            try
            {
                manejaDb.guardarPermisos(usuario);
                bitacora.persistirMensajeLogged(EventoEnum.AsignacionPermisosOk, Modulo.AdminPerfiles, Criticidad.Uno);
            }
            catch (Exception ex)
            {
                bitacora.persistirMensajeLogged(EventoEnum.AsignacionPermisosNoOk, Modulo.AdminPerfiles, Criticidad.Uno);
                throw new Exception($"Error al guardar permisos del usuario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Carga los permisos de un usuario específico
        /// </summary>
        public void cargarPermisos(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(usuario.nomUsu))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío", nameof(usuario));
            }

            try
            {
                perfilBLL.FillUserComponents(usuario);
            }
            catch (Exception ex)
            {
                bitacora.persistirMensajeLogged(EventoEnum.ErrorGeneral, Modulo.AdminPerfiles, Criticidad.Dos);
                throw new Exception($"Error al cargar permisos del usuario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica si un usuario tiene un permiso específico
        /// </summary>
        public bool tienePermiso(Usuario usuario, TipoPermiso permiso)
        {
            if (usuario == null || usuario.permisos == null)
            {
                return false;
            }

            try
            {
                return perfilBLL.usuarioTienePermiso(usuario, permiso);
            }
            catch (Exception ex)
            {
                mensajeria.mostrarMensaje($"Error al verificar permisos: {ex.Message}");
                bitacora.persistirMensajeLogged(EventoEnum.ErrorGeneral, Modulo.AdminPerfiles, Criticidad.Dos);
                return false;
            }
        }

        #endregion

        #region Métodos de Validación

        /// <summary>
        /// Valida que los datos básicos del usuario sean correctos
        /// </summary>
        public bool validarDatosUsuario(Usuario usuario, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (usuario == null)
            {
                mensajeError = "El usuario no puede ser nulo";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.nomUsu))
            {
                mensajeError = "El nombre de usuario es obligatorio";
                return false;
            }

            if (usuario.nomUsu.Length < 3)
            {
                mensajeError = "El nombre de usuario debe tener al menos 3 caracteres";
                return false;
            }

            if (usuario.nomUsu.Length > 50)
            {
                mensajeError = "El nombre de usuario no puede exceder 50 caracteres";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.pass))
            {
                mensajeError = "La contraseña es obligatoria";
                return false;
            }

            if (usuario.pass.Length < 6)
            {
                mensajeError = "La contraseña debe tener al menos 6 caracteres";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida el formato de un email
        /// </summary>
        public bool validarEmail(string email, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(email))
            {
                mensajeError = "El email no puede estar vacío";
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                mensajeError = "El formato del email no es válido";
                return false;
            }

            return true;
        }

        #endregion
    }
}
