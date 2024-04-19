using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica_4_WEB.Entities;
using Practica_4_WEB.Models;
using Practica_4_WEB.Services;
using System.Diagnostics;
using System.Net.Http;

namespace Practica_4_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IPrincipalModel _principalModel;
        public HomeController(ILogger<HomeController> logger, IPrincipalModel principalModel)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _principalModel = principalModel;
        }

        public IActionResult Index()
        {
            var resp = _principalModel.ConsultarPrincipal();
            return View(resp!.datos);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Principal()
        {
            var resp = _principalModel.ConsultarPrincipal();
            return View(resp!.datos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
