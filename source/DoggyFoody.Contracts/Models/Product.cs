using System.Collections.Generic;

namespace DoggyFoody.Contracts.Models
{
    public class Product
    {
        public string Name { get; set; }
        public IDictionary<string, decimal> Ingredients { get; set; }  
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Column> Columns { get; set; }
        public IEnumerable<Rate> Rates { get; set; }
    }
}
