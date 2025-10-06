using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    [AttributeUsage(AttributeTargets.All)]
    public class DescripcionEventoTraduccion : DescriptionAttribute {

        private readonly ResourceManager _resourceManager;

        private readonly string _resourceKey;

        public DescripcionEventoTraduccion(string resourceKey, Type resourceType) {
            if (resourceType == null) {
                throw new ArgumentNullException("resourceType");
            }
            if (string.IsNullOrEmpty(resourceKey)) {
                throw new ArgumentNullException("resourceKey");
            }
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }
        public override string Description {
            get {
                string displayName = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrEmpty(displayName) ? string.Format("[[{0}]]", _resourceKey) : displayName;
            }
        }
    }
}
