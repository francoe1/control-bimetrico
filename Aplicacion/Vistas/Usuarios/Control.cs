using Aplicacion.Datos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Aplicacion.Vistas.Usuarios
{
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
            _btnNuevo.Click += (o, e) => OnNuevo();
            _btnActualizar.Click += (o, e) => UpdateTable();
            _btnEliminar.Click += (o, e) => OnEliminar();

            _table.CellMouseDoubleClick += (o, e) =>
            {
                if (e.RowIndex == -1) return;

                Formulario form = new Formulario();
                int id = (int)_table.Rows[e.RowIndex].Cells[0].Value;
                form.Datos = Program.DbContext.Usuarios.Where(x => x.Id == id).Single();
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    Program.DbContext.SaveChanges();
                    UpdateTable();
                }
            };
            UpdateTable();
        }

        private void OnEliminar()
        {
            if (_table.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            if (MessageBox.Show("Estas seguro de eliminar el usuario selecionado, esta acción no se puede deshacer"
                , "Eliminar usuario",
                MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                int id = (int)_table.SelectedRows[0].Cells[0].Value;
                Program.DbContext.Usuarios.Remove(Program.DbContext.Usuarios
                    .Where(x => x.Id == id)
                    .Single());
                Program.DbContext.SaveChanges();
                UpdateTable();
            }
        }

        private async void UpdateTable()
        {
            _table.Rows.Clear();
            using (DataContext context = new DataContext())
            {
                List<Usuario> datos = await context.Usuarios.ToListAsync();                
                datos.ForEach(x => _table.Rows.Add(x.Id, x.Nombre, x.Email, x.Clave));
            }
        }

        private void OnNuevo()
        {
            Formulario form = new Formulario();
            form.Datos = new Datos.Usuario();
            if(form.ShowDialog() != DialogResult.Cancel)
            {
                Program.DbContext.Usuarios.Add(form.Datos);
                Program.DbContext.SaveChanges();
                UpdateTable();
            }
        }
    }
}
