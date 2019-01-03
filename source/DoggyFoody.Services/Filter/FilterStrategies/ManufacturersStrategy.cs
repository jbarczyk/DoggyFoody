using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services.Filter.Generic;
using System.Linq;

namespace DoggyFoody.Services.Filter.FilterStrategies
{
    internal class ManufacturersStrategy : FilterStrategy<Product, FilterParams>
    {
        public ManufacturersStrategy()
        {
            Condition = filterParams => filterParams.ManufacturerIds?.Any() ?? false;

            Mutator =  (query, filterParams) 
                => query.Where(x =>  filterParams.ManufacturerIds.Contains(x.ManufacturerId));
        }
    }
}
