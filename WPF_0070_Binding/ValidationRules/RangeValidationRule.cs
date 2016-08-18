using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Controls;

namespace WPF_0070_Binding.ValidationRules
{


    public class RangeValidationRule : ValidationRule
    {
        int min;
        public int Min
        {
            get { return min; }
            set { min = value; }
        }

        int max;
        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int number;
            if (!int.TryParse((string)value, out number))
            {
                return new ValidationResult(false, "Invalid number format");
            }

            if (number < min || number > max)
            {
                return new ValidationResult(false, string.Format("Number out of range ({0} - {1})", min, max));
            }

            return ValidationResult.ValidResult;
        }

    }
}
