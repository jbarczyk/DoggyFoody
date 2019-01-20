using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services.Filter.Generic;
using System.Linq;

namespace DoggyFoody.Services.Filter.FilterStrategies
{
    internal class FoodTypeStrategy : FilterStrategy<Product, FilterParams>
    {
        public FoodTypeStrategy()
        {
            Condition = filterParams => filterParams?.FoodType.HasValue ?? false;

            Mutator = (query, filterParams)
               => query.Where(x => x.FoodType == filterParams.FoodType.Value);
        }
    }
}
