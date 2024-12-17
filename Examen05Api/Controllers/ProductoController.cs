using Examen05Api.Models;
using Examen05Api.Requests;
using Examen05Api.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen05Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ContextDB db;
        public ProductoController(ContextDB _context)
        {
            db = _context;
        }


        [HttpPost]
        public bool Insertar(ProductoRequest obj)
        {
            try
            {
                Producto _producto = new Producto();
                _producto.Nombre = obj.Nombre;
                _producto.Precio = obj.Precio;
                _producto.CategoriaId = obj.CategoriaId;

                db.Productos.Add(_producto);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public IEnumerable<ProductoResponse> Listar()
        {
            var response = (from P in db.Productos
                            join C in db.Categorias on
                            P.CategoriaId equals C.CategoriaId
                            select new ProductoResponse
                            {
                                ProductoId = P.ProductoId,
                                Nombre = P.Nombre,
                                Precio = P.Precio,
                                NombreCategoria = P.Categoria.Nombre
                            }).ToList();
            return response;
        }

        [HttpGet]
        public ProductoResponse ListaPorId(int id)
        {
            var response = (from P in db.Productos
                            join C in db.Categorias on
                            P.CategoriaId equals C.CategoriaId
                            where P.ProductoId == id
                            select new ProductoResponse
                            {
                                ProductoId = P.ProductoId,
                                Nombre = P.Nombre,
                                Precio = P.Precio,
                                NombreCategoria = P.Categoria.Nombre
                            }).FirstOrDefault();
            return response;

        }












    }
}
