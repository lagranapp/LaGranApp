using LaGranAppDAL.Model.Config;
using LaGranAppDAL.Model.Menu;
using LaGranAppDAL.Model.Usuario;
using Microsoft.EntityFrameworkCore;

namespace LaGranAppDAL.DatabaseContext
{
    public interface ILaGranAppDbContext
    {
        DbSet<lgaConfig> lgaConfig { get; set; }
        DbSet<lgaMenuRoles> lgaMenuRoles { get; set; }
        DbSet<lgaUsuarios> lgaUsuarios { get; set; }
        DbSet<lgaUsuariosRoles> lgaUsuariosRoles { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}