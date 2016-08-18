using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Data;

namespace WPF_0110_Template.Converter
{
    public class L2BConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int textLength = (int)value;
            return textLength > 6 ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
