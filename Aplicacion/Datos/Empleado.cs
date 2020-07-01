using System.Collections.Generic;

namespace Aplicacion.Datos
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }  
        public Jornada Jornada { get; set; }                                                       
        public List<DatosBiometrico> DatosBiometricos { get; set; }
        public List<RegistroHorario> RegistrosHorario { get; set; }

        public string DisplayMember { get { return ToString(); } }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
