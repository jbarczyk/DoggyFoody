using System;
using DoggyFoody.Contracts.Database.Base;


namespace DoggyFoody.Contracts.Database.Models
{
    public class ColumnEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Published { get; set; }
    }
}
