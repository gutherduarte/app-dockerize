using System;
using System.Collections.Generic;
using System.Text;

namespace app.dominio.interfaces
{
	public interface IEditar<TEntidad>
	{
		void Editar(TEntidad entidad);
	}
}
