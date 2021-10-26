using System;
using System.Collections.Generic;
using System.Text;

namespace app.dominio.interfaces
{	public interface IAgregar<TEntidad>
	{
		TEntidad Agregar(TEntidad entidad);
	}
}
