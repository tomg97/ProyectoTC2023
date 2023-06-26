using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios.Metodos {
    public class Jsonifier {
        public static void guardarAJsonConLocación(Object payload, string nombre) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult resultado = folderBrowserDialog.ShowDialog();
            if (resultado == DialogResult.OK) {
                string rutaCarpeta = folderBrowserDialog.SelectedPath;
                string rutaArchivo = Path.Combine(rutaCarpeta, nombre + ".json");

                string json = JsonConvert.SerializeObject(payload);
                
                File.WriteAllText(rutaArchivo, json);
            }
        }
    }
}
