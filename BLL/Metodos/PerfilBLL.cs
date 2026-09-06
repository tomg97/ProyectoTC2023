using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Metodos
{
    public class PerfilBLL
    {
        private readonly PerfilDAL _repository;

        public PerfilBLL()
        {
            _repository = new PerfilDAL();
        }

        public List<Permiso> obtenerTodosLosPermisos()
        {
            return _repository.obtenerTodosLosPermisos();
        }

        public List<Familia> obtenerTodosLosPerfiles()
        {
            return _repository.obtenerTodosLosPerfiles();
        }

        public Familia obtenerPerfilConJerarquia(int idPerfil)
        {
            List<Familia> perfiles = _repository.obtenerTodosLosPerfiles();
            Familia perfil = perfiles.FirstOrDefault(p => p.id == idPerfil);

            if (perfil != null)
            {
                _repository.cargarJerarquiaPerfil(perfil);
            }

            return perfil;
        }

        public Familia crearPerfil(string nombrePerfil)
        {
            Familia perfil = new Familia();
            perfil.nombre = nombrePerfil;
            perfil.id = _repository.guardarComponente(perfil);
            return perfil;
        }

        public void guardarPerfil(Familia perfil)
        {
            if (perfil == null)
                throw new ArgumentNullException(nameof(perfil));

            if (string.IsNullOrWhiteSpace(perfil.nombre))
                throw new ArgumentException("El nombre del perfil no puede estar vacío");

            _repository.guardarPerfil(perfil);
        }

        public bool existeComponenteEnPerfil(Familia perfil, int idComponente)
        {
            return perfil.contieneId(idComponente);
        }

        public bool agregarComponenteAPerfil(Familia perfil, Componente componente)
        {
            if (perfil == null || componente == null)
                return false;

            if (existeComponenteEnPerfil(perfil, componente.id))
                return false;

            perfil.agregar(componente);
            return true;
        }

        public void cargarPermisosUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            _repository.cargarPermisosUsuario(usuario);
        }

        public void guardarPermisosUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            _repository.guardarPermisosUsuario(usuario);
        }

        public bool usuarioTienePermiso(Usuario usuario, TipoPermiso tipoPermiso)
        {
            if (usuario == null || usuario.permisos == null)
                return false;

            return usuario.permisos
                .SelectMany(c => c.obtenerTodosLosPermisos())
                .Any(p => p.tipoPermiso == tipoPermiso);
        }

        // Métodos legacy para compatibilidad
        public Array GetAllPermisos()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }

        public void GuardarComponente(Componente componente, bool esFamilia)
        {
            _repository.guardarComponente(componente);
        }

        public void GuardarFamilia(Familia familia)
        {
            guardarPerfil(familia);
        }

        public List<Permiso> GetAllPatentes()
        {
            return obtenerTodosLosPermisos();
        }

        public List<Familia> GetAllFamilias()
        {
            return obtenerTodosLosPerfiles();
        }

        public void FillUserComponents(Usuario usuario)
        {
            cargarPermisosUsuario(usuario);
        }

        public void FillFamilyComponents(Familia familia)
        {
            _repository.cargarJerarquiaPerfil(familia);
        }

        public bool Existe(Componente componente, int idBuscar)
        {
            return componente.contieneId(idBuscar);
        }
    }
}