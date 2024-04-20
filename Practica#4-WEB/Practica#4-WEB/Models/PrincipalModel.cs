
using Practica_4_WEB.Entities;
using Practica_4_WEB.Services;

namespace Practica_4_WEB.Models
{
    public class PrincipalModel(HttpClient _client, IConfiguration _config) : IPrincipalModel
    {
        public PrincipalRespuesta ConsultarCompras()
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "Principal";

            var resp = _client.GetAsync(url).Result;

            if(resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<PrincipalRespuesta>().Result;
            }
            return null;
        }
    }
}
