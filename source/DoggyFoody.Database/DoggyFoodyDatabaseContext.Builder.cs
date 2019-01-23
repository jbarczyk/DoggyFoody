using System;
using DoggyFoody.Contracts.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DoggyFoody.Database
{
    public partial class DoggyFoodyDatabaseContext
    {
        public DoggyFoodyDatabaseContext(DbContextOptions<DoggyFoodyDatabaseContext> options)
            : base(options)
        { }

        public DoggyFoodyDatabaseContext()
            :base(new DbContextOptions<DoggyFoodyDatabaseContext>())
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=tcp:doggyfoodyserver.database.windows.net,1433;Initial Catalog=DoggyFoodyDb;
                                       Persist Security Info=False;User ID=jbarczyk;Password=DoggyFoody1997;
                                       MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureProducts(modelBuilder);
            ConfigureManufacturers(modelBuilder);
            ConfigureUsers(modelBuilder);
        }

        private void ConfigureManufacturers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasMany<Product>(x => x.Products)
                .WithOne()
                .HasForeignKey(X => X.ManufacturerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Manufacturer>()
                .HasMany<Advertisement>(x => x.Advertisements)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany<Comment>(x => x.Comments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany<Rate>(x => x.Rates)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany<Column>(x => x.Columns)
                .WithOne()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private void ConfigureUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Column>(x => x.Columns)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany<Comment>()
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
