using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KolevDiamonds.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRingService ringService;

        public HomeController(
            ILogger<HomeController> logger,
            IRingService ringService)
        {
            _logger = logger;
            this.ringService = ringService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await ringService.AllRings();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
