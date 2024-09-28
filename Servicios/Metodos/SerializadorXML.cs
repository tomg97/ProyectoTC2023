using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Servicios.Metodos {
    public class SerializadorXML {
        public void serializarObjetoConXML<T>(T obj) {
            // Prompt the user to select the file location
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                // Serialize the object to XML and save it to the selected file location
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextWriter writer = new StreamWriter(saveFileDialog.FileName)) {
                    serializer.Serialize(writer, obj);
                }
                MessageBox.Show("El objeto fue serializado exitosamente.");
            }
        }

        public T deserializarObjetoDesdeXML<T>() {
            // Prompt the user to select the XML file to deserialize
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                // Deserialize the XML file into an object
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StreamReader(openFileDialog.FileName)) {
                    return (T)serializer.Deserialize(reader);
                }
            }
            return default(T);
        }
    }
}
