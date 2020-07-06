namespace AppData
{
    public class DatosBiometrico : DbEntity
    {
        public int EmpladoId { get; set; }
        public byte[] Data { get; set; }
        public bool ManoDerecha { get; set; }
        public Enums.EDedo Dedo { get; set; }
    }
}
