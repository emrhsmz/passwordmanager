using Microsoft.EntityFrameworkCore;
using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.DataAccess.Concrete.EntityFramework.Context
{
    public class PasswordManagerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7F4NLBQ\SQLEXPRESS;Database=passwordManager;user id=sa;password=test"); // Lenovo
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<AccountProperty> AccountProperties { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<SystemType> SystemTypes { get; set; }
        public DbSet<Safe> Safes { get; set; }
    }
}
