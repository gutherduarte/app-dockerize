using app.dominio;
using app.dominio.interfaces.repositorio;
using app.infraestructura.datos.contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.infraestructura.datos.repositorio
{
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {

        private AppDbContext db;

        public ProductoRepositorio(AppDbContext _db)
        {
            db = _db;
        }

        public Producto Agregar(Producto producto)
        {
            producto.ProductoID = Guid.NewGuid();

            db.Produtos.Add(producto);

            return producto;
        }

        public List<Producto> Listar()
        {
            return db.Produtos.ToList();
        }

        public void Editar(Producto producto)
        {
            var productoSelecconado = db.Produtos.Where(c => c.ProductoID == producto.ProductoID).FirstOrDefault();
            if (productoSelecconado != null)
            {
                productoSelecconado.nombre = producto.nombre;
                productoSelecconado.precio = producto.precio;
                productoSelecconado.descripcion = producto.descripcion;
                productoSelecconado.Imagen = producto.Imagen;

                db.Entry(productoSelecconado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var productoSeleccionado = db.Produtos.Where(c => c.ProductoID == entidadId).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                db.Produtos.Remove(productoSeleccionado);
            }
        }

        public Producto SeleccionarPorID(Guid entidadId)
        {
            var productoSeleccionado = db.Produtos.Where(c => c.ProductoID == entidadId).FirstOrDefault();
            return productoSeleccionado;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

    }
}
