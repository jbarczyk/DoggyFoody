using DoggyFoody.Contracts.Database.Base;

namespace DoggyFoody.Contracts.Database.Models
{
    public class Rate : BaseEntity
    {
        public int Score { get; set; }
    }
}
