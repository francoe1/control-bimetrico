using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Vistas.RegistroHorario
{
    public partial class Formulario : Form
    {
        private Datos.RegistroHorario _datos { get; set;}
        public Datos.RegistroHorario Datos
        {
            get
            {
                return _datos;
            }
            set
            {
                _datos = value;
                _cbxEstado.DataSource = Enum.GetNames(typeof(Datos.Enums.ERegistroEstado));
                _cbxEstado.SelectedIndex = (int)_datos.Estado;

                if(_datos.Entrada != null)
                    _dtpEntrada.Value = (DateTime)_datos.Entrada;

                if(_datos.Salida != null)
                    _dtpSalida.Value = (DateTime)_datos.Salida;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Formulario()
        {
            InitializeComponent();
            _btnGuardar.Click += (o, e) => OnGuardar();
            _btnCancelar.Click += (o, e) => OnCancelar();
        }

        private void OnCancelar()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnGuardar()
        {
            _datos.Entrada = _dtpEntrada.Value;
            _datos.Salida = _dtpSalida.Value;
            _datos.Estado = (Datos.Enums.ERegistroEstado)_cbxEstado.SelectedIndex;
            DialogResult = DialogResult.Yes;
        }
    }
}
