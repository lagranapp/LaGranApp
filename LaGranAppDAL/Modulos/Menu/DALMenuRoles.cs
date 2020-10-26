using LaGranAppDAL.CRUD;
using LaGranAppDAL.Model.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LaGranAppDAL.Context;
using LaGranAppDAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using LaGranAppDAL.Model.Usuario;

namespace LaGranAppDAL.Modulos.Menu
{
    public class DALMenuRoles : IDALMenuRoles
    {
        LaGranAppDbContext _oDbContext;
        public DALMenuRoles(ILaGranAppDbContext oDbContext)
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
        /// <summary>
        /// Rutina para devolver todos los registro de menu basado en el AppId
        /// </summary>
        /// <param name="AppId"></param>
        /// <param name="Na"></param>
        /// <returns></returns>
        public IList<lgaMenuRoles> List(Guid AppId)
        {
            try
            {
                return _oDbContext.lgaMenuRoles.Where(c => c.AppId == AppId.ToString()).ToList();

            }
            catch
            {
                throw;
            }
        }

        public IList<lgaMenuRoles> List(Guid AppId, int MenuId)
        {
            try
            {
                return _oDbContext.lgaMenuRoles.Where(c => c.AppId == AppId.ToString() && c.MenuId == MenuId).ToList();

            }
            catch
            {
                throw;
            }
        }

        public List<lgaMenuRoles> List(int UsuarioId, Guid AppId)
        {
            try
            {                
                return  (from c in _oDbContext.lgaUsuarios join d in _oDbContext.lgaUsuariosRoles on c.Id equals d.UsuarioId join e in _oDbContext.lgaMenuRoles on d.RoleId equals e.RoleId where c.AppId == AppId.ToString() && c.Id ==UsuarioId orderby e.MenuId  select e).ToList();
            }
            catch
            {
                throw;
            }
        }

        public bool Create(lgaMenuRoles Entidad)
        {
            try
            {              
                _oDbContext.lgaMenuRoles.Add(Entidad);
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

        public lgaMenuRoles Read(Guid AppId, int Id)
        {
            try
            {
                return _oDbContext.lgaMenuRoles.Where(c => c.AppId == AppId.ToString() && c.Id == Id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public bool Update(lgaMenuRoles Entidad)
        {
            try
            {                
                _oDbContext.lgaMenuRoles.Update(Entidad);
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

        public bool Delete(lgaMenuRoles Entidad)
        {
            try
            {                
                _oDbContext.lgaMenuRoles.Remove(Entidad);
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
