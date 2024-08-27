using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Metodos {
    public class BackupRestore {
        public string Backup(string folderPath) {
            string timeStamp = DateTime.Now.ToString("ddMMyy_HHmm");
            string fileName = $"BAK_{timeStamp}.bak";
            string filePath = Path.Combine(folderPath, fileName);
            return filePath;
        }
        public string Restore(string folderPath) {
        
        }
    }
}
