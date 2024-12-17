using Examen05Api.Models;
using Examen05Api.Requests;
using Examen05Api.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen05Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ContextDB db;
        public CategoriaController(ContextDB _context)
        {
            db = _context;
        }

        [HttpPost]
        public bool Insertar(CategoriaRequest obj)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.Nombre = obj.Nombre;
                categoria.Descripcion = obj.Descripcion;

                db.Categorias.Add(categoria);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public IEnumerable<CategoriaResponse> Listar()
        {
            var objj = db.Categorias.ToList();
            var response = objj.Select(x => new CategoriaResponse()
            {
                CategoriaId = x.CategoriaId,
                Nombre= x.Nombre,
                Descripcion = x.Descripcion
            }).ToList();
            return response;
        }

        [HttpGet]
        public CategoriaResponse ListaPorId(int id)
        {
            var objj = db.Categorias.FirstOrDefault(x => x.CategoriaId == id);

            var response = new CategoriaResponse()
            {
                CategoriaId = objj.CategoriaId,
                Nombre = objj.Nombre,
                Descripcion = objj.Descripcion
            };
            return response;
        }




    }
}
