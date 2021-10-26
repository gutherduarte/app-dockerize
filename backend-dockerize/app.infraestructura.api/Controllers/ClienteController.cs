using app.aplicaciones.servicio;
using app.dominio;
using app.infraestructura.datos.contexto;
using app.infraestructura.datos.repositorio;
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
    public class ClienteController : Controller
    {
        public ClienteServicio CrearServicio()
        {
            AppDbContext db = new AppDbContext();
            ClienteRepositorio repositorio = new ClienteRepositorio(db);
            ClienteServicio servicio = new ClienteServicio(repositorio);

            return servicio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            ClienteServicio servicio = CrearServicio();

            return Ok(servicio.Listar());

        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(Guid id)
        {
            ClienteServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id));
        }
        // POST: ArticuloController/Create
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Cliente Entidad)
        {
            ClienteServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(Entidad);

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cliente Entidad)
        {
            ClienteServicio servicio = CrearServicio();

            Entidad.ClienteID = id;

            servicio.Editar(Entidad);

            return Ok("Editado exitosamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ClienteServicio servicio = CrearServicio();

            servicio.Eliminar(id);

            return Ok("Eliminado exitosamente");
        }
    }
}