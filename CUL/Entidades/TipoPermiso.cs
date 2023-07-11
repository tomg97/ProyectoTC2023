using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public enum TipoPermiso {
        admin_usuarios,
        admin_perfiles,
        admin_idiomas,
        admin_backup,
        admin_bitacora,
        maestros_productos,
        maestros_clientes,
        maestros_proveedores,
        usuario,
        ventas_select,
        ventas_facturar,
        ventas_despachar,
        compras,
        reportes
    }
}
