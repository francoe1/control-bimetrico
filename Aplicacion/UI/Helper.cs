using System.Net.Mail;
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
