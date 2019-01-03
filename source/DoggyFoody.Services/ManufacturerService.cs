using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System;
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

        public async Task AddManufacturer(Manufacturer manufacturer)
        {
            await _dbContext.AddAsync(manufacturer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteManufacturer(long id)
        {
            var manufacturer = GetManufacturer(id);
            if (manufacturer != null)
            {
                _dbContext.Remove<Manufacturer>(manufacturer);
            }

            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Product> GetManufacturerProducts(long id)
            => GetManufacturer(id)?.Products;

        public IEnumerable<Advertisement> GetManufacturerAdvertisements(long id)
            => GetManufacturer(id)?.Advertisements;

        public async Task AddProductToManufacturer(long manufacturerId, Product product)
        {
            var manufacturer = GetManufacturer(manufacturerId) ?? throw new ArgumentException("Cannot find user");
            if (manufacturer.Products == null)
            {
                manufacturer.Products = new List<Product>();
            }

            manufacturer.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAdvertisement(long manufacturerId, Advertisement advertisement)
        {
            var manufacturer = GetManufacturer(manufacturerId) ?? throw new ArgumentException("Cannot find user");
            if (manufacturer.Advertisements == null)
            {
                manufacturer.Advertisements = new List<Advertisement>();
            }

            manufacturer.Advertisements.Add(advertisement);
            await _dbContext.SaveChangesAsync();
        }
    }
}
