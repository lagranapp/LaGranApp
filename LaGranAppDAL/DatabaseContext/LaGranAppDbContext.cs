using LaGranAppDAL.Model.Config;
using LaGranAppDAL.Model.Menu;
using LaGranAppDAL.Model.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaGranAppDAL.DatabaseContext
{
    public class LaGranAppDbContext : DbContext, ILaGranAppDbContext
    {
        public LaGranAppDbContext(DbContextOptions<LaGranAppDbContext> options) : base(options) { }
        public DbSet<lgaUsuarios> lgaUsuarios { get; set; }
        public DbSet<lgaUsuariosRoles> lgaUsuariosRoles { get; set; }
        public DbSet<lgaMenuRoles> lgaMenuRoles { get; set; }
        public DbSet<lgaConfig> lgaConfig { get; set; }                        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
           
        }
    }
}
