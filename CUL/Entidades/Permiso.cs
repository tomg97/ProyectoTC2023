using System.Collections.Generic;

namespace CUL.Entidades
{
    public class Permiso : Componente
    {
        private static readonly List<Componente> _hijosVacios = new List<Componente>();

        public override bool esCompuesto
        {
            get { return false; }
        }

        public override List<Componente> hijos
        {
            get { return _hijosVacios; }
        }

        public override void agregar(Componente componente)
        {
            // Los permisos individuales no pueden tener hijos
        }

        public override void remover(Componente componente)
        {
            // Los permisos individuales no pueden tener hijos
        }

        public override void vaciarHijos()
        {
            // Los permisos individuales no pueden tener hijos
        }

        public override IEnumerable<Componente> obtenerTodosLosPermisos()
        {
            yield return this;
        }
    }
}
