using app.dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.infraestructura.datos.Entidades
{
    public class ProductoEntidadConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(detalle => detalle.ProductoID);

            builder.HasMany(Articulo => Articulo.detalleFacturas)
            .WithOne(detalle => detalle.productoNav);

        }

    }
}
