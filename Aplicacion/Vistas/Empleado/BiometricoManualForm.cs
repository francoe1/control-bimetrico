using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Empleado
{
    public partial class BiometricoManualForm : Form
    {
        public byte[] Bytes { get; private set; }
        public Image Image { get; private set; }

        public BiometricoManualForm()
        {
            InitializeComponent();
        }

        private void m_btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Bytes = Encoding.ASCII.GetBytes(m_txtBytes.Text);
            Image = GetImage(Bytes);
            Close();
        }

        private Image GetImage(byte[] byteArrayIn)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length))
                {
                    ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                    return Image.FromStream(ms, true);
                }
            }
            catch { }
            return default;
        }
    }
}
