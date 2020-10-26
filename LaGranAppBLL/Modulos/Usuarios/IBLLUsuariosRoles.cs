using LaGranAppDAL.Model.Usuario;
using System;
using System.Collections.Generic;

namespace LaGranAppBLL.Modulos.Usuarios
{
    public interface IBLLUsuariosRoles
    {
        List<lgaUsuariosRoles> List(Guid AppId, string username);
        bool Create(lgaUsuariosRoles Entity);

        lgaUsuariosRoles Read(params object[] oArrayKeys);

        bool Update(lgaUsuariosRoles Entity);

        bool Delete(lgaUsuariosRoles Entity);
    }
}