using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IProductService
    {
        Task AddCommentToProduct(long userID, long productId, Comment comment);
        Task AddRateToProduct(long userID, long productId, Rate comment);
        Task DeleteProduct(long id);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(long id);
        IEnumerable<Column> GetProductColumns(long id);
        IEnumerable<Comment> GetProductComments(long id);
        IEnumerable<Rate> GetProductRates(long id);
    }
}