using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = "";
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = "";
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = "";
        [MaxLength(20)]
        public string? Phone {  get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; } = "";
        [Required, MaxLength(50)]
        public string City { get; set; } = "";
        [Required, MaxLength(20)]
        public string State { get; set; } = "";
        [Required, MaxLength(10)]
        public string PostalCode { get; set; } = "";
        public IdentityUser IdentityUser { get; set; } = null!;
        public List<Order> Orders { get; set; } = new();
    }
}
