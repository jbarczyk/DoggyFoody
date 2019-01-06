using System;
using DoggyFoody.Contracts.Database.Base;


namespace DoggyFoody.Contracts.Database.Models
{
    public class Column : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Published { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }
    }
}
