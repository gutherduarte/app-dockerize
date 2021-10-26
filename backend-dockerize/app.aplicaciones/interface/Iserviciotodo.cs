using app.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.aplicaciones.servicio
{
    class IServicioTodo
    {
        public interface IServicioNombre<TEntidad, TEntidadID, TEntidadNombre>
         : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion
        { }
    }
}
