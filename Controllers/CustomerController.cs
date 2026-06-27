using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using RestaurantOrderSystem.Application.Services;
using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.Domain.Entities;
using RestaurantOrderSystem.ViewModels.Customer;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerQueryService _queryService;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerQueryService queryService, ICustomerService customerService)
        {
            _queryService = queryService;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
           
            var customers = await _queryService.GetAllAsync();

            var viewModel = customers.Select(customer => new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode

            }).ToList();
            return View(viewModel);
        }

        // GET Create 4
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST Create 4
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var customer = new Customer
            {
                FirstName = viewModel.FirstName, 
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                City = viewModel.City,
                State = viewModel.State,
                PostalCode = viewModel.PostalCode
            };

            await _customerService.CreateAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        //GET Edit Customer 5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _queryService.GetByIdAsync(id);
            if (customer == null) return NotFound();

            var viewModel = new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode
            };

            return View(viewModel); 
        }

        //POST Edit Customer 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var customer = await _queryService.GetByIdAsync(viewModel.Id);
            if (customer == null) return NotFound();

            customer.FirstName = viewModel.FirstName;
            customer.LastName = viewModel.LastName;
            customer.Email = viewModel.Email;
            customer.Phone = viewModel.Phone;
            customer.Address = viewModel.Address;
            customer.City = viewModel.City;
            customer.State = viewModel.State;
            customer.PostalCode = viewModel.PostalCode;

            await _customerService.UpdateAsync(customer);

            return RedirectToAction(nameof(Index));
        }


        //POST Delete Customer 5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
