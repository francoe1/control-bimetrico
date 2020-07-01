using System;
using System.Collections.Generic;

namespace Aplicacion.Tools
{
    public class Debug
    {
        private List<string> m_lastLogs { get; set; } = new List<string>();


        public void Log(string msg)
        {
            if (m_lastLogs.Count > 30)
                m_lastLogs.RemoveAt(0);
            m_lastLogs.Add(msg);
            Console.WriteLine(msg);
        }

        public string[] GetLogs()
        {
            return m_lastLogs.ToArray();
        }
    }
}
