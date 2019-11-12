using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InformationKiosk.PL.Validation
{
    public class IsUriValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return !string.IsNullOrWhiteSpace((value ?? "").ToString()) && !isValidUri(value.ToString())
           ? new ValidationResult(false, "Field must be in valid URI format.")
           : ValidationResult.ValidResult;
        }

        private bool isValidUri(string uri)
        {
            return Uri.TryCreate(uri, UriKind.Absolute, out var uriResult);
        }
    }
}
