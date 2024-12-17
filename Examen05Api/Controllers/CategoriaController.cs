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
        public RespuestaEN<string> Insertar(CategoriaRequest obj)
        {
            RespuestaEN<string> _RespuestaEN;
            try
            {
                if (obj.Nombre.Trim().Length == 0)
                {
                    _RespuestaEN = new RespuestaEN<string>() { status = false, msg = "Por favor ingresar los campos requeridos", value = null };
                    return _RespuestaEN;
                }

                Categoria categoria = new Categoria();
                categoria.Nombre = obj.Nombre;
                categoria.Descripcion = obj.Descripcion;

                db.Categorias.Add(categoria);
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
        public RespuestaEN<IEnumerable<CategoriaResponse>> Listar()
        {
            RespuestaEN<IEnumerable<CategoriaResponse>> _RespuestaEN;
            try
            {
                var objj = db.Categorias.ToList();
                var response = objj.Select(x => new CategoriaResponse()
                {
                    CategoriaId = x.CategoriaId,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion
                }).ToList();
                _RespuestaEN = new RespuestaEN<IEnumerable<CategoriaResponse>>() { status = true, msg = "Ok", value = response };
                return _RespuestaEN;
            }
            catch (Exception ex)
            {
                _RespuestaEN = new RespuestaEN<IEnumerable<CategoriaResponse>> { status = false, msg = ex.Message, value = null };
                return _RespuestaEN;
            }
        }

        [HttpGet]
        public RespuestaEN<CategoriaResponse> ListaPorId(int id)
        {
            RespuestaEN<CategoriaResponse> _RespuestaEN;
            try
            {
                var objj = db.Categorias.FirstOrDefault(x => x.CategoriaId == id);
                if (objj == null)
                {
                    _RespuestaEN = new RespuestaEN<CategoriaResponse>() { status = false, msg = "Id Categoria No Existe", value = null };
                    return _RespuestaEN;
                }
                var response = new CategoriaResponse()
                {
                    CategoriaId = objj.CategoriaId,
                    Nombre = objj.Nombre,
                    Descripcion = objj.Descripcion
                };
                _RespuestaEN = new RespuestaEN<CategoriaResponse>() { status = true, msg = "Ok", value = response };
                return _RespuestaEN;
            }
            catch (Exception ex)
            {
                _RespuestaEN = new RespuestaEN<CategoriaResponse> { status = false, msg = ex.Message, value = null };
                return _RespuestaEN;
            }
        }




    }
}
