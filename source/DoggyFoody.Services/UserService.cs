﻿using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoggyFoody.Services
{
    public class UserService : IUserService
    {
        private readonly DoggyFoodyDatabaseContext _dbContext;

        public UserService(DoggyFoodyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
            => _dbContext.Users;

        public User GetUser(long id)
            => _dbContext.Users.FirstOrDefault(x => x.Id == id);

        public UserTypeEnum? GetUserRole(long id)
            => GetUser(id)?.UserType;

        public async Task AddUser(User newUser)
        {
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Column> GetUserColumns(long id)
            => GetUser(id)?.Columns;

        public User GetUser(string login, string password)
            => _dbContext.Users.FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password));

        public async Task DeleteUser(long id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                _dbContext.Remove<User>(user);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddColumnToUser(long userId, Column column)
        {
            var user = GetUser(userId) ?? throw new ArgumentException("Cannot find user");
            if(user.Columns == null)
            {
                user.Columns = new List<Column>();
            }

            user.Columns.Add(column);
            await _dbContext.SaveChangesAsync();
        }
    }
}