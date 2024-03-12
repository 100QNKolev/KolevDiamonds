using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Controllers
{
    public class RingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {


            return View();
        }
    }
}
