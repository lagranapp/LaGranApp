using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using LaGranAppDAL;
using LaGranAppDAL.Model.Config;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LaGranAppBLL.Interface;
using LaGranAppDAL.Modulos.Configuracion;
using Microsoft.Extensions.Logging;

namespace LaGranAppBLL.Modulos.Configuracion
{
    public class BLLConfiguracion : IBLLConfiguracion
    {
        private readonly ILogger _logger;
        private IDALConfiguracion _dalConfiguracion;
        public BLLConfiguracion(IDALConfiguracion DalConfiguracion, ILogger<BLLConfiguracion> logger)
        {
            try
            {
                _dalConfiguracion = DalConfiguracion; //IOC.Ioc.Provider.GetService<LaGranAppDAL.Entidad.Configuracion.Configuracion>();   //new LaGranAppDAL.Entidad.Configuracion.Configuracion(_DbContext);               
                _logger = logger;
                _logger.LogError("Configuracion iniciada");
            }
            catch
            {
                throw;
            }
        }

        public bool Create(lgaConfig Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(lgaConfig Entity)
        {
            throw new NotImplementedException();
        }

        public List<lgaConfig> List(lgaConfig Entity)
        {
            throw new NotImplementedException();
        }

        public lgaConfig Read()
        {
            try
            {
                lgaConfig oData = new lgaConfig() { Id = 1 };
                return _dalConfiguracion.Read(oData);
            }
            catch
            {
                throw;
            }
        }

        public lgaConfig Read(lgaConfig Entity)
        {
            lgaConfig oData = new lgaConfig() { Id = 1 };
            return _dalConfiguracion.Read(oData);
        }

        public bool Update(lgaConfig Entity)
        {
            throw new NotImplementedException();
        }
    }
}
