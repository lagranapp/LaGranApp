using LaGranAppDAL.Model.Config;
using LaGranAppDAL.Model.Menu;
using LaGranAppDAL.Model.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LaGranAppDAL.Context
{
    public class SQLite : DbContext, IContext
    {
        private readonly string _connectionString;

        public DbSet<lgaUsuarios> Usuarios { get; set;}
        public DbSet<lgaUsuariosRoles> UsuariosRoles { get; set; }
        public DbSet<lgaMenuRoles> MenuRoles { get; set; }
        public DbSet<lgaConfig> Config { get; set; }
        public DbContext DbCtx { get { return this; } }

        public SQLite(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Filename=" + ConfigurationManager.AppSettings["providerSQLite"].ToString(), options =>
            optionsBuilder.UseSqlite(_connectionString, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });            
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<lgaUsuarios>().ToTable("lgaUsuarios", "lgaUsuarios");
            modelBuilder.Entity<lgaUsuariosRoles>().ToTable("lgaUsuariosRoles", "lgaUsuariosRoles");
            modelBuilder.Entity<lgaMenuRoles>().ToTable("lgaMenuRoles", "lgaMenuRoles");
            modelBuilder.Entity<lgaConfig>().ToTable("lgaConfig", "lgaConfig");

            modelBuilder.Entity<lgaUsuarios>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id).IsUnique();
                //entity.Property(e => e.DateTimeAdd).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<lgaUsuariosRoles>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id).IsUnique();                
            });

            modelBuilder.Entity<lgaUsuarios>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id).IsUnique();
                //entity.Property(e => e.DateTimeAdd).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<lgaMenuRoles>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id).IsUnique();

            });

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
