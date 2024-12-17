using System.ComponentModel.DataAnnotations;

namespace Examen05Api.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        public string Nombre { get; set; } =string.Empty;
        public string? Descripcion { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
