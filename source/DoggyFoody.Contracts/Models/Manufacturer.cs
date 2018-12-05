using System.Collections.Generic;

namespace DoggyFoody.Contracts.Models
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Advertisement> Advertisements { get; set; }
    }
}
