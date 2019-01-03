using DoggyFoody.Contracts.Database.Enums;
using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Database;
using DoggyFoody.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DoggyFoody.TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DoggyFoodyDatabaseContext>();
            builder.UseSqlServer(@"Server=localhost\sqlexpress;Database=DoggyFoodyDb;Trusted_Connection=True;");

            var context = new DoggyFoodyDatabaseContext(new DbContextOptionsBuilder<DoggyFoodyDatabaseContext>().Options);
            var userService = new UserService(context);
            var productService = new ProductService(context, userService);

            var users = userService.GetAllUsers();
            productService.AddCommentToProduct(1, 1, new Comment
            {
                Author = "Zbyszek",
                Published = DateTime.Now,
                Text = "Komentarz mistrza"
            }).Wait();

            var products = productService.GetAllProducts();
        }
    }
}
