using app.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.aplicaciones.servicio
{
	public interface IServicioMovimiento<TEntidad, TEntidadID> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>
	{
		void Anular(TEntidadID entidadId);
	}
}
