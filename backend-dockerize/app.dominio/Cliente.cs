using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace app.dominio
{
   public class Cliente
    {
        [Key]

        public Guid ClienteID { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public char Sexo { get; set; }

        public List<Factura> facturas { get; set; }

    }
}
