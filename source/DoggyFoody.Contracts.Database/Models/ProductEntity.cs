using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Base;
using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Utils;

namespace DoggyFoody.Contracts.Database.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public FoodTypeEnum FoodType { get; set; }

        public string Ingredients { get; set; }
        public long ManufacturerId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public string Description { get; set; }
        public string ImageAddress { get; set; }
    }
}
