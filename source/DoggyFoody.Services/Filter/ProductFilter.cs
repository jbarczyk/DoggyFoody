using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services.Filter.FilterStrategies;
using DoggyFoody.Services.Filter.Generic;
using System.Collections.Generic;
using System.Linq;

namespace DoggyFoody.Services.Filter
{
    public class ProductFilter : IProductFilter
    {
        private QueryBuilder<Product, FilterParams> _queryBuilder = new QueryBuilder<Product, FilterParams>();

        public ProductFilter()
        {
            _queryBuilder.Mutators = new List<QueryMutator<Product, FilterParams>>
            {
                new QueryMutator<Product, FilterParams>(new DescriptionStrategy()),
                new QueryMutator<Product, FilterParams>(new IngredientsStrategy()),
                new QueryMutator<Product, FilterParams>(new ManufacturersStrategy()),
                new QueryMutator<Product, FilterParams>(new NameStrategy()),
                new QueryMutator<Product, FilterParams>(new FoodTypeStrategy())
            };
        }

        public IQueryable<Product> FilterProducts(IQueryable<Product> products, FilterParams filterParams)
            => _queryBuilder.ApplyFilters(filterParams, products);
    }
}
