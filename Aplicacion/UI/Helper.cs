using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.UI
{
    public static class Helper
    {
        public static bool IsEmail(this TextBox txt)
        {
            try
            {
                MailAddress address = new MailAddress(txt.Text);
                return address.Address == txt.Text;
            }
            catch
            {
                return false;
            }
        }
    }
}
