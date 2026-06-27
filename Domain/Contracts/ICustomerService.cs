using Microsoft.AspNetCore.Mvc;
using RestaurantOrderSystem.Domain.Entities;
using RestaurantOrderSystem.ViewModels.Customer;

namespace RestaurantOrderSystem.Domain.Contracts
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(Customer customer);
         Task<bool> UpdateAsync(Customer customer);
       Task<bool> DeleteAsync(int id);
    }
}
