using System;
using System.Windows.Forms;

namespace Aplicacion.Vistas.RegistroHorario
{
    public partial class FiltroForm : Form
    {
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }

        public FiltroForm()
        {
            InitializeComponent();
            m_dateStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            m_dateEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
            DateStart = m_dateStart.Value;
            DateEnd = m_dateEnd.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateStart = m_dateStart.Value;
            DateEnd = m_dateEnd.Value;
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
