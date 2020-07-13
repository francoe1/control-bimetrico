using AppData;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Jornada
{
    public partial class MainFormControl : UserControl
    {
        public MainFormControl()
        {
            InitializeComponent();
            ActualizarTable();
            _btnActualizar.Click += (o, e) => ActualizarTable();
            _btnNuevo.Click += (o, e) => OnNuevo();
            _table.CellDoubleClick += TableRowClick;
        }

        private void TableRowClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            int id = (int)_table.Rows[e.RowIndex].Cells[0].Value;
            FormularioForm form = new FormularioForm
            {
                Datos = DataContext.Current.Jornadas.FindById(id)
            };
            if (form.ShowDialog() == DialogResult.Yes)
            {
                DataContext.Current.Jornadas.Update(form.Datos);
                ActualizarTable();
            }
        }

        private void OnNuevo()
        {
            FormularioForm form = new FormularioForm
            {
                Datos = new AppData.Jornada()
            };
            if (form.ShowDialog() == DialogResult.Yes)
            {
                DataContext.Current.Jornadas.Insert(form.Datos);
                ActualizarTable();
            }
        }

        public void ActualizarTable()
        {
            _table.Rows.Clear();
            _table.Rows.Add("Cargando datos ...");
            IEnumerable<AppData.Jornada> jornadas = DataContext.Current.Jornadas.FindAll();
            _table.Rows.Clear();

            foreach (AppData.Jornada x in jornadas)
                _table.Rows.Add(x.Id, x.Nombre,
                    x.Lunes + x.Martes + x.Miercoles + x.Jueves + x.Viernes + x.Sabado + x.Domingo);
        }
    }
}
