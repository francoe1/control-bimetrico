using Aplicacion.Datos;
using System.Windows.Forms;

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
                form.Datos = Program.DbContext.Usuarios.FindById(id);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    Program.DbContext.Usuarios.Update(form.Datos);
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
                Program.DbContext.Usuarios.Delete(id);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            _table.Rows.Clear();

            foreach (Usuario usuario in Program.DbContext.Usuarios.FindAll())
                _table.Rows.Add(usuario.Id, usuario.Nombre, usuario.Email, usuario.Clave);
        }

        private void OnNuevo()
        {
            Formulario form = new Formulario
            {
                Datos = new Usuario()
            };
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                Program.DbContext.Usuarios.Insert(form.Datos);
                UpdateTable();
            }
        }
    }
}
