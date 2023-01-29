using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Shared.Classes
{
    public class Pizzas
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

    }
}
