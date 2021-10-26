using System;
using System.Collections.Generic;
using System.Text;

namespace app.dominio.interfaces
{
	public interface IListar<TEntidad, TEntidadID>
	{
		List<TEntidad> Listar();

		TEntidad SeleccionarPorID(TEntidadID entidadId);
	}
}
