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
        public RespuestaEN<string> Insertar(ProductoRequest obj)
        {
            RespuestaEN<string> _RespuestaEN;
            try
            {
                if (obj.Nombre.Trim().Length == 0 || obj.Precio <= 0)
                {
                    _RespuestaEN = new RespuestaEN<string>() { status = false, msg = "Por favor ingresar los campos requeridos", value = null };
                    return _RespuestaEN;
                }

                Producto _producto = new Producto();
                _producto.Nombre = obj.Nombre;
                _producto.Precio = obj.Precio;
                _producto.CategoriaId = obj.CategoriaId;

                db.Productos.Add(_producto);
                db.SaveChanges();

                _RespuestaEN = new RespuestaEN<string>() { status = true, msg = "Se Guardo Correctamente", value = null };
                return _RespuestaEN;
            }
            catch (Exception ex)
            {
                _RespuestaEN = new RespuestaEN<string>() { status = false, msg = ex.Message, value = null };
                return _RespuestaEN;
            }
        }

        [HttpGet]
        public RespuestaEN<IEnumerable<ProductoResponse>> Listar()
        {
            RespuestaEN<IEnumerable<ProductoResponse>> _RespuestaEN;
            try
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
                _RespuestaEN = new RespuestaEN<IEnumerable<ProductoResponse>>() { status = true, msg = "Ok", value = response };
                return _RespuestaEN;
            }
            catch (Exception ex)
            {
                _RespuestaEN = new RespuestaEN<IEnumerable<ProductoResponse>> { status = false, msg = ex.Message, value = null };
                return _RespuestaEN;
            }            
        }

        [HttpGet]
        public RespuestaEN<ProductoResponse> ListaPorId(int id)
        {
            RespuestaEN<ProductoResponse> _RespuestaEN;
            try
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

                if (response == null)
                {
                    _RespuestaEN = new RespuestaEN<ProductoResponse>() { status = false, msg = "Id Producto No Existe", value = null };
                    return _RespuestaEN;
                }

                _RespuestaEN = new RespuestaEN<ProductoResponse>() { status = true, msg = "Ok", value = response };
                return _RespuestaEN;
            }
            catch (Exception ex)
            {
                _RespuestaEN = new RespuestaEN<ProductoResponse> { status = false, msg = ex.Message, value = null };
                return _RespuestaEN;
            }
        }












    }
}
