using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoggyFoody.Services
{
    public class ColumnService : IColumnService
    {
        private readonly DoggyFoodyDatabaseContext _dbContext;

        public ColumnService(DoggyFoodyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Column> GetRandomColumns(int count)
            => _dbContext.Columns.OrderBy(x => x.GetHashCode()).Take(count);

        public async Task AddColumn(Column column, long userId, long? productId)
        {
            column.ProductId = productId;
            column.UserId = userId;
            await _dbContext.AddAsync(column);
            await _dbContext.SaveChangesAsync();
        }
    }
}
