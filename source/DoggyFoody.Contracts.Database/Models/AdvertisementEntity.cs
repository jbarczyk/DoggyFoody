using DoggyFoody.Contracts.Database.Base;

namespace DoggyFoody.Contracts.Database.Models
{
    public class AdvertisementEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
