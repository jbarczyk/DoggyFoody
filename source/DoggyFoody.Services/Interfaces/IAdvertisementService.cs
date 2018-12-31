using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IAdvertisementService
    {
        Task AddAdvertisement(Advertisement advertisement);
        void DeleteAdvertisement(long id);
        Advertisement GetAdvertisement(long id);
        IEnumerable<Advertisement> GetAllAdvertisements();
    }
}