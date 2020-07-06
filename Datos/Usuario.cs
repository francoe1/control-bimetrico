namespace AppData
{
    public class Usuario : DbEntity
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
