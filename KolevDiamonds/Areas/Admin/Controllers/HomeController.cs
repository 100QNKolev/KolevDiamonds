using Microsoft.AspNetCore.Mvc;

namespace KolevDiamonds.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
