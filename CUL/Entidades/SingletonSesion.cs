using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades
{
    public sealed class SingletonSesion
    {
        private static SingletonSesion instance = null;
        private static readonly object lockObject = new object();
        public bool estaLogged = false;
        private static string _codigoIdioma = "es-AR";
        private Usuario usuarioSesion;

        private SingletonSesion()
        {
        }

        public static SingletonSesion getInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonSesion();
                        }
                    }
                }
                return instance;
            }
        }

        public void logIn(Usuario usuario)
        {
            estaLogged = true;
            usuarioSesion = usuario;
        }

        public void logOut()
        {
            estaLogged = false;
            usuarioSesion = null;
        }

        public Usuario getUsuarioActual()
        {
            return usuarioSesion;
        }

        /// <summary>
        /// Verifica si el usuario actual tiene un permiso específico
        /// </summary>
        public bool tienePermiso(TipoPermiso tipoPermiso)
        {
            if (usuarioSesion == null || usuarioSesion.permisos == null)
                return false;

            // Usar el método obtenerTodosLosPermisos del patrón Composite
            return usuarioSesion.permisos
                .SelectMany(componente => componente.obtenerTodosLosPermisos())
                .Any(permiso => permiso.tipoPermiso.Equals(tipoPermiso));
        }

        public static void idiomaActual(string codigoIdioma)
        {
            if (getInstance.usuarioSesion != null)
            {
                getInstance.usuarioSesion.idioma = codigoIdioma;
            }
            else
            {
                _codigoIdioma = codigoIdioma;
            }
        }

        public string getIdiomaActual()
        {
            if (getInstance.usuarioSesion != null)
            {
                if (getInstance.usuarioSesion.idioma != null)
                    return getInstance.usuarioSesion.idioma;
                else
                    getInstance.usuarioSesion.idioma = _codigoIdioma;
                return getInstance.usuarioSesion.idioma;
            }
            else
            {
                return _codigoIdioma;
            }
        }
    }
}
