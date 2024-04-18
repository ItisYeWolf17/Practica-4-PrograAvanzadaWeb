using Microsoft.AspNetCore.Mvc;
using Practica_4_API.Entities;
using System.Net.Http.Json;

namespace Practica_4_Web.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly HttpClient _httpClient;

        public PrincipalController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:5001/api/Principal");
            response.EnsureSuccessStatusCode();
            var resultado = await response.Content.ReadFromJsonAsync<PrincipalRespuesta>();

            return View(resultado.datos);
        }
    }
}