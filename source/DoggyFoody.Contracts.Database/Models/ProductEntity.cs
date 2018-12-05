using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Base;
using DoggyFoody.Contracts.Database.Utils;

namespace DoggyFoody.Contracts.Database.Models
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }

        public IDictionary<string, decimal> Ingredients { get; set; }
        public string IngredientsInternal
        {
            get => Ingredients.SerializeNullable();
            set => Ingredients = value.DeserializeNullable<IDictionary<string, decimal>>();
        }

        public virtual ICollection<CommentEntity> Comments { get; set; }
        public virtual ICollection<ColumnEntity> Columns { get; set; }
        public virtual ICollection<RateEntity> Rates { get; set; }
    }
}
