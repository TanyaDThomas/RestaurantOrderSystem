using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.Domain.Entities;
using RestaurantOrderSystem.Infrastructure.Data;
using RestaurantOrderSystem.ViewModels.Customer;

namespace RestaurantOrderSystem.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly OrderSystemDbContext _context;
        private readonly ICustomerQueryService _queryService;

        public CustomerService(OrderSystemDbContext context, ICustomerQueryService queryService)
        {
            _context = context;
            _queryService = queryService;
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<bool> UpdateAsync(Customer customer)
        {
            if (customer == null) return false;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var customerToDelete = await _queryService.GetByIdAsync(id);
            if(customerToDelete == null) return false;
            _context.Remove(customerToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
