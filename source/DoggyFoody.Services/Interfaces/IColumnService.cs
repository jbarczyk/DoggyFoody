using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IColumnService
    {
        IEnumerable<Column> GetRandomColumns(int count);
        Task AddColumn(Column column, long userId, long? productId);
    }
}