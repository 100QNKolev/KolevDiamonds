using KolevDiamonds.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KolevDiamonds.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductIndexServiceModel> cartItems =  GetCartItems();
            return View(cartItems);
        }

        public async Task<IActionResult> AddToCart(ProductIndexServiceModel item)
        {
            List<ProductIndexServiceModel> cartItems =  GetCartItems();

            bool itemExists = cartItems.Any(i => i.Id == item.Id && i.Name == item.Name);

            if (!itemExists)
            {
                cartItems.Add(item);
                SaveCartItems(cartItems);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveFromCart(int Id, string name)
        {
            List<ProductIndexServiceModel> cartItems =  GetCartItems();
            var itemToRemove = cartItems.Find(item => item.Id == Id && item.Name == name);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartItems(cartItems);
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private List<ProductIndexServiceModel> GetCartItems()
        {
            var cartItemsJson = _httpContextAccessor.HttpContext?.Session.GetString("CartItems");
            if (cartItemsJson == null)
            {
                return new List<ProductIndexServiceModel>();
            }
            return JsonConvert.DeserializeObject<List<ProductIndexServiceModel>>(cartItemsJson);
        }

        [NonAction]
        private void SaveCartItems(List<ProductIndexServiceModel> cartItems)
        {
            var cartItemsJson = JsonConvert.SerializeObject(cartItems);
            _httpContextAccessor.HttpContext?.Session.SetString("CartItems", cartItemsJson);
        }
    }
}