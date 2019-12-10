using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InformationKiosk.PL.Validation
{
    public class PhonrNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return !string.IsNullOrWhiteSpace((value ?? "").ToString()) && !isPhoneNumber(value.ToString())
           ? new ValidationResult(false, "Value must be an Israli PhoneNumber.")
           : ValidationResult.ValidResult;
        }

        private bool isPhoneNumber(string phoneNumber)
        {
            return phoneNumber.StartsWith("+972") && phoneNumber.Length == 13;
        }
    }
}
