using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public enum EventoEnum {
        [DescripcionEventoTraduccion("LoginExitoso", typeof(DescripcionEventoTraduccion))]
        LoginNoExitoso,
        [DescripcionEventoTraduccion("LoginNoExitoso", typeof(DescripcionEventoTraduccion))]
        LoginExitoso,
        [DescripcionEventoTraduccion("LookupUsuarioOk", typeof(DescripcionEventoTraduccion))]
        LookupUsuarioOk,
        [DescripcionEventoTraduccion("LookupUsuarioNoOk", typeof(DescripcionEventoTraduccion))]
        LookupUsuarioNoOk,
        [DescripcionEventoTraduccion("CreaUsuarioOk", typeof(DescripcionEventoTraduccion))]
        CreaUsuarioOk,
        [DescripcionEventoTraduccion("CreaUsuarioNoOk", typeof(DescripcionEventoTraduccion))]
        CreaUsuarioNoOk,
        [DescripcionEventoTraduccion("ModificacionUsuarioOk", typeof(DescripcionEventoTraduccion))]
        ModificacionUsuarioOk,
        [DescripcionEventoTraduccion("ModificacionUsuarioNoOk", typeof(DescripcionEventoTraduccion))]
        ModificacionUsuarioNoOk,
        [DescripcionEventoTraduccion("EliminaUsuarioOk", typeof(DescripcionEventoTraduccion))]
        EliminaUsuarioOk,
        [DescripcionEventoTraduccion("EliminaUsuarioNoOk", typeof(DescripcionEventoTraduccion))]
        EliminaUsuarioNoOk,
        [DescripcionEventoTraduccion("BackupOk", typeof(DescripcionEventoTraduccion))]
        BackupOk,
        [DescripcionEventoTraduccion("BackupNoOk", typeof(DescripcionEventoTraduccion))]
        BackupNoOk,
        [DescripcionEventoTraduccion("RestoreOk", typeof(DescripcionEventoTraduccion))]
        RestoreOk,
        [DescripcionEventoTraduccion("RestoreNoOk", typeof(DescripcionEventoTraduccion))]
        RestoreNoOk,
        [DescripcionEventoTraduccion("GenerarDVOk", typeof(DescripcionEventoTraduccion))]
        GenerarDVOk,
        [DescripcionEventoTraduccion("CreaClienteOk", typeof(DescripcionEventoTraduccion))]
        CreaClienteOk,
        [DescripcionEventoTraduccion("CreaClienteNoOk", typeof(DescripcionEventoTraduccion))]
        CreaClienteNoOk,
        [DescripcionEventoTraduccion("LookupClienteOk", typeof(DescripcionEventoTraduccion))]
        LookupClienteOk,
        [DescripcionEventoTraduccion("LookupClienteNoOk", typeof(DescripcionEventoTraduccion))]
        LookupClienteNoOk,
        [DescripcionEventoTraduccion("ModificacionClienteOk", typeof(DescripcionEventoTraduccion))]
        ModificacionClienteOk,
        [DescripcionEventoTraduccion("ModificacionClienteNoOk", typeof(DescripcionEventoTraduccion))]
        ModificacionClienteNoOk,
        [DescripcionEventoTraduccion("EliminaClienteOk", typeof(DescripcionEventoTraduccion))]
        EliminaClienteOk,
        [DescripcionEventoTraduccion("EliminaClienteNoOk", typeof(DescripcionEventoTraduccion))]
        EliminaClienteNoOk,
        [DescripcionEventoTraduccion("CreaProductoOk", typeof(DescripcionEventoTraduccion))]
        CreaProductoOk,
        [DescripcionEventoTraduccion("CreaProductoNoOk", typeof(DescripcionEventoTraduccion))]
        CreaProductoNoOk,
        [DescripcionEventoTraduccion("LookupProductoOk", typeof(DescripcionEventoTraduccion))]
        LookupProductoOk,
        [DescripcionEventoTraduccion("LookupProductoNoOk", typeof(DescripcionEventoTraduccion))]
        LookupProductoNoOk,
        [DescripcionEventoTraduccion("ModificacionProductoOk", typeof(DescripcionEventoTraduccion))]
        ModificacionProductoOk,
        [DescripcionEventoTraduccion("ModificacionProductoNoOk", typeof(DescripcionEventoTraduccion))]
        ModificacionProductoNoOk,
        [DescripcionEventoTraduccion("EliminaProductoOk", typeof(DescripcionEventoTraduccion))]
        EliminaProductoOk,
        [DescripcionEventoTraduccion("EliminaProductoNoOk", typeof(DescripcionEventoTraduccion))]
        EliminaProductoNoOk,
        [DescripcionEventoTraduccion("LookupEventoOk", typeof(DescripcionEventoTraduccion))]
        LookupEventoOk,
        [DescripcionEventoTraduccion("LookupCambioOk", typeof(DescripcionEventoTraduccion))]
        LookupCambioOk,
        [DescripcionEventoTraduccion("RollbackCambioOk", typeof(DescripcionEventoTraduccion))]
        RollbackCambioOk,

    }
}
