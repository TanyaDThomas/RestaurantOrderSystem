using RestaurantOrderSystem.Domain.Entities;

namespace RestaurantOrderSystem.Domain.Contracts
{
    public interface IItemQueryService
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);

    }
}
