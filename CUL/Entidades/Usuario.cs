using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CUL.Entidades {
    [Serializable]
    public class Usuario {
        private string _nomUsu;
        public Usuario() {
            _permisos = new List<Componente>();
        }
        [XmlElement]
        public string nomUsu {
            get { return _nomUsu; }
            set { _nomUsu = value; }
        }
        private string _pass;
        [XmlElement]
        public string pass {
            get { return _pass; }
            set { _pass = value; }
        }
        [XmlIgnore]
        private List<Componente> _permisos;
        public List<Componente> permisos {
            get { return _permisos; }
            set { _permisos = value; }
        }
        private string _idioma;
        [XmlElement]
        public string idioma {
            get { return _idioma; }
            set { _idioma = value; }
        }
        private string _nombre;
        [XmlElement]
        public string nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apellido;
        [XmlElement]
        public string apellido {
            get { return _apellido; }
            set { _apellido = value; }
        }
        private string _email;
        [XmlElement]
        public string email {
            get { return _email; }
            set { _email = value; }
        }
        private string _telefono;
        [XmlElement]
        public string telefono {
            get { return _telefono; }
            set { _telefono = value; }
        }
        private string _dni;
        [XmlElement]
        public string dni {
            get { return _dni; }
            set { _dni = value; }
        }
    }
}
