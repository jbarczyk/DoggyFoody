using System.Linq;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services.Filter
{
    public interface IProductFilter
    {
        IQueryable<Product> FilterProducts(IQueryable<Product> products, FilterParams filterParams);
    }
}