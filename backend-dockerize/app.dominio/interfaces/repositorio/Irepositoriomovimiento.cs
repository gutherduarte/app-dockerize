using System;
using System.Collections.Generic;
using System.Text;

namespace app.dominio.interfaces.repositorio
{
	public interface IRepositorioMovimiento<TEntidad, TEntidadID>
		   : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
	{

		void Anular(TEntidadID entidadId);

	}
	class Irepositoriomovimiento
    {
    }
}
