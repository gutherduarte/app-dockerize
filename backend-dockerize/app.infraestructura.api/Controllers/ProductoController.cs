using app.aplicaciones.servicio;
using app.dominio;
using app.infraestructura.datos.contexto;
using app.infraestructura.datos.repositorio;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.infraestructura.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        public ProductoServicio CrearServicio()
        {
            AppDbContext db = new AppDbContext();
            ProductoRepositorio repositorio = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repositorio);

            return servicio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            ProductoServicio servicio = CrearServicio();

            return Ok(servicio.Listar());

        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}")]

        public ActionResult<Producto> Get(Guid id)
        {
            ProductoServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id));
        }
        // POST: ArticuloController/Create
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto Entidad)
        {
            ProductoServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(Entidad);

            return Ok(resultado);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]

        public ActionResult Put(Guid id, [FromBody] Producto Entidad)
        {
            ProductoServicio servicio = CrearServicio();

            Entidad.ProductoID = id;

            servicio.Editar(Entidad);

            return Ok("Editado exitosamente");
        }

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ProductoServicio servicio = CrearServicio();

            servicio.Eliminar(id);

            return Ok("Eliminado exitosamente");
        }

    }
}
