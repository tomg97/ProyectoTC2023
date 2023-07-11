using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ManejaPermisos {
        ManejaDbPerfil manejaDbPerfil = new ManejaDbPerfil();
        public bool Existe(Componente c, int id) {
            bool existe = false;
            if (c.id.Equals(id))
                existe = true;
            else
                foreach (var item in c.hijos) {

                    existe = Existe(item, id);
                    if (existe) return true;
                }
            return existe;
        }
        public Array GetAllPermisos() {
            return manejaDbPerfil.GetAllPermisos();
        }
        public void GuardarComponente(Componente p, bool esfamilia) {
            manejaDbPerfil.GuardarComponente(p, esfamilia);
        }
        public void GuardarFamilia(Familia c) {
            manejaDbPerfil.GuardarFamilia(c);
        }
        public List<Permiso> GetAllPatentes() {
            return manejaDbPerfil.GetAllPatentes();
        }
        public List<Familia> GetAllFamilias() {
            return manejaDbPerfil.GetAllFamilias();
        }
        public List<Componente> GetAll(string familia) {
            return manejaDbPerfil.GetAll(familia);
        }
        public void FillUserComponents(Usuario u) {
            manejaDbPerfil.FillUserComponents(u);
        }
        public void FillFamilyComponents(Familia familia) {
            manejaDbPerfil.FillFamilyComponents(familia);
        }
    }
}
