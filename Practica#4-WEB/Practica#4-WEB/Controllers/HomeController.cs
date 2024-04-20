using Microsoft.AspNetCore.Mvc;
using Practica_4_WEB.Entities;
using Practica_4_WEB.Models;
using System.Diagnostics;
using System.Net.Http;

namespace Practica_4_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
