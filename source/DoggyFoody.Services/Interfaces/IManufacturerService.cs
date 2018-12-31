using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IManufacturerService
    {
        Task AddManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(long id);
        IEnumerable<Manufacturer> GetAllManufacturers();
        Manufacturer GetManufacturer(long id);
        IEnumerable<Advertisement> GetManufacturerAdvertisements(long id);
        IEnumerable<Product> GetManufacturerProducts(long id);
    }
}