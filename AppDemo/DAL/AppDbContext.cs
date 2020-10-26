using AppDemo.Model.Contar;
using LaGranAppDAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.DAL
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<AppContar> AppContar { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextoptions) : base(dbContextoptions)
        {

        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
