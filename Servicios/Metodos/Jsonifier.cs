using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios.Metodos {
    public class Jsonifier {
        Mensajeria mensajeria = new Mensajeria();
        public void guardarAJsonConLocación(Object payload, string nombre) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult resultado = folderBrowserDialog.ShowDialog();
            if (resultado == DialogResult.OK) {
                string rutaCarpeta = folderBrowserDialog.SelectedPath;
                string rutaArchivo = Path.Combine(rutaCarpeta, nombre + ".json");

                string json = JsonConvert.SerializeObject(payload);
                
                File.WriteAllText(rutaArchivo, json);
            }
        }
        public T cargarFacturaYRellenarTreeView<T>(TreeView tree) {
            T resultado = default(T);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string rutaArchivo = openFileDialog.FileName;
                SingletonRutaArchivo.getInstance.setRutaArchivo(rutaArchivo);
                string jsonArchivo = File.ReadAllText(rutaArchivo);
                rellenarTreeView(tree, jsonArchivo);
                resultado = JsonConvert.DeserializeObject<T>(jsonArchivo); 
            }
            return resultado;
        }
        public void rellenarTreeView(TreeView treeView, string payload) {
            treeView.Nodes.Clear();
            if (!string.IsNullOrEmpty(payload)) {
                TreeNode root = new TreeNode("JSON");
                treeView.Nodes.Add(root);
                try {
                    JToken token = JToken.Parse(payload);
                    poblarTree(root, token);
                    treeView.ExpandAll();
                } catch (JsonReaderException ex) {
                    mensajeria.mostrarMensaje("Formato de JSON invalido.");
                }
            } else {
                mensajeria.mostrarMensaje("No hay datos");
            } 
        }

        private void poblarTree(TreeNode root, JToken token) {
            if (token is JValue) {
                root.Nodes.Add(new TreeNode(token.ToString()));
            } else if (token is JObject) {
                JObject obj = (JObject)token;
                foreach (var property in obj.Properties()) {
                    TreeNode nodoPropiedad = new TreeNode(property.Name);
                    root.Nodes.Add(nodoPropiedad);
                    poblarTree(nodoPropiedad, property.Value);
                }
            } else if (token is JArray) {
                JArray obj = (JArray)token;
                for (int i = 0; i < obj.Count; i++) {
                    TreeNode nodo = new TreeNode("[" + i + "]");
                    root.Nodes.Add(nodo);
                    poblarTree(nodo, obj[i]);
                }
            } else if (token is JProperty) {
                JProperty obj = (JProperty)token;
                TreeNode nodoPropiedad = new TreeNode(obj.Name);
                root.Nodes.Add(nodoPropiedad);
                poblarTree(nodoPropiedad, obj.Value);
            }
        }
        public void moverArchivoDone(string rutaArchivo, string nombreSubDirectorio) {
            string directorioInicial = Path.GetDirectoryName(rutaArchivo);
            string subDirectorio = nombreSubDirectorio;
            string pathSubDirectorio = Path.Combine(directorioInicial, subDirectorio);
            if (!Directory.Exists(pathSubDirectorio)) { 
                Directory.CreateDirectory(pathSubDirectorio);
            }
            string nombreArchivo = Path.GetFileName(rutaArchivo);
            string destino = Path.Combine(pathSubDirectorio, nombreArchivo);
            File.Move(rutaArchivo, destino);
        }
    }
}
