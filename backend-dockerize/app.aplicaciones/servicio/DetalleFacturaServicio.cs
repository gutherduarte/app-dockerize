using app.dominio;
using app.dominio.interfaces.repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.aplicaciones.servicio
{
    public class DetalleFacturaServicio : IServicioMovimiento<Factura, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repositorioProducto;
        private readonly IRepositorioMovimiento<Factura, Guid> repositorioFactura;
        private readonly IRepositorioDetalle<DetalleFactura, Guid> repositorioDetalleFactura;

        public DetalleFacturaServicio(

             IRepositorioMovimiento<Factura, Guid> _repositorioFactura,
            IRepositorioBase<Producto, Guid> _repositorioProducto,
            IRepositorioDetalle<DetalleFactura, Guid> _repositorioDetalleFactura

                )
        {
            repositorioFactura = _repositorioFactura;
            repositorioProducto = _repositorioProducto;
            repositorioDetalleFactura = _repositorioDetalleFactura;

        }

        public Factura Agregar(Factura entidad)
        {
            var FacturaAgregada = repositorioFactura.Agregar(entidad);

            entidad.facturaDetalles.ForEach(detalle => {


                var productoSeleccionado = repositorioProducto.SeleccionarPorID(detalle.ProductoID);
                if (productoSeleccionado == null)
                    throw new NullReferenceException("Usted está intentando vender un PRODUCTO que no existe 😡😡😡...");
                detalle.FacturaID = entidad.FacturaID;

                detalle.ProductoID = productoSeleccionado.ProductoID;
                detalle.CostoProductosVendido = productoSeleccionado.precio * detalle.CatidadProductosVendido;
                repositorioProducto.Editar(productoSeleccionado);
                repositorioDetalleFactura.Agregar(detalle);

                entidad.Total += detalle.PrecioProductosVendido; 
            });

            repositorioFactura.GuardarTodosLosCambios();
            return FacturaAgregada;
        }

        public void Anular(Guid ventaId)
        {
            repositorioFactura.Anular(ventaId);
            repositorioFactura.GuardarTodosLosCambios();
        }

        public List<Factura> Listar()
        {
            return repositorioFactura.Listar();
        }

        public Factura SeleccionarPorID(Guid ventaId)
        {
            return repositorioFactura.SeleccionarPorID(ventaId);
        }
    }
}
