using DoggyFoody.Contracts.Database.Enums;
using System.Collections.Generic;

namespace DoggyFoody.Services.Filter
{
    public class FilterParams
    {
        public string Name { get; set; }
        public string DescriptionContains { get; set; }
        public IEnumerable<long> ManufacturerIds { get; set; }
        public IEnumerable<string> ContainsIngredients { get; set; }
        public FoodTypeEnum? FoodType { get; set; }
    }
}
