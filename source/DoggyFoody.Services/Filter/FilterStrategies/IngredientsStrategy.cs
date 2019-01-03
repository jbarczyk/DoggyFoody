﻿using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services.Filter.Generic;
using System.Linq;

namespace DoggyFoody.Services.Filter.FilterStrategies
{
    internal class IngredientsStrategy : FilterStrategy<Product, FilterParams>
    {
        public IngredientsStrategy()
        {
            Condition = filterParams => filterParams.ContainsIngredients?.Any() ?? false;

            Mutator =  (query, filterParams) 
                => query.Where(x => x.Ingredients.All(indegrient => filterParams.ContainsIngredients.Contains(indegrient.Key)));
        }
    }
}
