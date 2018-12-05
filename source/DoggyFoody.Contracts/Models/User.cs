using System.Collections.Generic;
using DoggyFoody.Contracts.Enums;

namespace DoggyFoody.Contracts.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<Column> Columns { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
