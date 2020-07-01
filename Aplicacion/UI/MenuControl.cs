using System.Collections.Generic;
using System.Windows.Forms;

namespace Aplicacion.UI
{
    public class MenuControl
    {
        private Dictionary<string, Button> _buttons { get; set; } = new Dictionary<string, Button>();
        private Dictionary<string, UserControl> _controls { get; set; } = new Dictionary<string, UserControl>();
        private Panel _panel { get; set; }
        private Label _titleLabel { get; set; }
        private string _titleStartText { get; set; }

        public MenuControl(Panel panel)
        {
            _panel = panel;
        }

        public void SetTitleLabel(Label label)
        {
            _titleLabel = label;
            _titleStartText = label.Text + " ";
        }

        public void SetTitleText(string value, bool userStartText = true)
        {
            if (_titleLabel != null)
                _titleLabel.Text = _titleStartText + value.ToUpper();
        }

        public void Link(string name, UserControl control)
        {
            _controls.Add(name, control);
            _panel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BackColor = _panel.BackColor;
        }

        public void Link(string name, Button btn, UserControl control)
        {
            _buttons.Add(name, btn);
            _controls.Add(name, control);
            _panel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BackColor = _panel.BackColor;
            btn.Click += (o, e) => SwithTo(name);
        }

        public void DisableButton(string name)
        {
            if (_buttons.ContainsKey(name))
                _buttons[name].Hide();
        }

        public void HideAll()
        {
            foreach (string name in _controls.Keys)
                HideControl(name);
        }

        public void HideControl(string name)
        {
            if (_controls[name].Visible) 
                Program.Debug.Log(ELogType.Info, "Ocultando " + name);
            _controls[name].Visible = false;
        }

        public void SwithTo(string name)
        {
            HideAll();
            _controls[name].Visible = true;
            Program.Debug.Log(ELogType.Info, "Cambiar a " + name);

            if (_titleLabel != null)
                _titleLabel.Text = _titleStartText + name.ToUpper();
        }
    }
}
