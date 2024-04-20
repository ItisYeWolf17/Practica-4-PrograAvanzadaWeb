using Microsoft.AspNetCore.Mvc;
using Practica_4_WEB.Services;
using System.Net.Http.Json;
using System.Text.Json;

namespace Practica_4_Web.Controllers
{
    public class PrincipalController(IPrincipalModel _principal) : Controller
    {
        public ActionResult Index()
        {
            var resp = _principal.ConsultarCompras();
            if (resp.datos != null)
            {
                var compras = resp.datos;
                return View(compras);
            }
            else
            {
                return View();
            }
        }

        public JsonResult obtenerCompras()
        {
            var resp = _principal.ConsultarCompras();
            if (resp.datos != null)
            {
                var compras = resp.datos.Where(x => x.Estado == "Pendiente").ToList();
                return Json(compras);
            }
            return null;
        }
    }
}