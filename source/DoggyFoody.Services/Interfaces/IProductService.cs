using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        void DeleteProduct(long id);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(long id);
        IEnumerable<Column> GetProductColumns(long id);
        IEnumerable<Comment> GetProductComments(long id);
        IEnumerable<Rate> GetProductRates(long id);
    }
}