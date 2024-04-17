using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica_4_API.Entities;
using System.Data.SqlClient;

namespace Practica_4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonoController(IConfiguration _config) : ControllerBase
    {
        [HttpPost]
        public IActionResult RegistrarAbono(Abono entity)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                Respuesta answer = new Respuesta();

                var resultado = db.Query<Abono>("SP_REGISTRAR_ABONO",
                    new
                    {
                        COMPRA = entity.Id_Compra,
                        MONTO = entity.Monto
                    }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

                if (resultado.Id_Abono != -1 && resultado != null)
                {
                    answer.Codigo = "1";
                    answer.Mensaje = "Se ha registrado el abono..";
                }
                else
                {
                    answer.Codigo = "-1";
                    answer.Mensaje = "Error al registrar el abono..";
                }
                return Ok(answer);
            }
        }
    }
}
