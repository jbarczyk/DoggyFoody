using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services.Filter;

namespace DoggyFoody.Services
{
    public interface IProductService
    {
        Task AddCommentToProduct(long userID, long productId, Comment comment);
        Task AddRateToProduct(long userID, long productId, Rate comment);
        Task AddColumnToProduct(long userID, long productId, Column column);
        Task DeleteProduct(long id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProducts(FilterParams filterParams);
        Product GetProduct(long id);
        IEnumerable<Column> GetProductColumns(long id);
        IEnumerable<Comment> GetProductComments(long id);
        IEnumerable<Rate> GetProductRates(long id);
        IEnumerable<Product> GetProductsOfType(FoodTypeEnum foodType);
    }
}