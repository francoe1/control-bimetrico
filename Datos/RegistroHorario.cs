using System;

namespace AppData
{
    public class RegistroHorario : DbEntity
    {
        public int EmpladoId { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public Enums.ERegistroEstado Estado { get; set; }
    }
}
