using System;

namespace Aplicacion.Datos
{
    public class RegistroHorario
    {
        public int Id { get; set; }
        public int EmpladoId { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public Enums.ERegistroEstado Estado { get; set; }
    }
}
