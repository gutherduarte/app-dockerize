using app.dominio;
using app.dominio.interfaces.repositorio;
using app.infraestructura.datos.contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.infraestructura.datos.repositorio
{
    public class ClienteRepositorio : IRepositorioBase<Cliente, Guid>
    {

        private AppDbContext db;

        public ClienteRepositorio(AppDbContext _db)
        {
            db = _db;
        }

        public Cliente Agregar(Cliente cliente)
        {
            cliente.ClienteID = Guid.NewGuid();

            db.clientes.Add(cliente);

            return cliente;
        }

        public List<Cliente> Listar()
        {
            return db.clientes.ToList();
        }

        public void Editar(Cliente cliente)
        {
            var ClienteSeleccionado = db.clientes.Where(c => c.ClienteID == cliente.ClienteID).FirstOrDefault();
            if (ClienteSeleccionado != null)
            {
                ClienteSeleccionado.Nombres = cliente.Nombres;
                ClienteSeleccionado.Cedula = cliente.Cedula;
                ClienteSeleccionado.Apellidos = cliente.Apellidos;
                ClienteSeleccionado.Direccion = cliente.Direccion;
                ClienteSeleccionado.Telefono = cliente.Telefono;
                ClienteSeleccionado.Sexo = cliente.Sexo;

                db.Entry(ClienteSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var ClienteSeleccionado = db.clientes.Where(c => c.ClienteID == entidadId).FirstOrDefault();
            if (ClienteSeleccionado != null)
            {
                db.clientes.Remove(ClienteSeleccionado);
            }
        }

        public Cliente SeleccionarPorID(Guid entidadId)
        {
            var ClienteSeleccionado = db.clientes.Where(c => c.ClienteID == entidadId).FirstOrDefault();
            return ClienteSeleccionado;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

    }
}
