using AppData;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Aplicacion.Vistas.RegistroHorario
{
    public partial class Control : UserControl
    {
        private FiltroForm m_filters { get; set; } = new FiltroForm();

        private AppData.Empleado _datos { get; set; }
        public AppData.Empleado Datos
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
                Datos = new AppData.RegistroHorario { Estado = Enums.ERegistroEstado.Cerrado }
            };

            if (form.ShowDialog() == DialogResult.Yes)
            {
                AppData.Empleado empleado = DataContext.Current.Empleado.FindById(Datos.Id);
                form.Datos.EmpladoId = empleado.Id;
                DataContext.Current.RegistroHorarios.Insert(form.Datos);
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
                Datos = DataContext.Current.RegistroHorarios.FindById(id)
            };
            if (form.ShowDialog() == DialogResult.Yes)
            {
                DataContext.Current.RegistroHorarios.Update(form.Datos);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            _table.Rows.Clear();

            foreach (var registro in DataContext.Current
                .RegistroHorarios
                .Find(x => x.EmpladoId == Datos.Id && x.Entrada > m_filters.DateStart && x.Salida < m_filters.DateEnd)
                .Take(Program.Conf.MaxRegistros)
                .OrderByDescending(x => x.Entrada))
            {
                double minutes = 0;
                if (registro.Salida != null && registro.Entrada != null)
                    minutes = Math.Round((registro.Salida - registro.Entrada).Value.TotalMinutes, 2);

                _table.Rows.Add(registro.Id, registro.Entrada, registro.Salida, minutes, registro.Estado);
            }
        }

        private void m_btnFilters_Click(object sender, EventArgs e)
        {
            if (m_filters.ShowDialog() == DialogResult.OK)
            {
                UpdateTable();
            }
        }
    }
}
