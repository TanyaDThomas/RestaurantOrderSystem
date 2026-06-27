using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        [Range(1, 100)]
        public int Quantity { get; set; }
        [Range(0, 9999)]
        public decimal UnitPrice { get; set; } //Price at time of order
        public decimal LineTotal { get; set; } // Item x quantity
        
    }
}
