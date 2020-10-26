using LaGranAppDAL.Context;
using LaGranAppDAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaGranAppDAL.CRUD
{
    public abstract class CRUD<T> : ICRUD<T> where T : class
    {
        protected internal DbContext _oCTX;
        private const int RecordsxPage = 10;
        public CRUD(DbContext  dbCtx)
        {
            try
            {
                _oCTX = dbCtx;
            }
            catch
            {
                throw;
            }
        }
        public virtual bool Create(T oEntity)
        {
            try
            {
                DbSet<T> oEntidad = _oCTX.Set<T>();
                oEntidad.Add(oEntity);
                _oCTX.SaveChanges();
                _oCTX.Entry(oEntity).Reload();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual T Read(params object[] oArrayKeys)
        {
            try
            {
                T oTBL = (T)_oCTX.Set<T>().Find(oArrayKeys);
                return oTBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual bool Update(T oEntity)
        {
            try
            {
                DbSet<T> oEntidad = _oCTX.Set<T>();
                oEntidad.Attach(oEntity);
                _oCTX.Entry(oEntity).State = EntityState.Modified;
                _oCTX.SaveChanges();
                _oCTX.Entry(oEntity).Reload();
                return true;
            }
            catch
            {
                throw;
            }
        }
        #region "DELETE"
        public virtual bool Delete(T Entity)
        {
            try
            {
                _oCTX.Set<T>().Remove(Entity);
                _oCTX.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual bool Delete(params object[] oArrayKeys)
        {
            try
            {
                try
                {
                    T oTBL = (T)_oCTX.Set<T>().Find(oArrayKeys);
                    if ((oTBL != null))
                    {
                        _oCTX.Set<T>().Remove(oTBL);
                        _oCTX.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    throw;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region "LIST"
        public virtual IQueryable<T> List(params object[] oArrayKeys)
        {
            try
            {
                if (oArrayKeys.Count() > 0)
                {
                    return (IQueryable<T>)_oCTX.Set<T>().Find(oArrayKeys);
                }
                else
                {
                    return (IQueryable<T>)_oCTX.Set<T>();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IList<T> List(int PageIndex = 1)
        {
            try
            {
                return (from c in (IQueryable<T>)_oCTX.Set<T>() select c).Skip(PageIndex).Take(RecordsxPage).ToList();

            }
            catch
            {
                throw;
            }
        }




        public virtual IList<T> List()
        {
            try
            {
                return (from c in (IQueryable<T>)_oCTX.Set<T>() select c).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


    }
}
