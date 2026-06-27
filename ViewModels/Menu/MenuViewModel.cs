using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.ViewModels.Menu
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string DisplayPrice => Price.ToString("C");

    }
}
