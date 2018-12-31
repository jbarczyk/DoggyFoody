using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Base;
using DoggyFoody.Contracts.Database.Utils;

namespace DoggyFoody.Contracts.Database.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public IDictionary<string, decimal> Ingredients { get; set; }
        public string IngredientsInternal
        {
            get => Ingredients.SerializeNullable();
            set => Ingredients = value.DeserializeNullable<IDictionary<string, decimal>>();
        }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public string Description { get; set; }
    }
}
