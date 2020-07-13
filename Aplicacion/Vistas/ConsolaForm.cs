using System.Windows.Forms;

namespace Aplicacion.Vistas
{
    public partial class ConsolaForm : Form
    {
        public ConsolaForm()
        {
            InitializeComponent();
            Program.UpdateEvent += OnUpdate;
        }

        private void OnUpdate()
        {
            _txtLog.Lines = Program.Debug.GetLogs();
        }
    }
}
