using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoggyFoody.Services
{
    public class ProductService : IProductService
    {
        private readonly DoggyFoodyDatabaseContext _dbContext;
        private readonly IUserService _userService;

        public ProductService(DoggyFoodyDatabaseContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public IEnumerable<Product> GetAllProducts()
            => _dbContext.Products;

        public Product GetProduct(long id)
            => _dbContext.Products.FirstOrDefault(x => x.Id == id);

        public async Task DeleteProduct(long id)
        {
            var product = GetProduct(id);
            if (product != null)
            {
                _dbContext.Remove<Product>(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Comment> GetProductComments(long id)
            => GetProduct(id)?.Comments;

        public IEnumerable<Column> GetProductColumns(long id)
            => GetProduct(id)?.Columns;

        public IEnumerable<Rate> GetProductRates(long id)
            => GetProduct(id)?.Rates;

        public async Task AddCommentToProduct(long userID, long productId, Comment comment)
        {
            var user = _userService.GetUser(userID) ?? throw new ArgumentException("Cannot find user");
            var product = GetProduct(productId) ?? throw new ArgumentException("Cannot find product");
            if (product.Comments == null)
            {
                product.Comments = new List<Comment>();
            }

            product.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRateToProduct(long userID, long productId, Rate rate)
        {
            var user = _userService.GetUser(userID) ?? throw new ArgumentException("Cannot find user");
            var product = GetProduct(productId) ?? throw new ArgumentException("Cannot find product");
            if (product.Rates == null)
            {
                product.Rates = new List<Rate>();
            }

            product.Rates.Add(rate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
