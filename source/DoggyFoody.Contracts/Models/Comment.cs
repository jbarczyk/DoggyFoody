using System;

namespace DoggyFoody.Contracts.Models
{
    public class Comment
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Published { get; set; }
    }
}
