using app.dominio;
using app.dominio.interfaces.repositorio;
using app.infraestructura.datos.contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.infraestructura.datos.repositorio
{
    public class DetalleFacturasRepositorio : IRepositorioDetalle<DetalleFactura, Guid>
    {
        private AppDbContext db;

        public DetalleFacturasRepositorio(AppDbContext _db)
        {
            db = _db;
        }

        public DetalleFactura Agregar(DetalleFactura entidad)
        {

            db.DetalleFacturas.Add(entidad);

            return entidad;
        }


        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<DetalleFactura> SeleccionarDetallesPorMovimiento(Guid movimientoId)
        {
            return db.DetalleFacturas.Where(c => c.FacturaID == movimientoId).ToList();
        }
    }
}
