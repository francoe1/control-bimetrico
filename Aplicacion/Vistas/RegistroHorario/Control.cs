using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

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
            Formulario form = new Formulario();
            form.Datos = new Aplicacion.Datos.RegistroHorario();
            if (form.ShowDialog() == DialogResult.Yes)
            {
                Datos.Empleado empleado = Program.DbContext.Empleado
                    .Where(x => x.Id == Datos.Id)
                    .Single();                
                empleado.RegistrosHorario.Add(form.Datos);
                Program.DbContext.SaveChanges();

                UpdateTable();
            }
        }

        private void OnEdicion(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            int id = (int)_table.Rows[e.RowIndex].Cells[0].Value;
            Datos.RegistroHorario reg = Program.DbContext.Empleado.Where(x => x.Id == Datos.Id)
                .Include(x => x.RegistrosHorario)
                .Single()
                .RegistrosHorario
                .Where(x => x.Id == id)
                .Single();

            Formulario form = new Formulario();
            form.Datos = reg;
            if(form.ShowDialog() == DialogResult.Yes)
            {
                Program.DbContext.SaveChanges();
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            _table.Rows.Clear();

            Program.DbContext.Empleado
            .Where(x => x.Id == _datos.Id)
            .Include(x => x.RegistrosHorario)
            .ToList()
            .Single()
            .RegistrosHorario
            .Take(Program.Conf.MaxRegistros)
            .ToList()
            .ForEach(x =>
            {
                double minutes = 0;
                if (x.Salida != null && x.Entrada != null)
                    minutes = Math.Round((x.Salida - x.Entrada).Value.TotalMinutes, 2);

                _table.Rows.Add(x.Id, x.Entrada, x.Salida, minutes, x.Estado);
            });
        }
    }
}
