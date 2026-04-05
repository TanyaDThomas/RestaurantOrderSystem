using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        [Range(1, 100)]
        public int Quantity { get; set; }
        [Range(0, 9999)]
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public Order Order { get; set; } = null!;
        public Item Item { get; set; } = null!;
    }
}
