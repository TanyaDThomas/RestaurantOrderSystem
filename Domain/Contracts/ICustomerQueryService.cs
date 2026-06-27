using Microsoft.AspNetCore.Mvc;
using RestaurantOrderSystem.Domain.Entities;


namespace RestaurantOrderSystem.Domain.Contracts
{
    public interface ICustomerQueryService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
    }
}
