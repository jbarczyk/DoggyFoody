using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Base;

namespace DoggyFoody.Contracts.Database.Models
{
    public class ManufacturerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
        public virtual ICollection<AdvertisementEntity> Advertisements { get; set; }
    }
}
