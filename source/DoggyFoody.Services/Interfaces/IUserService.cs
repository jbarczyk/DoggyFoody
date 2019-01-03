using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoggyFoody.Services
{
    public interface IUserService
    {
        Task AddUser(User newUser);
        Task DeleteUser(long id);
        IEnumerable<User> GetAllUsers();
        User GetUser(long id);
        IEnumerable<Column> GetUserColumns(long id);
        UserTypeEnum? GetUserRole(long id);
        User GetUser(string login, string password);
        Task AddColumnToUser(long userId, Column column);
    }
}