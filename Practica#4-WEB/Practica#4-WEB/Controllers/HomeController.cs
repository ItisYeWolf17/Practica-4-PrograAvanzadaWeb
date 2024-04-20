using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica_4_WEB.Entities;
using Practica_4_WEB.Models;
using Practica_4_WEB.Services;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Practica_4_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IPrincipalModel _principalModel;
        private readonly IAbonoModel _abonoModel;
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

        [HttpGet]
        public IActionResult Abono()
        {
            var resp = _principalModel.ConsultarPrincipal();

            if (resp != null)
            {
                var compras = resp?.datos?.Where(x => x.Estado == "Pendiente").ToList();
                var opciones = compras?.Select(x => new SelectListItem
                {
                    Value = x.Id_Compra.ToString(),
                    Text = x.Descripcion

                }).ToList();

                ViewBag.SelectList = opciones;


                var json = JsonSerializer.Serialize(compras);

                ViewBag.Json = json;
                return View("Privacy");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Abono(Abono entidad)
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
