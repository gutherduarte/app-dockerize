using app.dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.infraestructura.datos.Entidades
{
    public class FacturaEntidadConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(p => p.FacturaID);

            builder
                    .HasMany(cli => cli.facturaDetalles)
                    .WithOne(pedido => pedido.facturaNav);

        }
    }
}
