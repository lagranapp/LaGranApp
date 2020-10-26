using LaGranAppDAL.Context;
using LaGranAppDAL.CRUD;
using LaGranAppDAL.DatabaseContext;
using LaGranAppDAL.Model.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaGranAppDAL.Modulos.Usuarios
{
    public class DALUsuarios : IDALUsuarios
    {
        private LaGranAppDbContext _oDbContext;
        public DALUsuarios(ILaGranAppDbContext  oDbContext)
        {
            try
            {
                _oDbContext = oDbContext as LaGranAppDbContext;
            }
            catch
            {
                throw;
            }
        }

        public lgaUsuarios Read(Guid AppGuid, string username)
        {
            try
            {               
                return _oDbContext.lgaUsuarios.Where(c => c.Usuario == username && c.AppId == AppGuid.ToString()).FirstOrDefault();

            }
            catch
            {
                throw;
            }
        }

        public List<lgaUsuarios> List(Guid AppGuid)
        {
            try
            {
               
                return _oDbContext.lgaUsuarios.Where(c => c.AppId == AppGuid.ToString()).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<lgaUsuarios> List(Guid AppGuid, string Usuario)
        {
            try
            {
               
                return _oDbContext.lgaUsuarios.Where(c => c.Usuario == Usuario && c.AppId == AppGuid.ToString()).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<lgaUsuarios> List(Guid AppGuid, int PageIndex)
        {
            try
            {
              
              return _oDbContext.lgaUsuarios.Where(c => c.AppId == AppGuid.ToString()).OrderByDescending(d => d.Id).Skip(PageIndex - 1).Take(10).ToList();
            }
            catch
            {
                throw;
            }
        }

        public bool Create(lgaUsuarios Entidad)
        {
            try
            {
               
                _oDbContext.lgaUsuarios.Add(Entidad);
                if (_oDbContext.SaveChanges() > 0)
                {
                    _oDbContext.Entry(Entidad).Reload();
                    return true;
                }
                else return false;
            }
            catch
            {
                throw;
            }
        }

        public lgaUsuarios Read(int UsuarioId)
        {
            try
            {                
                return _oDbContext.lgaUsuarios.Where(c => c.Id == UsuarioId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public bool Update(lgaUsuarios Entidad)
        {
            try
            {                
                _oDbContext.lgaUsuarios.Update(Entidad);
                _oDbContext.Entry(Entidad).State = EntityState.Modified;
                if (_oDbContext.SaveChanges() > 0)
                {
                    _oDbContext.Entry(Entidad).Reload();
                    return true;
                }
                else return false;
            }
            catch
            {
                _oDbContext.Entry(Entidad).Reload();
                throw;
            }
        }

        public bool Delete(lgaUsuarios Entidad)
        {
            try
            {               
                _oDbContext.lgaUsuarios.Remove(Entidad);
                if (_oDbContext.SaveChanges() > 0) return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }

        
    }
}
