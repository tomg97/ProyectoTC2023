using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public sealed class SingletonSesion {
        private static SingletonSesion instance = null;
        private static readonly object lockObject = new object();
        public bool estaLogged = false;
        private static string _codigoIdioma = "es-AR";
        private Usuario usuarioSesion;
        private SingletonSesion() {

        }
        public static SingletonSesion getInstance {
            get {
                if (instance == null) {
                    lock (lockObject) {
                        if (instance == null) {
                            instance = new SingletonSesion();
                        }
                    }
                }
                return instance;
            }
        }
        public void logIn(Usuario usuario) {
            estaLogged = true;
            usuarioSesion = usuario;
        }
        public void logOut() {
            estaLogged = false;
            usuarioSesion = null;
        }
        public Usuario getUsuarioActual() {
            return usuarioSesion;
        }
        public bool tienePermiso(TipoPermiso tipoPermiso) {
            bool existe = false;
            foreach (var item in usuarioSesion.permisos) {
                if (item.tipoPermiso.Equals(tipoPermiso))
                    return true;
                else {
                    existe = estaEnRol(item, tipoPermiso, existe);
                    if (existe) return true;
                }
            }
            return existe;
        }
        bool estaEnRol(Componente c, TipoPermiso tipoPermiso, bool existe) {
            if (c.tipoPermiso.Equals(tipoPermiso))
                existe = true;
            else {
                foreach (var item in c.hijos) {
                    existe = estaEnRol(item, tipoPermiso, existe);
                    if (existe) return true;
                }
            }
            return existe;
        }
        public static void idiomaActual(string codigoIdioma) {
            if(getInstance.usuarioSesion != null) {
                getInstance.usuarioSesion.idioma = codigoIdioma; 
            } else {
                _codigoIdioma = codigoIdioma;
            }
        }
        public string getIdiomaActual() {
            if (getInstance.usuarioSesion != null) {
                return getInstance.usuarioSesion.idioma;
            } else {
                return _codigoIdioma;
            }
        }
    }
}
