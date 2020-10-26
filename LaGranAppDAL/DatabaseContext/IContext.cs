using LaGranAppDAL.Model.Config;
using LaGranAppDAL.Model.Menu;
using LaGranAppDAL.Model.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaGranAppDAL.Context
{
    public interface IContext : IDisposable
    {
        DbSet<lgaUsuarios> Usuarios { get; set; }
        DbSet<lgaUsuariosRoles> UsuariosRoles { get; set; }
        DbSet<lgaMenuRoles> MenuRoles { get; set; }
        DbSet<lgaConfig> Config { get; set; }
        DbContext DbCtx { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();

    }
}
