using System;
using System.Collections.Generic;
using System.Text;

namespace LaGranAppBLL.Interface
{   public interface IBLL<T>        
    {        
        bool Create(T Entity);        
        T Read(T Entity);        
        bool Update(T Entity);            
        bool Delete(T Entity);        
        List<T> List(T Entity);        
        List<T> List();
        List<T> List(int PageIndex);        
    }
    
}
