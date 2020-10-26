using LaGranAppDAL.Model.Menu;
using System;
using System.Collections.Generic;

namespace LaGranAppDAL.Modulos.Menu
{
    public interface IDALMenuRoles
    {
        bool Create(lgaMenuRoles Entidad);
        bool Delete(lgaMenuRoles Entidad);
        IList<lgaMenuRoles> List(Guid AppId);
        lgaMenuRoles Read(Guid AppId, int MenuId);
        bool Update(lgaMenuRoles Entidad);
        IList<lgaMenuRoles> List(Guid AppId, int Id);
        List<lgaMenuRoles> List(int UsuarioId, Guid AppId);
    }
}