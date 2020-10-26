using AppDemo.Model.Contar;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppDemo.DAL
{
    public interface IAppDbContext
    {
       // public DbSet<AppContar> AppContar { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}