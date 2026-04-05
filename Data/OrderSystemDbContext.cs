using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Data
{
    public class OrderSystemDbContext : IdentityDbContext
    {
        public OrderSystemDbContext(DbContextOptions<OrderSystemDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
       
    }
}
