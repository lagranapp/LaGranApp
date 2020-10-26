using LaGranAppDAL.Context;
using LaGranAppDAL.Model.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaGranAppDAL.DatabaseContext;

namespace LaGranAppDAL.Modulos.Configuracion
{
    public class DALConfiguracion :  IDALConfiguracion
    {
        private readonly ILaGranAppDbContext _odbCTX;

        public DALConfiguracion(ILaGranAppDbContext oDbContext)
        {
            _odbCTX =oDbContext;
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

        public lgaConfig Read(lgaConfig Entity)
        {
            return (from c in _odbCTX.lgaConfig where c.Id == 1 select c).FirstOrDefault();            
            
        }

        public bool Update(lgaConfig Entity)
        {
            throw new NotImplementedException();
        }
    }
}
