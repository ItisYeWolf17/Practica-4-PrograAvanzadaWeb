using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica_4_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Practica_4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController(IConfiguration _config) : ControllerBase
    {
        [HttpGet]
        public IActionResult ConsultarCompras()
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                PrincipalRespuesta answer = new PrincipalRespuesta();

                var resultado = db.Query<Principal>("SP_CONSULTAR_COMPRAS", commandType: CommandType.StoredProcedure).ToList();

                if(resultado == null)
                {
                    answer.Mensaje = "No hay compras realizadas...";
                    answer.Codigo = "-1";

                }
                else
                {
                    answer.datos = resultado;
                }

                return Ok(answer);
            }
        }
    }
}
