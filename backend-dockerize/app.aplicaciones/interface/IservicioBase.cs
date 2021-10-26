using System;
using System.Collections.Generic;
using System.Text;
using app.dominio.interfaces;

namespace app.aplicaciones.servicio
{
	public interface IServicioBase<TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
	{ }
}

