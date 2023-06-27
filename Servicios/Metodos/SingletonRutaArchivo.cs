using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Metodos {
    public sealed class SingletonRutaArchivo {
        private static SingletonRutaArchivo instance = null;
        private static readonly object lockObject = new object();
        private string rutaArchivo;
        private SingletonRutaArchivo() {

        }
        public static SingletonRutaArchivo getInstance {
            get {
                if (instance == null) {
                    lock (lockObject) {
                        if (instance == null) {
                            instance = new SingletonRutaArchivo();
                        }
                    }
                }
                return instance;
            }
        }
        public string getRutaArchivo() {
            return rutaArchivo;
        }
        public void setRutaArchivo(string ruta) {
            if (rutaArchivo == null) {
                rutaArchivo = ruta;
            }
        }
        public void resetRuta() {
            rutaArchivo = null;
        }
    }
}
