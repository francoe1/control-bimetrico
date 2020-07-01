using System.Collections.Generic;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Jornada
{
    public partial class Control : UserControl
    {
        public Control()
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
            Formulario form = new Formulario
            {
                Datos = Program.DbContext.Jornadas.FindById(id)
            };
            if (form.ShowDialog() == DialogResult.Yes)
            {
                Program.DbContext.Jornadas.Update(form.Datos);
                ActualizarTable();
            }
        }

        private void OnNuevo()
        {
            Formulario form = new Formulario
            {
                Datos = new Datos.Jornada()
            };
            if (form.ShowDialog() == DialogResult.Yes)
            {
                Program.DbContext.Jornadas.Insert(form.Datos);
                ActualizarTable();
            }
        }

        public void ActualizarTable()
        {
            _table.Rows.Clear();
            _table.Rows.Add("Cargando datos ...");
            IEnumerable<Datos.Jornada> jornadas = Program.DbContext.Jornadas.FindAll();
            _table.Rows.Clear();

            foreach (Datos.Jornada x in jornadas)
                _table.Rows.Add(x.Id, x.Nombre,
                    x.Lunes + x.Martes + x.Miercoles + x.Jueves + x.Viernes + x.Sabado + x.Domingo);
        }
    }
}
