using CUL.Entidades;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Métodos {
    static public class LenguajeActual {
        private static string _lenguajeActual = SingletonSesion.getInstance.getIdiomaActual();

        private static List<IObserver> observers = new List<IObserver>();

        public static string lenguajeActual {
            get { return _lenguajeActual; }
            set {
                _lenguajeActual = value;
                NotifyObservers();
            }
        }

        public static void Attach(IObserver observer) {
            observers.Add(observer);
        }

        public static void Detach(IObserver observer) {
            observers.Remove(observer);
        }

        private static void NotifyObservers() {
            foreach (var observer in observers) {
                observer.actualizarIdioma();
            }
        }
    }
}
