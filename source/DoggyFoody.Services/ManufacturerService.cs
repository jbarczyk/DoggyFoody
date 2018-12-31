using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoggyFoody.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly DoggyFoodyDatabaseContext _dbContext;

        public ManufacturerService(DoggyFoodyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Manufacturer> GetAllManufacturers()
            => _dbContext.Manufacturers;

        public Manufacturer GetManufacturer(long id)
            => _dbContext.Manufacturers.FirstOrDefault(x => x.Id == id);

        public Task AddManufacturer(Manufacturer manufacturer)
            => _dbContext.AddAsync(manufacturer);

        public void DeleteManufacturer(long id)
        {
            var manufacturer = GetManufacturer(id);
            if (manufacturer != null)
            {
                _dbContext.Remove<Manufacturer>(manufacturer);
            }
        }

        public IEnumerable<Product> GetManufacturerProducts(long id)
            => GetManufacturer(id)?.Products;

        public IEnumerable<Advertisement> GetManufacturerAdvertisements(long id)
            => GetManufacturer(id)?.Advertisements;
    }
}
