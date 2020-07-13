using Aplicacion.Vistas.RegistroHorario;
using AppData;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Empleado
{
    public partial class MainFormControl : UserControl
    {
        public MainFormControl()
        {
            InitializeComponent();
            _btnNuevo.Click += (o, e) => OnNuevo();
            _btnActualizar.Click += (o, e) => UpdateTable();
            _btnRegistros.Click += (o, e) => OnRegisters();
            _btnEliminar.Click += (o, e) => OnEliminar();
            _table.CellMouseDoubleClick += OnSeleccionEmpleado;
            UpdateTable();
        }

        private void OnEliminar()
        {
            if (_table.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            if (MessageBox.Show("Estas seguro de eliminar el empleado selecionado, esta acción no se puede deshacer"
                , "Eliminar empleado",
                MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                int id = (int)_table.SelectedRows[0].Cells[0].Value;
                DataContext.Current.Empleado.Delete(id);
                //Program.DbContext.SaveChanges();
                UpdateTable();
            }
        }

        private void OnRegisters()
        {
            if (_table.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            int id = (int)_table.SelectedRows[0].Cells[0].Value;
            AppData.Empleado empleado = DataContext.Current.Empleado.FindById(id);
            Program.InicioForm.MainMenu.SwithTo("RegistroHorario");
            Program.InicioForm.MainMenu.SetTitleText($"{empleado.Nombre} {empleado.Apellido} > Registros");
            Program.InicioForm.RegistroHorarioControl.Datos = empleado;
        }

        private void OnSeleccionEmpleado(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int id = (int)_table.Rows[e.RowIndex].Cells[0].Value;
            FormularioForm form = new FormularioForm
            {
                Datos = DataContext.Current.Empleado.FindById(id)
            };

            if (form.ShowDialog() == DialogResult.Yes)
            {
                DataContext.Current.Empleado.Update(form.Datos);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            int currentSelect = (_table.SelectedRows.Count > 0) ? _table.SelectedRows[0].Index : 0;
            _table.Rows.Clear();

            foreach (AppData.Empleado x in DataContext.Current.Empleado.FindAll())
                _table.Rows.Add(x.Id, x.Nombre, x.Apellido, x.Documento, x.Direccion, x.Telefono, x.Email);

            _table.ClearSelection();
            if (_table.Rows.Count > currentSelect)
                _table.Rows[currentSelect].Selected = true;
        }

        private void OnNuevo()
        {
            FormularioForm form = new FormularioForm
            {
                Datos = new AppData.Empleado()
            };
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                DataContext.Current.Empleado.Insert(form.Datos);
                UpdateTable();
            }
        }
    }
}
