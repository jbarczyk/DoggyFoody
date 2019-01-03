using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System.Collections.Generic;
using System.Linq;

namespace DoggyFoody.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly DoggyFoodyDatabaseContext _dbContext;

        public AdvertisementService(DoggyFoodyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Advertisement> GetAllAdvertisements()
            => _dbContext.Advertisements;

        public Advertisement GetAdvertisement(long id)
            => _dbContext.Advertisements.FirstOrDefault(x => x.Id == id);

        public void DeleteAdvertisement(long id)
        {
            var advertisement = GetAdvertisement(id);
            if (advertisement != null)
            {
                _dbContext.Remove<Advertisement>(advertisement);
            }
        }

        public IEnumerable<Advertisement> GetRandomAdvertisements(int count)
            => GetAllAdvertisements().OrderBy(x => x.GetHashCode()).Take(count);
    }
}
