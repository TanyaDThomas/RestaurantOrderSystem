
using RestaurantOrderSystem.Domain.Entities;

namespace RestaurantOrderSystem.Domain.Contracts
{
    public interface IItemService
    {
        Task<Item> CreateAsync(Item item);
        Task<bool> UpdateAsync(Item item);
        Task<bool> DeleteAsync(int id);
    }
}
