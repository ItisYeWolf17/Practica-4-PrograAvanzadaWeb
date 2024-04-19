namespace Practica_4_WEB.Entities
{
    public class Principal
    {
        public long Id_Compra { get; set; }
        public decimal Precio { get; set; }
        public decimal Saldo { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

    }
    public class PrincipalRespuesta
    {
        public PrincipalRespuesta()
        {
            Codigo = "00";
            Mensaje = string.Empty;
        }
        public Principal? data { get; set; }
        public List<Principal>? datos { get; set; }
        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }

    }

}
