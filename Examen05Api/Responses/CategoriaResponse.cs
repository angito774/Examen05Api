using Examen05Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Examen05Api.Responses
{
    public class CategoriaResponse
    {
        public int CategoriaId { get; set; }        
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }        
    }
}
