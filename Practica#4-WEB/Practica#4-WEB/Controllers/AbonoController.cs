using Microsoft.AspNetCore.Mvc;
using Practica_4_WEB.Entities;
using Practica_4_WEB.Services;

namespace Practica_4_WEB.Controllers
{
    public class AbonoController(IAbono _abono) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Abono entity)
        {
            var resp = _abono.RegistrarAbono(entity);
            if(resp.Codigo == "1")
            {
                return RedirectToAction("Index", "Principal");
            }
            else
            {
                ViewBag.Mensaje = "Error al Registrar";
            }

            return View();
        }
    }
}
