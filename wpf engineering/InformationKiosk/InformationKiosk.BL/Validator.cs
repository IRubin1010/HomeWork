using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.BL
{
    public class Validator
    {
        public bool ValidateEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidatePasswordLength(string password)
        {
            return password.Length >= 6;
        }
    }
}
