using System.Windows.Forms;

namespace Aplicacion.Vistas
{
    public partial class Consola : Form
    {
        public Consola()
        {
            InitializeComponent();
            Program.EventUpdate += OnUpdate;
        }

        private void OnUpdate()
        {
            _txtLog.Lines = Program.Debug.GetLog(100);
        }
    }
}
