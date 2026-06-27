using Microsoft.AspNetCore.Mvc;
using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.Domain.Entities;
using RestaurantOrderSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace RestaurantOrderSystem.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly OrderSystemDbContext _context;
        private readonly IItemQueryService _queryService;

        public ItemService(OrderSystemDbContext context, IItemQueryService queryService )
        {
            _context = context;
            _queryService = queryService;
        }

        public async Task<Item> CreateAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateAsync(Item item)
        {
            if (item == null) return false;
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteItem == null) return false; 

            _context.Items.Remove(deleteItem);
            await _context.SaveChangesAsync();
  
            return true;
        }

    }
}
