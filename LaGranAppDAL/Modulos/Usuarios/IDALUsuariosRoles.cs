using LaGranAppDAL.Model.Usuario;
using System.Collections.Generic;

namespace LaGranAppDAL.Modulos.Usuarios
{
    public interface IDALUsuariosRoles
    {
        List<lgaUsuariosRoles> List();

        bool Create(lgaUsuariosRoles Entity);

        lgaUsuariosRoles Read(params object[] oArrayKeys);

        bool Update(lgaUsuariosRoles Entity);

        bool Delete(lgaUsuariosRoles Entity);
    }
}