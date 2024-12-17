namespace Examen05Api.Responses
{
    public class ProductoResponse
    {
        public int ProductoId { get; set; }        
        public string Nombre { get; set; } = string.Empty;        
        public decimal Precio { get; set; } = 0m;
        public string NombreCategoria { get; set; } = string.Empty;
    }
}
