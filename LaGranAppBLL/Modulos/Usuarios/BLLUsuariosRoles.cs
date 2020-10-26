using LaGranAppDAL.Context;
using LaGranAppDAL.CRUD;
using LaGranAppDAL.Modulos.Usuarios;
using LaGranAppDAL.Model.Usuario;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LaGranAppBLL.Modulos.Usuarios
{
    public class BLLUsuariosRoles : IBLLUsuariosRoles
    {

        private IDALUsuariosRoles _oUsuariosRoles;
        private IDALUsuarios _oUsuarios;

        public BLLUsuariosRoles( IDALUsuariosRoles usuariosRoles, IDALUsuarios Usuarios)
        {
            try
            {
                _oUsuariosRoles = usuariosRoles;
                _oUsuarios = Usuarios;
            }
            catch
            {
                throw;
            }
        }

        public bool Create(lgaUsuariosRoles Entity)
        {
            try
            {
                return _oUsuariosRoles.Create(Entity);
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(lgaUsuariosRoles Entity)
        {
            try
            {
                return _oUsuariosRoles.Delete(Entity);
            }
            catch
            {
                throw;
            }
        }

        public List<lgaUsuariosRoles> List(Guid AppId, string username)
        {
            try
            {
                string Id = AppId.ToString();
                return (from c in _oUsuariosRoles.List() join d in _oUsuarios.List(AppId, username) on c.UsuarioId equals d.Id select c).ToList();
            }
            catch
            {
                throw;
            }

        }

        public lgaUsuariosRoles Read(params object[] oArrayKeys)
        {
            try
            {
                return _oUsuariosRoles.Read(oArrayKeys);
            }
            catch
            {
                throw;
            }
        }

        public bool Update(lgaUsuariosRoles Entity)
        {
            try
            {
                return _oUsuariosRoles.Update(Entity);
            }
            catch
            {
                throw;
            }
        }
    }
}

