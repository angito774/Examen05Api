using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen05Api.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Precio { get; set; } = 0m;

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
