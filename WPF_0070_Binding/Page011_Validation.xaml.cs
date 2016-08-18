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


using WPF_0070_Binding.ValidationRules;


namespace WPF_0070_Binding
{
    /// <summary>
    /// Page011_Validation.xaml 的交互逻辑
    /// </summary>
    public partial class Page011_Validation : Page
    {
        public Page011_Validation()
        {
            InitializeComponent();



            Binding binding = new Binding("Value") { Source = this.sliTest };
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            RangeValidationRule rvr = new RangeValidationRule()
            {
                Min= 0,
                Max = 100
            };


            // Binding 只在 Target 被外部方法更新是 校验数据，而自身 Binding 的 Source 数据更新 Target 时是不进行校验的。
            // 如果要改变这种行为， 需要增加下面 ValidatesOnTargetUpdated = true 的处理。
            rvr.ValidatesOnTargetUpdated = true;


            binding.ValidationRules.Add(rvr);






            // 默认情况下， 数据错误时，仅仅是 输入框 边框线变红色。
            // 如果要求有 自定义的 错误显示方式. 需要自己定义一个事件处理.
            binding.NotifyOnValidationError = true;


            this.txtTest.SetBinding(TextBox.TextProperty, binding);



            // 默认情况下， 数据错误时，仅仅是 输入框 边框线变红色。
            // 如果要求有 自定义的 错误显示方式. 需要自己定义一个事件处理.
            this.txtTest.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));

        }



        void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(sender as TextBox).Count > 0)
            {
                ((TextBox)sender).ToolTip = Validation.GetErrors((TextBox)sender)[0].ErrorContent.ToString();
            }
        }


    }
}
