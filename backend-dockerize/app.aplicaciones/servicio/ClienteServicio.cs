using app.dominio;
using app.dominio.interfaces.repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.aplicaciones.servicio
{
    public class ClienteServicio : IServicioBase<Cliente, Guid>
    {
        private readonly IRepositorioBase<Cliente, Guid> repositorio;

        public ClienteServicio(IRepositorioBase<Cliente, Guid> _repositorio)
        {
            repositorio = _repositorio;
        }

        public Cliente Agregar(Cliente entidad)
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
        public List<Cliente> Listar()
        {
            return repositorio.Listar();
        }

        public void Editar(Cliente entidad)
        {
            repositorio.Editar(entidad);
            repositorio.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repositorio.Eliminar(entidadId);
            repositorio.GuardarTodosLosCambios();
        }

        public Cliente SeleccionarPorID(Guid entidadId)
        {
            return repositorio.SeleccionarPorID(entidadId);
        }

        public void GuardarTodosLosCambios()
        {
            repositorio.GuardarTodosLosCambios();
        }
    }
}
