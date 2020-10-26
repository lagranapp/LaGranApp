using LaGranAppDAL.Model.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaGranAppDAL.Modulos.Configuracion
{
    public interface IDALConfiguracion 
    {
        bool Create(lgaConfig  Entity);
        lgaConfig Read(lgaConfig Entity);
        bool Update(lgaConfig Entity);
        bool Delete(lgaConfig Entity);
        List<lgaConfig> List(lgaConfig Entity);
    }
}
