using System.Collections.Generic;
using DoggyFoody.Contracts.Database.Base;
using DoggyFoody.Contracts.Enums;

namespace DoggyFoody.Contracts.Database.Models
{
    public class UserEntity : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<ColumnEntity> Columns { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
