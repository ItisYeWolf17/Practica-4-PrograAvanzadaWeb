namespace Practica_4_WEB.Entities
{
    public class Abono
    {
        public long Id_Abono { get; set; }
        public long Id_Compra { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class AbonoRespuesta
    {
        public Abono data { get; set; }
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
    }

}
