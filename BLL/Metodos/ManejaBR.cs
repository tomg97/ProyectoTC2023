using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ManejaBR {
        ManejaDbBR manejaDb = new ManejaDbBR();
        public string realizarBackup(string filePath) {
            try {
                manejaDb.realizarBackup(filePath);
                return "Backup exitoso.";
            } catch (Exception ex) {
                return "El backup no pudo ser realizado. Razón: " + ex;
            }
        }
        public string realizarRestore(string filePath) {
            try {
                manejaDb.realizarRestore(filePath);
                return "Restore exitoso.";
            } catch (Exception ex) {
                return "El restore no pudo ser realizado. Razón: " + ex;
            }
        }
    } 
}
