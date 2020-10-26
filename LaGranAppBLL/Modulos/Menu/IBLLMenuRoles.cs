using LaGranAppDAL.Model.Menu;
using System;
using System.Collections.Generic;

namespace LaGranAppBLL.Modulos.Menu
{
    public interface IBLLMenuRoles
    {
        bool Create(lgaMenuRoles Entidad);
        bool Delete(lgaMenuRoles Entidad);
        IList<lgaMenuRoles> List(Guid AppId);
        lgaMenuRoles Read(Guid AppId, int MenuId);
        bool Update(lgaMenuRoles Entidad);
        IList<lgaMenuRoles> List(Guid AppId, int Id);
        List<lgaMenuRoles> List(int Id, Guid AppId);
    }
}