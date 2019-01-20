using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using DoggyFoody.Services.Filter;
using Microsoft.EntityFrameworkCore;
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
        private readonly IProductFilter _filter;
        private readonly IColumnService _columnService;

        public ProductService(DoggyFoodyDatabaseContext dbContext, IUserService userService, IProductFilter productFilter, IColumnService columnService)
        {
            _dbContext = dbContext;
            _userService = userService;
            _filter = productFilter;
            _columnService = columnService;
        }

        public IEnumerable<Product> GetAllProducts()
            => _dbContext.Products;

        public IEnumerable<Product> GetProducts(FilterParams filterParams)
        {
            if (filterParams == null)
            {
                throw new ArgumentException("Filter params shoudn't be null");
            }

            return _filter.FilterProducts(_dbContext.Products, filterParams);
        }

        public Product GetProduct(long id)
        {
            return _dbContext.Products
                .Include(x => x.Columns)
                .Include(x => x.Comments)
                .Include(x => x.Rates)
                .FirstOrDefault(x => x.Id == id);
        }

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

        public async Task AddColumnToProduct(long userID, long productId, Column column)
        {
            var user = _userService.GetUser(userID) ?? throw new ArgumentException("Cannot find user");
            var product = GetProduct(productId) ?? throw new ArgumentException("Cannot find product");
            await _columnService.AddColumn(column, userID, productId);
        }

        public IEnumerable<Product> GetProductsOfType(FoodTypeEnum foodType)
        {
            var filterParams = new FilterParams
            {
                FoodType = foodType
            };

            return _filter.FilterProducts(_dbContext.Products, filterParams);
        }
    }
}
