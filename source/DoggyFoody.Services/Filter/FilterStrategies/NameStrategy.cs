using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services.Filter.Generic;
using System.Linq;

namespace DoggyFoody.Services.Filter.FilterStrategies
{
    internal class NameStrategy : FilterStrategy<Product, FilterParams>
    {
        public NameStrategy()
        {
            Condition = filterParams => !string.IsNullOrEmpty(filterParams.Name);

            Mutator =  (query, filterParams) 
                => query.Where(x => x.Name.Contains(filterParams.Name));
        }
    }
}
