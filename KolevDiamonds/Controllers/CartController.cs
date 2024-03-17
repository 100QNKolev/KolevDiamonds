using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            List<string> cartItems = GetCartItems();
            return View(cartItems);
        }

        public IActionResult AddToCart(int productId)
        {
            List<string> cartItems = GetCartItems();
            cartItems.Add(productId.ToString());
            SaveCartItems(cartItems);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            List<string> cartItems = GetCartItems();
            cartItems.Remove(productId.ToString());
            SaveCartItems(cartItems);
            return RedirectToAction("Index");
        }

        private List<string> GetCartItems()
        {
            var cartItemsString = _httpContextAccessor.HttpContext?.Session.GetString("CartItems");
            if (cartItemsString == null)
            {
                return new List<string>();
            }
            return cartItemsString.Split(',').ToList();
        }

        private void SaveCartItems(List<string> cartItems)
        {
            _httpContextAccessor.HttpContext?.Session.SetString("CartItems", string.Join(",", cartItems));
        }
    }
}
