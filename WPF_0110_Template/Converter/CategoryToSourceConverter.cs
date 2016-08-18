using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Data;


namespace WPF_0110_Template.Converter
{

    /// <summary>
    /// 数据转换.
    /// </summary>
    public class CategoryToSourceConverter :IValueConverter
    {

        /// <summary>
        /// 将  Category  转换为 Uri.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Category c = (Category)value;
            switch (c)
            {
                case Category.Bomber:
                    return @"\Icons\tie_bomber.png";
                case Category.Fighter:
                    return @"\Icons\tie_fighter.png";
                default :
                    return null;
            }
        }



        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
