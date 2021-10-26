using System;
using System.Collections.Generic;
using System.Text;

namespace app.dominio
{
    public class Factura
    {
        public bool anulado;

        public Guid FacturaID { get; set; }
        public Guid ClienteID { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
     
        public Cliente clienteNav { get; set; }
        public List<DetalleFactura> facturaDetalles { get; set; }
    }
}
