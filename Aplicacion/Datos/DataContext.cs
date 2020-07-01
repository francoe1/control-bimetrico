using LiteDB;
using System.IO;

namespace Aplicacion.Datos
{
    public class DataContext
    {
        private LiteDatabase m_ddbb { get; set; }

        public ILiteCollection<Usuario> Usuarios => m_ddbb.GetCollection<Usuario>();
        public ILiteCollection<Empleado> Empleado => m_ddbb.GetCollection<Empleado>();
        public ILiteCollection<Jornada> Jornadas => m_ddbb.GetCollection<Jornada>();
        public ILiteCollection<RegistroHorario> RegistroHorarios => m_ddbb.GetCollection<RegistroHorario>();
        public ILiteCollection<DatosBiometrico> DatosBiometricos => m_ddbb.GetCollection<DatosBiometrico>();
        public string DataBaseLocation { get; private set; }

        public DataContext()
        {
            ConnectionString conn = BuildConnectionString("data");
            m_ddbb = new LiteDatabase(conn);
            DataBaseLocation = conn.Filename;
        }

        private static ConnectionString BuildConnectionString(string fileName)
        {
            string dir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            string filePath = Path.Combine(dir, fileName + ".db");
            return new ConnectionString() { Filename = filePath, Connection = ConnectionType.Shared };
        }
    }
}
