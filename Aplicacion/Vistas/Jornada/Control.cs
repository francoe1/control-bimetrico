using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Entity;
using System;
using System.Linq;

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
            Formulario form = new Formulario();
            form.Datos = Program.DbContext.Jornadas.Where(x => x.Id == id).Single();
            if (form.ShowDialog() == DialogResult.Yes)
            {
                Program.DbContext.SaveChanges();
                ActualizarTable();
            }
        }

        private void OnNuevo()
        {
            Formulario form = new Formulario();
            form.Datos = new Datos.Jornada();
            if(form.ShowDialog() == DialogResult.Yes)
            {
                Program.DbContext.Jornadas.Add(form.Datos);
                Program.DbContext.SaveChanges();
                ActualizarTable();
            }
        }

        public async void ActualizarTable()
        {
            _table.Rows.Clear();
            _table.Rows.Add("Cargando datos ...");
            List<Datos.Jornada> jornadas = await Program.DbContext.Jornadas.ToListAsync();
            _table.Rows.Clear();
            jornadas.ForEach(x => _table.Rows.Add(
                x.Id,
                x.Nombre,
                x.Lunes + x.Martes + x.Miercoles + x.Jueves + x.Viernes + x.Sabado + x.Domingo
            ));
        }
    }
}
