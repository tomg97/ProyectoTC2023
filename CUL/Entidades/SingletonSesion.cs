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
    }
}
