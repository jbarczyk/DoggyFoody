using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DoggyFoody.Database
{
    class DoggyFoodyDatabaseContextDesignTimeFactory : IDesignTimeDbContextFactory<DoggyFoodyDatabaseContext>
    {
        public DoggyFoodyDatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DoggyFoodyDatabaseContext>();
            return new DoggyFoodyDatabaseContext(builder.Options);
        }
    }
}
