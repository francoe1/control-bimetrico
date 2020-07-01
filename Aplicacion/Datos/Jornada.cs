using System;

namespace Aplicacion.Datos
{
    public class Jornada
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Lunes { get; set; }
        public decimal Martes { get; set; }
        public decimal Miercoles { get; set; }
        public decimal Jueves { get; set; }
        public decimal Viernes { get; set; }
        public decimal Sabado { get; set; }
        public decimal Domingo { get; set; }
        public decimal PrecioNormal { get; set; }
        public decimal PrecioExtra { get; set; }


        public double GetHoras(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Monday)
                return (double)Lunes;
            if (dayOfWeek == DayOfWeek.Tuesday)
                return (double)Martes;
            if (dayOfWeek == DayOfWeek.Wednesday)
                return (double)Miercoles;
            if (dayOfWeek == DayOfWeek.Thursday)
                return (double)Jueves;
            if (dayOfWeek == DayOfWeek.Friday)
                return (double)Viernes;
            if (dayOfWeek == DayOfWeek.Saturday)
                return (double)Sabado;
            if (dayOfWeek == DayOfWeek.Sunday)
                return (double)Domingo;

            return 0;


        }
    }
}
