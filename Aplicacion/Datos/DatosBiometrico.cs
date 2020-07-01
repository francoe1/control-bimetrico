namespace Aplicacion.Datos
{
    public class DatosBiometrico
    {
        public int Id { get; set; }
        public int EmpladoId { get; set; }
        public byte[] Data { get; set; }
        public bool ManoDerecha { get; set; }
        public Enums.EDedo Dedo { get; set; }
    }
}
