using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Base;
using DoggyFoody.Contracts.Database.Enums;

namespace DoggyFoody.Contracts.Database.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
