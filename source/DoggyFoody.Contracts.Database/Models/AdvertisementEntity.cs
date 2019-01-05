using DoggyFoody.Contracts.Database.Base;

namespace DoggyFoody.Contracts.Database.Models
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageAddress { get; set; }
    }
}
