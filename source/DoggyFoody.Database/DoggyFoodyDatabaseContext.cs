using DoggyFoody.Contracts.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DoggyFoody.Database
{
    public partial class DoggyFoodyDatabaseContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
