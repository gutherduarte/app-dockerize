using System;
using System.Collections.Generic;
using System.Text;


namespace app.dominio.interfaces.repositorio
{
	public interface IRepositorioDetalle<TEntidad, TMovimientoID>
	   : IAgregar<TEntidad>, ITransaccion
	{
		List<TEntidad> SeleccionarDetallesPorMovimiento(TMovimientoID movimientoId);

	}
}
