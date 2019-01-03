using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IColumnService
    {
        IEnumerable<Column> GetRandomColumns(int count);
    }
}