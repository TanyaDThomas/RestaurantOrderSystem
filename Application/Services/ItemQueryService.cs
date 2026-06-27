using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.Domain.Entities;
using RestaurantOrderSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace RestaurantOrderSystem.Application.Services
{
    public class ItemQueryService : IItemQueryService
    {
        private readonly OrderSystemDbContext _context;

        public ItemQueryService(OrderSystemDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items
             .AsNoTracking()
             .ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

        }

    }
}
