using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestaurantOrderSystem.Domain.Contracts;
using RestaurantOrderSystem.Helpers;
using RestaurantOrderSystem.ViewModels.Cart;

namespace RestaurantOrderSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly IItemQueryService _queryService;

        public CartController(IItemQueryService queryService)
        {
            _queryService = queryService;
        }
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();

            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var item = await _queryService.GetByIdAsync(id);

            var cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();

            var existingCart = cart.FirstOrDefault(x => x.ItemId == id);
            if(existingCart != null)
            {
                existingCart.Quantity++;
            }
            else
            {
                cart.Add(new CartItemViewModel
                {
                    ItemId = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObject("Cart", cart);



            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();

            var item = cart.FirstOrDefault(x => x.ItemId == id);
            if(item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session.SetObject("Cart", cart);

            return RedirectToAction(nameof(Index));        
        }
    }
}
