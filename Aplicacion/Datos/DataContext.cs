using System.Data.Entity;

namespace Aplicacion.Datos
{
    public class DataContext : DbContext
    {                                             
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }

        public DataContext() : base("name=Default") { }
    }
}
