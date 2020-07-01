using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Aplicacion.Vistas.RegistroHorario
{
    public partial class Control : UserControl
    {
        private Datos.Empleado _datos { get; set; }
        public Datos.Empleado Datos
        {
            get
            {
                return _datos;
            }
            set
            {
                _datos = value;
                UpdateTable();
            }
        }

        public Control()
        {
            InitializeComponent();
            _table.CellMouseDoubleClick += OnEdicion;
            _btnActualizar.Click += (o, e) => UpdateTable();
            _btnNuevo.Click += (o, e) => OnNuevo();
        }

        private void OnNuevo()
        {
            Formulario form = new Formulario
            {
                Datos = new Datos.RegistroHorario()
            };
            if (form.ShowDialog() == DialogResult.Yes)
            {
                Datos.Empleado empleado = Program.DbContext.Empleado.FindById(Datos.Id);
                form.Datos.EmpladoId = empleado.Id;
                Program.DbContext.RegistroHorarios.Insert(form.Datos);
                UpdateTable();
            }
        }

        private void OnEdicion(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            int id = (int)_table.Rows[e.RowIndex].Cells[0].Value;
            Formulario form = new Formulario
            {
                Datos = Program.DbContext.RegistroHorarios.FindById(id)
            };
            if (form.ShowDialog() == DialogResult.Yes)
            {
                Program.DbContext.RegistroHorarios.Update(form.Datos);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            _table.Rows.Clear();

            foreach (var registro in Program.DbContext
                .RegistroHorarios
                .Find(x => x.EmpladoId == Datos.Id)
                .Take(Program.Conf.MaxRegistros)
                .OrderByDescending(x => x.Entrada))
            {
                double minutes = 0;
                if (registro.Salida != null && registro.Entrada != null)
                    minutes = Math.Round((registro.Salida - registro.Entrada).Value.TotalMinutes, 2);

                _table.Rows.Add(registro.Id, registro.Entrada, registro.Salida, minutes, registro.Estado);
            }
        }
    }
}
