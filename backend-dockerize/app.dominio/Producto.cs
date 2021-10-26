using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace app.dominio
{
    public class Producto
    {
		[Key]
		public Guid ProductoID { get; set; }
		
		public string nombre { get; set; }
		public decimal precio { get; set; }
		
		public string Imagen { get; set; }
		public string descripcion { get; set; }

		public List<DetalleFactura> detalleFacturas { get; set; }
	}
}
