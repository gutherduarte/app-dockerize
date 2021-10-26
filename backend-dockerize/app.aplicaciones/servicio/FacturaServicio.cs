using app.dominio;
using app.dominio.interfaces.repositorio;
using System;
using System.Collections.Generic;

namespace app.aplicaciones.servicio
{
    public class FacturaServicio : IServicioBase<Factura, Guid>
    {

        private readonly IRepositorioBase<Factura, Guid> repositorio;

        public FacturaServicio(IRepositorioBase<Factura, Guid> _repositorio)
        {
            repositorio = _repositorio;
        }

        public Factura Agregar(Factura entidad)
        {
            if (entidad != null)
            {
                var resultado = repositorio.Agregar(entidad);
                repositorio.GuardarTodosLosCambios();
                return resultado;
            }
            else
                throw new Exception("Error la entidad no puede ser nula");
        }

        public List<Factura> Listar()
        {
            return repositorio.Listar();
        }

        public void Editar(Factura entidad)
        {
            repositorio.Editar(entidad);
            repositorio.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repositorio.Eliminar(entidadId);
            repositorio.GuardarTodosLosCambios();
        }

        public Factura SeleccionarPorID(Guid entidadId)
        {
            return repositorio.SeleccionarPorID(entidadId);
        }

        public void GuardarTodosLosCambios()
        {
            repositorio.GuardarTodosLosCambios();
        }

    }
}
