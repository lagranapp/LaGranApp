using LaGranAppDAL.Model.Usuario;
using System;
using System.Collections.Generic;

namespace LaGranAppDAL.Modulos.Usuarios
{
    public interface IDALUsuarios
    {
        List<lgaUsuarios> List(Guid AppGuid);
        List<lgaUsuarios> List(Guid AppGuid, string Usuario);
        List<lgaUsuarios> List(Guid AppGuid, int PageIndex);
        lgaUsuarios Read(Guid AppGuid, string username);
        lgaUsuarios Read(int Id);
        bool Create(lgaUsuarios Entidad);
        bool Update(lgaUsuarios Entidad);
        bool Delete(lgaUsuarios Entidad);

    }
}