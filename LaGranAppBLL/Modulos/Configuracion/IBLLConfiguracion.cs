using LaGranAppDAL.Model.Config;
using System.Collections.Generic;

namespace LaGranAppBLL.Modulos.Configuracion
{
    public interface IBLLConfiguracion
    {
        bool Create(lgaConfig Entity);
        bool Delete(lgaConfig Entity);
        List<lgaConfig> List(lgaConfig Entity);
        lgaConfig Read();
        lgaConfig Read(lgaConfig Entity);
        bool Update(lgaConfig Entity);
    }
}