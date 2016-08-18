using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_0070_Binding
{
    /// <summary>
    /// Page013_MultiBinding.xaml 的交互逻辑
    /// </summary>
    public partial class Page013_MultiBinding : Page
    {
        public Page013_MultiBinding()
        {
            InitializeComponent();


            SetMultiBinding();
        }



        private void SetMultiBinding()
        {
            // 准备基础 Binding.
            Binding b1 = new Binding("Text") { Source = this.txtName1 };
            Binding b2 = new Binding("Text") { Source = this.txtName2 };


            Binding b3 = new Binding("Text") { Source = this.txtEmail1 };
            Binding b4 = new Binding("Text") { Source = this.txtEmail2 };

            // 准备 MultiBinding
            MultiBinding mb = new MultiBinding() { Mode = BindingMode.OneWay };

            // 注意： 顺序很重要.
            mb.Bindings.Add(b1);
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);

            mb.Converter = new  LogonMultiBindingConverter();

            // 按钮 与 MultiBinding 关联.
            this.btnSubmit.SetBinding(Button.IsEnabledProperty, mb);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK!");
        }
    }




    public class LogonMultiBindingConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            // 注意： 这里需要根据  前面 的 依次加入的顺序， 来判断数据.
            if(!values.Cast<string>().Any(text => string.IsNullOrEmpty(text))
                && values[0].ToString() == values[1].ToString()
                && values[2].ToString() == values[3].ToString())
            {
                return true;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
