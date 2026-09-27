using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces {
    public interface IDVDAL<T> {
        String calcularDVH(T obj);
        String calcularDVV(List<T> lista);
        void actualizarDVV();
        void actualizarTodosDV();
        string obtenerDVV();
    }
}
