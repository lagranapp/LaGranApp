using AppDemo.Model.Contar;
using LaGranAppDAL.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaGranAppDAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace AppDemo.DAL.Contar
{
    public class DALContar : CRUD<AppContar>,  IDALContar
    {
        private readonly DbContext _dbContext;

        public DALContar(IAppDbContext dbContext) :base (dbContext as DbContext)
        {
            _dbContext = dbContext as DbContext;
        }

        #region "EJEMPLO"
        /*   public AppContar Read(int Id)
           {
               try
               {
                  return  _dbContext.Set<AppContar>().Find(Id);
               }
               catch
               {
                   throw;
               }
           }

           public override bool Update(AppContar Entidad)
           {
               try
               {
                   _dbContext.Set<AppContar>().Update(Entidad);
                   _dbContext.SaveChanges();
                   _dbContext.Entry(Entidad).Reload();
                   return true;
               }
               catch(Exception ex)
               {
                   throw ex;
               }
           }*/
        #endregion
    }
}
