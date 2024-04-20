using Practica_4_WEB.Entities;
using Practica_4_WEB.Services;

namespace Practica_4_WEB.Models
{
    public class AbonoModel(IConfiguration _config, HttpClient _client) : IAbono
    {
        public Respuesta RegistrarAbono(Abono entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "Abono";

            JsonContent body = JsonContent.Create(entity);
            var resp = _client.PostAsync(url, body).Result;

            if(resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }
    }
}
