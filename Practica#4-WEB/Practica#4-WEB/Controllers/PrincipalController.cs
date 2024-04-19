using Microsoft.AspNetCore.Mvc;
using Practica_4_WEB.Entities;
using Practica_4_WEB.Services;
using System.Net.Http.Json;

namespace Practica_4_Web.Controllers
{
    public class PrincipalController (IPrincipalModel _principalModel) : Controller
    {
        [HttpGet]
        public IActionResult ConsultarServicios()
        {
            var resp = _principalModel.ConsultarPrincipal();
            return View(resp!.datos);
        }
    }
}