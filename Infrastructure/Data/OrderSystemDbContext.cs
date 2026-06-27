using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Domain.Entities;

namespace RestaurantOrderSystem.Infrastructure.Data
{
    public class OrderSystemDbContext : IdentityDbContext
    {
        public OrderSystemDbContext(DbContextOptions<OrderSystemDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Hamburger", Description = "One thick juicy patty on a sesame bun with your choice of toppings.", Price = 3.99M },
                new Item { Id = 2, Name = "Fries", Description = "Straight cut fries fried golden and salted to perfection.", Price = 1.50M }
                 );

            modelBuilder.Entity<Item>()
                .Property(i => i.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Subtotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Tax)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.LineTotal)
                .HasPrecision(10, 2);
               
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
       
    }
}
