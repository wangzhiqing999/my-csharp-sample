using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Data;

namespace WPF_0070_Binding.Converter
{
    public class StateToNullableBoolConverter : IValueConverter
    {

        /// <summary>
        /// State 转换为 bool?
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            State s = (State)value;
            switch (s)
            {
                case State.Locked:
                    return false;
                case State.Available:
                    return true;
                case State.Unknown:
                default:
                    return null;
            }
        }


        /// <summary>
        /// bool? 转换为 State
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? nb = (bool?)value;
            switch (nb)
            {
                case true:
                    return State.Available;
                case false :
                    return State.Locked;
                case null:
                default:
                    return State.Unknown;
            }
        }
    }
}
