using Microsoft.AspNetCore.Mvc;
using Practica_4_WEB.Entities;
using Practica_4_WEB.Services;
using System.Net.Http.Headers;

namespace Practica_4_WEB.Models
{
    public class AbonoModel(HttpClient _httpClient, IConfiguration _configuration) : IAbonoModel
    {
        public AbonoRespuesta? RegistrarAbono(Abono entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Abono";

            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<AbonoRespuesta>().Result;

            return null;
        }
    }
}

