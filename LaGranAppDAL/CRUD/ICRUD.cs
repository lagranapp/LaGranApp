using System.Collections.Generic;
using System.Linq;

namespace LaGranAppDAL.CRUD
{
    public interface ICRUD<T> where T : class
    {
        bool Create(T oEntity);
        bool Delete(params object[] oArrayKeys);
        bool Delete(T Entity);
        IList<T> List();
        IList<T> List(int PageIndex = 1);
        IQueryable<T> List(params object[] oArrayKeys);
        T Read(params object[] oArrayKeys);
        bool Update(T oEntity);
    }
}