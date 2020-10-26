
using LaGranAppDAL.Modulos.Menu;
using LaGranAppDAL.Model.Menu;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace LaGranAppBLL.Modulos.Menu
{
    public class BLLMenuRoles : IBLLMenuRoles
    {
        private IDALMenuRoles _oMenuRoles;

        public BLLMenuRoles(IDALMenuRoles MenuRoles)
        {
            try
            {

                _oMenuRoles = MenuRoles;
            }
            catch
            {
                throw;
            }
        }

        public IList<lgaMenuRoles> List(Guid AppId)
        {
            try
            {
                return _oMenuRoles.List(AppId);
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
                return _oMenuRoles.List(AppId, MenuId);
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
                return _oMenuRoles.List(UsuarioId, AppId);
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
                return _oMenuRoles.Create(Entidad);
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
                return _oMenuRoles.Read(AppId, Id);
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
                return _oMenuRoles.Update(Entidad);
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(lgaMenuRoles Entidad)
        {
            try
            {
                return _oMenuRoles.Delete(Entidad);
            }
            catch
            {
                throw;
            }
        }
    }
}
