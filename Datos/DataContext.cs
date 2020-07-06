using LiteDB;
using System.IO;

namespace AppData
{
    public class DataContext
    {
        public static DataContext Current { get; private set; } = new DataContext();

        private LiteDatabase m_ddbb { get; set; }

        public ILiteCollection<Usuario> Usuarios => GetCollection<Usuario>();
        public ILiteCollection<Empleado> Empleado => GetCollection<Empleado>();
        public ILiteCollection<Jornada> Jornadas => GetCollection<Jornada>();
        public ILiteCollection<RegistroHorario> RegistroHorarios => GetCollection<RegistroHorario>();
        public ILiteCollection<DatosBiometrico> DatosBiometricos => GetCollection<DatosBiometrico>();
        public string DataBaseLocation { get; private set; }

        public DataContext()
        {
            ConnectionString conn = BuildConnectionString("data");            
            m_ddbb = new LiteDatabase(conn);
            DataBaseLocation = conn.Filename;
            Current = this;
        }

        private ILiteCollection<T> GetCollection<T>() where T : DbEntity, new()
        {
            string name = typeof(T).FullName.Replace(".", "_");
            ILiteCollection<T> collection = m_ddbb.GetCollection<T>(name);
            if (!m_ddbb.CollectionExists(name))
            {
                T entity = new T();
                collection.Insert(entity);
                collection.Delete(entity.Id);
            }
            return collection;
        }

        private static ConnectionString BuildConnectionString(string fileName)
        {
            string dir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            string filePath = Path.Combine(dir, fileName + ".db");
            return new ConnectionString() { Filename = filePath, Connection = ConnectionType.Shared };
        }
    }

    public class DbEntity
    {
        public int Id { get; set; }
    }
}
