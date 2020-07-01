using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;
using FastReporter;
using FastReporter.Minimalist;
using Aplicacion.Datos;

namespace Aplicacion.Vistas.Reportes
{
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
            button1.Click += (o, e) => OnReporteGeneral();
            for (int i = 0; i < _chlFiltros.Items.Count; i++)
                _chlFiltros.SetItemChecked(i, true);
            
            _cbxEmpleados.DataSource = Program.DbContext.Empleado.ToList();
            _cbxEmpleados.ValueMember = "Id";
            _cbxEmpleados.DisplayMember = "DisplayMember";
            
            _chbTodos.CheckedChanged += (o, e) =>
            {
                _cbxEmpleados.Enabled = !_chbTodos.Checked;
            };

            _cbxEmpleados.Enabled = !_chbTodos.Checked;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if(Visible)
            {
                _dtpInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                _dtpEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                _dtpEnd.Value = _dtpEnd.Value.AddHours(23);
            }
        }

        private void _OnReporteGeneral()
        {
            HtmlPage page = new HtmlPage("Reporte General");
            page.SetStyle("padding:10px");
            page.Append(new HtmlItem(HtmlTag.h5, "Reportes general de usuarios"));

            List<Datos.Empleado> data = Program.DbContext
               .Empleado
               .Include(x => x.RegistrosHorario)
               .Include(x => x.Jornada)
               .ToList();

            foreach(Datos.Empleado empleado in data)
            {
                page.Append(new HtmlItem(HtmlTag.h1, empleado.Nombre));                

                foreach(Datos.RegistroHorario registro in empleado.RegistrosHorario)
                {
                    if (!registro.Salida.HasValue || !registro.Entrada.HasValue)
                        continue;

                    TimeSpan time = registro.Salida.Value - registro.Entrada.Value;
                    page.Append(new HtmlItem(HtmlTag.p, registro.Entrada + "/" + registro.Salida + "(" + ParseTimeSpan(time) + ")"));

                }
            }

            page.Visualize();
        }

        private void OnReporteGeneral()
        {
            HtmlPage page = new HtmlPage("Reporte General");
            page.SetStyle("padding:10px");
            page.Append(new HtmlItem(HtmlTag.h5, "Reportes general de usuarios"));

            foreach (Datos.Empleado empleado in Program.DbContext
                .Empleado
                .Include(x => x.RegistrosHorario)
                .Include(x => x.Jornada)
                .Where(x => x.Id == (!_chbTodos.Checked? (int)_cbxEmpleados.SelectedValue : x.Id))
                .ToList())
            {
                page.Append(new HtmlItem(HtmlTag.h3, empleado.Nombre + " " + empleado.Apellido));
                if (empleado.Jornada != null)
                {
                    DateTime start = _dtpInicio.Value.Date;
                    DateTime end = _dtpEnd.Value.Date.AddDays(1);
                    page.Append(HtmlRegistroHorario(empleado
                        .RegistrosHorario
                        .Where(x => x.Entrada > start && x.Salida < end)
                        .ToList(),
                        empleado.Jornada));
                }
                else
                {
                    page.Append(new HtmlItem(HtmlTag.h1, "Empleado no tiene una jornada Asignada"));
                }
                page.Append(new HtmlItem(HtmlTag.hr));             
            }
            page.Visualize();
        }

        private HtmlObject HtmlRegistroHorario(List<Datos.RegistroHorario> registros, Datos.Jornada jordana)
        {
            HtmlPage page = new HtmlPage("-");
            HtmlTable table = new HtmlTable("table-striped", "Fecha", "Registros", "H. Trabajadas", "H. Extras");
            double ganancias = 0;
            TimeSpan totalHours = new TimeSpan();
            TimeSpan totalHoursExtas = new TimeSpan();
            int dias = 0;

            foreach (var group in registros.Where(x =>
                    x.Entrada != null
                    && x.Salida != null
                    && x.Estado == Datos.Enums.ERegistroEstado.Cerrado)
                   .GroupBy(x => x.Entrada.Value.Date))
            {
                TimeSpan hours = new TimeSpan();
                dias++;
                DateTime date = DateTime.Now;
                foreach (var item in group)
                {
                    date = item.Entrada.Value.Date;
                    hours += (item.Salida.Value - item.Entrada.Value);
                }

                TimeSpan horasExtras = hours - new TimeSpan((int)jordana.GetHoras(date.DayOfWeek), 0, 0);
                totalHours += hours;

                table.AddRow(
                    date.ToShortDateString(), 
                    group.Count(),
                    ParseTimeSpan(hours) + "/"+ jordana.GetHoras(date.DayOfWeek),
                    ParseTimeSpan(horasExtras));

                if(horasExtras.TotalSeconds > 0)
                {
                    hours -= horasExtras;
                    ganancias += hours.TotalHours * (double)jordana.PrecioNormal;
                    ganancias += horasExtras.TotalHours * (double)jordana.PrecioExtra;
                    totalHoursExtas += horasExtras;
                }
            }

            if(_chlFiltros.GetItemChecked(0))
                page.Append(new HtmlInfoField { Text = "Total horas normal", Value = ParseTimeSpanHours(totalHours)});
            if (_chlFiltros.GetItemChecked(1))
                page.Append(new HtmlInfoField { Text = "Total horas extras", Value = ParseTimeSpanHours(totalHoursExtas) });
            if (_chlFiltros.GetItemChecked(2))
                page.Append(new HtmlInfoField { Text = "Ganancias", Value = "$" + Math.Round(ganancias, 2) });
            if (_chlFiltros.GetItemChecked(3))
            {
                page.Append(new HtmlInfoField { Text = "Jornada", Value = jordana.Nombre });
                page.Append(new HtmlInfoField { Text = "Valor x Hora Normal", Value = "$" + jordana.PrecioNormal });
                page.Append(new HtmlInfoField { Text = "Valor x Hora Extra", Value = "$" + jordana.PrecioExtra });
            }
            if (_chlFiltros.GetItemChecked(4))
                page.Append(new HtmlInfoField { Text = "Dias Trabajados", Value = dias });

            if(_chbRegistros.Checked)
                page.Append(table);
            return page;
        }        

        private string ParseTimeSpan(TimeSpan time)
        {
            string result = "";
            result += $"{((int)time.TotalHours).ToString("D2")}:{time.Minutes.ToString("D2")}:{time.Seconds.ToString("D2")}";
            return result;
        }

        private string ParseTimeSpanHours(TimeSpan time)
        {
            return $"{(int)time.TotalHours}:{time.Minutes.ToString("D2")}";
        }
    }
}
