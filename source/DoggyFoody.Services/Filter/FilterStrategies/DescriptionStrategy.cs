using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services.Filter.Generic;
using System.Linq;

namespace DoggyFoody.Services.Filter.FilterStrategies
{
    internal class DescriptionStrategy : FilterStrategy<Product, FilterParams>
    {
        public DescriptionStrategy()
        {
            Condition = filterParams => !string.IsNullOrEmpty(filterParams.DescriptionContains);

            Mutator =  (query, filterParams) 
                => query.Where(x => x.Description.Contains(filterParams.DescriptionContains));
        }
    }
}
