using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Aplicacion.UI
{
    public class Efectos
    {
        private List<Efectos> Items { get; set; } = new List<Efectos>();
        public Control UIControl { get; set; }

        private Color tmpColor { get; set; }
        public ConfigurationFX Conf { get; set; }

        public Efectos() { }

        private Efectos(Control control, ConfigurationFX conf)
        {
            UIControl = control;

            Conf = conf;
            if (Conf.ColorNormal == default)
                Conf.ColorNormal = UIControl.BackColor;

            if (UIControl is Button btn)
            {
                Conf.ColorHover = btn.FlatAppearance.MouseOverBackColor;
                Conf.ColorActivo = btn.FlatAppearance.MouseDownBackColor;
            }

            tmpColor = Conf.ColorNormal;
            UIControl.BackColor = Conf.ColorNormal;
            UIControl.MouseEnter += (o, e) => { tmpColor = Conf.ColorHover; UIControl.Invalidate(); };
            UIControl.MouseClick += (o, e) => { tmpColor = Conf.ColorActivo; UIControl.Invalidate(); };
            UIControl.MouseLeave += (o, e) => { tmpColor = Conf.ColorNormal; UIControl.Invalidate(); };
        }

        public void Update()
        {
            Items.ForEach(x => x.UpdateEffect());
        }

        public Efectos Add(Control control, ConfigurationFX conf)
        {
            Items.Add(new Efectos(control, new ConfigurationFX
            {
                ColorNormal = conf.ColorNormal,
                ColorActivo = conf.ColorActivo,
                ColorHover = conf.ColorHover,
                Transicion = conf.Transicion
            }));

            return Items.Last();
        }

        private void UpdateEffect()
        {
            UIControl.BackColor = Mathf.LerpColor(UIControl.BackColor, tmpColor, Conf.Transicion);
        }

        public class ConfigurationFX
        {
            public Color ColorNormal { get; set; }
            public Color ColorActivo { get; set; }
            public Color ColorHover { get; set; }
            public int Transicion { get; set; }
        }
    }
}
