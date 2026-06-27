using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.Domain.Entities;
using RestaurantOrderSystem.Infrastructure.Data;
using SQLitePCL;

namespace RestaurantOrderSystem.Application.Services
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly OrderSystemDbContext _context;
        public CustomerQueryService(OrderSystemDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
             .AsNoTracking()
              .ToListAsync();
        }
        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
