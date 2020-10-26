using LaGranAppDAL.Model.Usuario;
using System;
using System.Collections.Generic;

namespace LaGranAppBLL.Modulos.Usuarios
{
    public interface IBLLUsuarios
    {
        IList<lgaUsuarios> List(Guid AppGuid);

        IList<lgaUsuarios> List(Guid AppGuid, int PageIndex);
        lgaUsuarios Read(Guid AppGuid, string Usuario);

        lgaUsuarios Read(int UsuarioId);
        bool Create(lgaUsuarios Entidad);
        bool Update(lgaUsuarios Entidad);
        bool Delete(lgaUsuarios Entidad);

    }
}