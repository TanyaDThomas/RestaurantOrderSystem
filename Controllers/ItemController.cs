using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.JSInterop.Infrastructure;
using RestaurantOrderSystem.Application.Services;
using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.Domain.Entities;
using RestaurantOrderSystem.ViewModels.Item;


namespace RestaurantOrderSystem.Controllers
{
    
    public class ItemController : Controller
    {
        private readonly IItemQueryService _queryService;
        private readonly IItemService _itemService;
        private readonly FileService _fileService;

        public ItemController(IItemQueryService queryService, IItemService itemService, FileService fileService)
        {
            _queryService = queryService;
            _itemService = itemService;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var allItem = await _queryService.GetAllAsync();
            return View(allItem);
        }



        // GET Create Item
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Item
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string? imagePath = null;

            if (model.ImageFile != null)
            {
                imagePath = await _fileService.SaveImageAsync(model.ImageFile, "menu");
            }

            var item = new Item
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImagePath = imagePath
            };

            
            await _itemService.CreateAsync(item);

            return RedirectToAction("Index");
        }


        //public async Task<IActionResult> Create(Item item)
        //{
        //   if(ModelState.IsValid)
        //    {
        //        await _itemService.CreateAsync(item);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(item);
        //}

        //GET Update Item 4
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var existingItem = await _queryService.GetByIdAsync(id);
            if (existingItem == null) return NotFound();

            var viewModel = new ItemViewModel
            {
                Id = existingItem.Id,
                Name = existingItem.Name,
                Description = existingItem.Description,
                Price = existingItem.Price,
                ImagePath = existingItem.ImagePath
            };

            return View(viewModel);

        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var item = await _queryService.GetByIdAsync(model.Id);
            if(item == null) return NotFound();

            var newImagePath = await _fileService.SaveImageAsync(model.ImageFile, "menu");

            item.Name = model.Name;
            item.Description = model.Description;
            item.Price = model.Price;
            if(newImagePath != null) item.ImagePath = newImagePath;

            await _itemService.UpdateAsync(item);

            return RedirectToAction(nameof(Index));
        }

        //GET Delete Item 4 
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _queryService.GetByIdAsync(id);
            if(itemToDelete == null) NotFound();

            return View(itemToDelete);
        }

        //POST Delete Item 4
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           bool deleted = await _itemService.DeleteAsync(id);

            if (!deleted) NotFound();

            return RedirectToAction(nameof(Index));
        }


    }
}
