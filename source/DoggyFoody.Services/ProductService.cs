using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoggyFoody.Services
{
    public class ProductService : IProductService
    {
        private readonly DoggyFoodyDatabaseContext _dbContext;

        public ProductService(DoggyFoodyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
            => _dbContext.Products;

        public Product GetProduct(long id)
            => _dbContext.Products.FirstOrDefault(x => x.Id == id);

        public Task AddProduct(Product product)
            => _dbContext.AddAsync(product);

        public void DeleteProduct(long id)
        {
            var product = GetProduct(id);
            if (product != null)
            {
                _dbContext.Remove<Product>(product);
            }
        }

        public IEnumerable<Comment> GetProductComments(long id)
            => GetProduct(id)?.Comments;

        public IEnumerable<Column> GetProductColumns(long id)
            => GetProduct(id)?.Columns;

        public IEnumerable<Rate> GetProductRates(long id)
            => GetProduct(id)?.Rates;
    }
}
