using System;
using app.infraestructura.datos.contexto;

namespace app.infraestructura.datos
{
    class Program
    {
        static void Main(string[] args)
    {
        Console.WriteLine("Creando la base de datos, si no existe");
        Console.WriteLine("Cargando...");

        using (AppDbContext db = new AppDbContext())
        {
            db.Database.EnsureCreated();
        }

        Console.WriteLine("Procesado exitosamente!!!!!");
        Console.ReadKey();
    }
}
}
