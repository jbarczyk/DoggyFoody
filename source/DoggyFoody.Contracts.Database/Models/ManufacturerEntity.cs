using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Base;

namespace DoggyFoody.Contracts.Database.Models
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
