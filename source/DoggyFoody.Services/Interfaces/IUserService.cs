using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Models;

namespace DoggyFoody.Services
{
    public interface IUserService
    {
        Task AddUser(User newUser);
        void DeleteUser(long id);
        IEnumerable<User> GetAllUsers();
        User GetUser(long id);
        IEnumerable<Column> GetUserColumns(long id);
        UserTypeEnum? GetUserRole(long id);
    }
}