﻿using KolevDiamonds.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KolevDiamonds.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error(int statusCode)
        {
            if (statusCode == 404) 
            {
                return View("Error404");
            }
            if (statusCode == 500)
            {
                return View("Error500");
            }

            return View();
        }
    }
}
