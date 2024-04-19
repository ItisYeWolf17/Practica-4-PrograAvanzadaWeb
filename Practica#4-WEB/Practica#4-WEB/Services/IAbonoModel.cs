using Practica_4_WEB.Entities;

namespace Practica_4_WEB.Services
{
    public interface IAbonoModel
    {
        AbonoRespuesta? RegistrarAbono(Abono entity);
    }
}