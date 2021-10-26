using app.dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.infraestructura.datos.Entidades
{
    class DetalleFacturaConfig : IEntityTypeConfiguration<DetalleFactura>
    {
        public void Configure(EntityTypeBuilder<DetalleFactura> builder)
        {
            builder.ToTable("DetallePedido");

            builder.HasKey(detalle => new { detalle.ProductoID, detalle.FacturaID });
            //Mrs. GREEN APPLE - インフェルノ（Inferno）
            builder
                .HasOne(detalle => detalle.productoNav)
                .WithMany(ped => ped.detalleFacturas);

            builder
                .HasOne(detalle => detalle.facturaNav)
                .WithMany(venta => venta.facturaDetalles);
        }
    }
}
