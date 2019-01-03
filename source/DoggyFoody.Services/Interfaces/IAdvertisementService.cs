using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IAdvertisementService
    {
        void DeleteAdvertisement(long id);
        Advertisement GetAdvertisement(long id);
        IEnumerable<Advertisement> GetAllAdvertisements();
        IEnumerable<Advertisement> GetRandomAdvertisements(int count);
    }
}