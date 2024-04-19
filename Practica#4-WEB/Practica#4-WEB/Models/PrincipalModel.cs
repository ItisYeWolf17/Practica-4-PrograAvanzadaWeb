using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using Practica_4_WEB.Services;
using Practica_4_WEB.Entities;

namespace Practica_4_WEB.Models
{
    public class PrincipalModel (HttpClient _httpClient, IConfiguration _configuration) : IPrincipalModel
    {
        public PrincipalRespuesta? ConsultarPrincipal()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Principal";

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<PrincipalRespuesta>().Result;

            return null;
        }
    }
}
