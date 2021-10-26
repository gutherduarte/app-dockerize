using app.dominio;
using app.dominio.interfaces.repositorio;
using app.infraestructura.datos.contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.infraestructura.datos.repositorio
{
    public class FacturaRepositorio : IRepositorioMovimiento<Factura, Guid>
    {
        private AppDbContext db;

        public FacturaRepositorio(AppDbContext _db)
        {
            db = _db;
        }

        public Factura Agregar(Factura factura)
        {
            factura.FacturaID = Guid.NewGuid();

            db.Facturas.Add(factura);

            return factura;
        }

        public List<Factura> Listar()
        {
            return db.Facturas.ToList();
        }

        public Factura SeleccionarPorID(Guid entidadId)
        {
            var FacturaSeleccionado = db.Facturas.Where(c => c.FacturaID == entidadId).FirstOrDefault();
            return FacturaSeleccionado;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public void Anular(Guid entidadId)
        {
            var ventaSeleccionada = SeleccionarPorID(entidadId);

            if (ventaSeleccionada != null)
            {
                ventaSeleccionada.anulado = true;

                db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                throw new NullReferenceException("No se ha encontrado la venta que intenta anular... 😣");
            }
        }
    }
}
