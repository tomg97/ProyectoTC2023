using System;
using System.Collections.Generic;
using System.Linq;

namespace CUL.Entidades
{
    public abstract class Componente
    {
        private int _id;
        private string _nombre;
        private TipoPermiso _tipoPermiso;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public TipoPermiso tipoPermiso
        {
            get { return _tipoPermiso; }
            set { _tipoPermiso = value; }
        }

        public abstract bool esCompuesto { get; }
        public abstract List<Componente> hijos { get; }

        public abstract void agregar(Componente componente);
        public abstract void remover(Componente componente);
        public abstract void vaciarHijos();

        /// <summary>
        /// Obtiene todos los permisos de forma aplanada (incluyendo jerarquía)
        /// </summary>
        public virtual IEnumerable<Componente> obtenerTodosLosPermisos()
        {
            yield return this;
            foreach (var hijo in hijos)
            {
                foreach (var permiso in hijo.obtenerTodosLosPermisos())
                {
                    yield return permiso;
                }
            }
        }

        /// <summary>
        /// Verifica si existe un componente con el ID especificado en la jerarquía
        /// </summary>
        public virtual bool contieneId(int idBuscar)
        {
            if (id == idBuscar) return true;
            return hijos.Any(hijo => hijo.contieneId(idBuscar));
        }

        public override bool Equals(object obj)
        {
            return obj is Componente componente && id == componente.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nombre} (ID: {id})";
        }
    }
}