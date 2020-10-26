using LaGranAppDAL.Context;
using LaGranAppDAL.CRUD;
using LaGranAppDAL.DatabaseContext;
using LaGranAppDAL.Model.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LaGranAppDAL.Modulos.Usuarios
{
    public class DALUsuariosRoles : IDALUsuariosRoles
    {
        LaGranAppDbContext _DbContext;
        public DALUsuariosRoles(ILaGranAppDbContext oDbContext)
        {
            try
            {
                _DbContext = oDbContext as LaGranAppDbContext;
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
                _DbContext.lgaUsuariosRoles.Add(Entity);
                if (_DbContext.SaveChanges() > 0)
                {
                    _DbContext.Entry(Entity).Reload();
                    return true; 

                }

                else return false;
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
                _DbContext.lgaUsuariosRoles.Remove(Entity);
                if (_DbContext.SaveChanges() > 0) return true;
                else return true;
            }
            catch
            {
                throw;
            }
        }

        public List<lgaUsuariosRoles> List()
        {
            try
            {
                return _DbContext.lgaUsuariosRoles.ToList();
            }
            catch
            {
                throw;
            }
        }

        public lgaUsuariosRoles  Read(params object[] oArrayKeys)
        {
            try
            {
                return _DbContext.lgaUsuariosRoles.Find(oArrayKeys);
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
                _DbContext.lgaUsuariosRoles.Update(Entity);
                _DbContext.Entry(Entity).State = EntityState.Modified;
                if (_DbContext.SaveChanges() > 0) 
                {
                    _DbContext.Entry(Entity).Reload();
                    return true; 
                }
                else return false;
            }
            catch
            {
                _DbContext.Entry(Entity).Reload();
                throw;
            }
        }
    }
}
