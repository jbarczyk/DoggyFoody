using System;
using DoggyFoody.Contracts.Database.Base;

namespace DoggyFoody.Contracts.Database.Models
{
    public class CommentEntity : BaseEntity
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Published { get; set; }
    }
}
