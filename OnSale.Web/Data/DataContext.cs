using Microsoft.EntityFrameworkCore;
using OnSale.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Objetos que se crean en la BD
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índices
            modelBuilder.Entity<Country>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Category>().
                HasIndex(t => t.Name).
                IsUnique();

            modelBuilder.Entity<Product>().
                HasIndex(t => t.Name).
                IsUnique();
        }
    }

}
