using Microsoft.AspNetCore.Mvc;
using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.ViewModels.Menu;

namespace RestaurantOrderSystem.Controllers
{
    public class MenuController : Controller
    {
        private readonly IItemQueryService _queryService;

        public MenuController(IItemQueryService queryService)
        {
            _queryService = queryService;
           
        }
        public async Task<IActionResult> Index()
        {
            var allItems = await _queryService.GetAllAsync();

            var viewModel = allItems.Select(i => new MenuViewModel
            {
                Id = i.Id,
                ImagePath = i.ImagePath,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
            });

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var menuItem = await _queryService.GetByIdAsync(id);
            if (menuItem == null) NotFound();
            return View(menuItem);
        }
    }
}
