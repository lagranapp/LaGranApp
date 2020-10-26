using LaGranAppDAL.Context;
using LaGranAppDAL.Model.Usuario;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using LaGranAppDAL.Modulos.Usuarios;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace LaGranAppBLL.Modulos.Usuarios
{
    public class BLLUsuarios : IBLLUsuarios
    {
        private IDALUsuarios _oUsuarios;
        private readonly ILogger<BLLUsuarios> _logger;

        public BLLUsuarios(IDALUsuarios usuarios, ILogger<BLLUsuarios> logger)
        {
            try
            {
                _oUsuarios = usuarios;
                _logger = logger;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }

        }
        public IList<lgaUsuarios> List(Guid AppGuid)
        {
            try
            {
                return _oUsuarios.List(AppGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        public IList<lgaUsuarios> List(Guid AppGuid, int PageIndex)
        {
            try
            {
                return _oUsuarios.List(AppGuid,PageIndex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        public lgaUsuarios Read(Guid AppGuid, string Usuario)
        {
            try
            {
                return _oUsuarios.Read(AppGuid, Usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        public bool Create(lgaUsuarios Entidad)
        {
            try
            {
                return _oUsuarios.Create(Entidad);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }


        public lgaUsuarios Read(int UsuarioId)
        {
            try
            {
                return _oUsuarios.Read(UsuarioId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        public bool Update(lgaUsuarios Entidad)
        {
            try
            {
                return _oUsuarios.Update(Entidad);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        public bool Delete(lgaUsuarios Entidad)
        {
            try
            {
                return _oUsuarios.Delete(Entidad);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }
    }
}
