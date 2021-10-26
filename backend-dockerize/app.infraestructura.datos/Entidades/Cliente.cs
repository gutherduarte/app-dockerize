using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using app.dominio;

namespace app.infraestructura.datos.Entidades
{
    public class ClienteEntidadConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(Cliente => Cliente.ClienteID);

            builder.HasMany(p => p.facturas)
               .WithOne(c => c.clienteNav);

        }
    }
}
