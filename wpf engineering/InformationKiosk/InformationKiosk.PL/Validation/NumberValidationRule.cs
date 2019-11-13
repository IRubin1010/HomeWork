using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InformationKiosk.PL.Validation
{
    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = value?.ToString();
            if (!Int32.TryParse(s, out var number))
            {
                return new ValidationResult(false, "Value must be an integer.");
            }
            if (number <= 0)
            {
                return new ValidationResult(false, "Value must be greater than 0.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
