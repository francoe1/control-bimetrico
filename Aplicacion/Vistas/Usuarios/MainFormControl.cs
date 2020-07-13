using AppData;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Usuarios
{
    public partial class MainFormControl : UserControl
    {
        public MainFormControl()
        {
            InitializeComponent();
            _btnNuevo.Click += (o, e) => OnNuevo();
            _btnActualizar.Click += (o, e) => UpdateTable();
            _btnEliminar.Click += (o, e) => OnEliminar();

            _table.CellMouseDoubleClick += (o, e) =>
            {
                if (e.RowIndex == -1) return;

                FormularioForm form = new FormularioForm();
                int id = (int)_table.Rows[e.RowIndex].Cells[0].Value;
                form.Datos = DataContext.Current.Usuarios.FindById(id);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    DataContext.Current.Usuarios.Update(form.Datos);
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
                DataContext.Current.Usuarios.Delete(id);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            _table.Rows.Clear();

            foreach (Usuario usuario in DataContext.Current.Usuarios.FindAll())
                _table.Rows.Add(usuario.Id, usuario.Nombre, usuario.Email, usuario.Clave);
        }

        private void OnNuevo()
        {
            FormularioForm form = new FormularioForm
            {
                Datos = new Usuario()
            };
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                DataContext.Current.Usuarios.Insert(form.Datos);
                UpdateTable();
            }
        }
    }
}
