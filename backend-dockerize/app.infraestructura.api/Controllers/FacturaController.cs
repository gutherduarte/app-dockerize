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
    public class FacturaController : Controller
    {
        public DetalleFacturaServicio CrearServicio()
        {
            AppDbContext db = new AppDbContext();
            DetalleFacturasRepositorio repositorioFacturas = new DetalleFacturasRepositorio(db);
            ProductoRepositorio repositorioProducto = new ProductoRepositorio(db);
            FacturaRepositorio repositorioFactura = new FacturaRepositorio(db);
            DetalleFacturasRepositorio repositorioDetalleFactura = new DetalleFacturasRepositorio(db);
            DetalleFacturaServicio servicio = new DetalleFacturaServicio (repositorioFactura, repositorioProducto, repositorioDetalleFactura);

            return servicio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Factura>> Get()
        {
            DetalleFacturaServicio servicio = CrearServicio();

            return Ok(servicio.Listar());

        }

        [HttpGet("{id}")]
        public ActionResult<Factura> Get(Guid id)
        {
            DetalleFacturaServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id));
        }
        // POST: ArticuloController/Create
        [HttpPost]
        public ActionResult<Factura> Post([FromBody] Factura Entidad)
        {
            DetalleFacturaServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(Entidad);

            return Ok(new Factura()
            {

                ClienteID = resultado.ClienteID,
                Fecha = resultado.Fecha,
                Total = resultado.Total,
                FacturaID = resultado.FacturaID
            });
        }
    }
}