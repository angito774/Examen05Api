namespace Examen05Api.Requests
{
    public class ProductoRequest
    {
        public string Nombre { get; set; } = string.Empty;        
        public decimal Precio { get; set; } = 0m;
        public int CategoriaId { get; set; }        
    }
}
