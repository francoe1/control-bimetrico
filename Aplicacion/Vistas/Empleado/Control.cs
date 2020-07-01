using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Entity;
using Aplicacion.Datos;
using System;
using System.Linq;

namespace Aplicacion.Vistas.Empleado
{
    public partial class Control : UserControl
    {         
        public Control()
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

            if(MessageBox.Show("Estas seguro de eliminar el empleado selecionado, esta acción no se puede deshacer"
                , "Eliminar empleado",
                MessageBoxButtons.YesNo) 
                == DialogResult.Yes)
            {
                int id = (int)_table.SelectedRows[0].Cells[0].Value;
                Program.DbContext.Empleado.Remove(Program.DbContext.Empleado
                    .Where(x => x.Id == id)
                    .Include(x => x.RegistrosHorario)
                    .Include(x => x.DatosBiometricos)
                    .Single());
                Program.DbContext.SaveChanges();
                UpdateTable();
            }           
        }

        private void OnRegisters()
        {
            if(_table.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            int id = (int)_table.SelectedRows[0].Cells[0].Value;
            Datos.Empleado empleado = Program.DbContext.Empleado.Where(x => x.Id == id).Single();
            Program.InicioForm.MainMenu.SwithTo("RegistroHorario");
            Program.InicioForm.MainMenu.SetTitleText($"{empleado.Nombre} {empleado.Apellido} > Registros");
            Program.InicioForm.RegistroHorarioControl.Datos = empleado;
        }

        private void OnSeleccionEmpleado(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int id = (int)_table.Rows[e.RowIndex].Cells[0].Value;
            Formulario form = new Formulario();
            form.Datos = Program.DbContext.Empleado
                .Where(x => x.Id == id)
                .Include(x => x.Jornada)
                .Include(x => x.DatosBiometricos).Single();

            if(form.ShowDialog() == DialogResult.Yes)
            {
                Program.DbContext.SaveChanges();
                UpdateTable();
            }            
        }

        private async void UpdateTable()
        {
            int currentSelect = (_table.SelectedRows.Count > 0) ? _table.SelectedRows[0].Index : 0;
            _table.Rows.Clear();
            using (DataContext context = new DataContext())
            {
                List<Datos.Empleado> datos = await context.Empleado.ToListAsync();
                datos.ForEach(x => _table.Rows.Add(
                    x.Id,
                    x.Nombre,
                    x.Apellido,
                    x.Documento,
                    x.Direccion,
                    x.Telefono,
                    x.Email));
            }

            _table.ClearSelection();
            if (_table.Rows.Count > currentSelect)
                _table.Rows[currentSelect].Selected = true;
        }

        private void OnNuevo()
        {
            Formulario form = new Formulario();
            form.Datos = new Datos.Empleado();
            if(form.ShowDialog() != DialogResult.Cancel)
            {
                Program.DbContext.Empleado.Add(form.Datos);
                Program.DbContext.SaveChanges();
                UpdateTable();
            }
        }
    }
}
