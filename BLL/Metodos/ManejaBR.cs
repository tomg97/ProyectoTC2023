using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUL.Entidades;
using Servicios.Metodos;
namespace BLL.Metodos {
    public class ManejaBR {
        ManejaDbBR manejaDb = new ManejaDbBR();
        BitacoraBLL bitacora = new BitacoraBLL();
        public string realizarBackup(string filePath) {
            try {
                manejaDb.realizarBackup(filePath);
                bitacora.persistirMensajeLogged("Backup exitoso", Modulo.BackupRestore, Criticidad.Uno);
                return "Backup exitoso.";
            } catch (Exception ex) {
                bitacora.persistirMensajeLogged("Backup fallido", Modulo.BackupRestore, Criticidad.Uno);
                return "El backup no pudo ser realizado. Razón: " + ex;
            }
        }
        public string realizarRestore(string filePath) {
            try {
                manejaDb.realizarRestore(filePath);
                bitacora.persistirMensajeLogged("Restore exitoso", Modulo.BackupRestore, Criticidad.Uno);
                return "Restore exitoso.";
            } catch (Exception ex) {
                bitacora.persistirMensajeLogged("Restore fallido", Modulo.BackupRestore, Criticidad.Uno);
                return "El restore no pudo ser realizado. Razón: " + ex;
            }
        }
        public void realizarAutoBackup() {
            string folderPath = "C:\\Users\\Public\\Documents\\ComercializAR.bak";
            string filePath = new BackupRestore().Backup(folderPath);
            realizarBackup(filePath);
            bitacora.persistirMensajeLogged("Backup automático exitoso", Modulo.BackupRestore, Criticidad.Uno);
            ManejaDV manejaDV = new ManejaDV();
            manejaDV.almacenarDV();
            bitacora.persistirMensajeLogged("Se almacenó el DV exitosamente", Modulo.BackupRestore, Criticidad.Uno);
        }
    } 
}
