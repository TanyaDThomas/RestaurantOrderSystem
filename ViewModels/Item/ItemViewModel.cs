using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.ViewModels.Item
{
    public class ItemViewModel
    {
       public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }
    }
}
