using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(500)]
        public string? Description { get; set; }
        [Range(0, 999.99)]
        public decimal Price { get; set; }

    }
}
