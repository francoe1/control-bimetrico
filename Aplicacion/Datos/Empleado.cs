namespace Aplicacion.Datos
{
    public class Empleado
    {
        public int Id { get; set; }
        public int JornadaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DisplayMember { get { return ToString(); } }

        public Jornada Jornada
        {
            get { return Program.DbContext.Jornadas.FindById(JornadaId); }
            set { JornadaId = (value is null) ? -1 : value.Id; }
        }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
