using System;
using System.Collections.Generic;
using System.Text;

namespace app.dominio.interfaces
{
	public interface IEliminar<TEntidadID>
	{
		void Eliminar(TEntidadID entidadId);
	}
}
