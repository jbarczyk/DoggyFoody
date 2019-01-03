using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System;
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
    }
}
