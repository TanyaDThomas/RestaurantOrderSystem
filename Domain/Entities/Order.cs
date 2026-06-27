using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace RestaurantOrderSystem.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } 
        public Decimal Subtotal { get; set; }
        public Decimal Tax { get; set; }
        public Decimal Total { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();

    }
}
