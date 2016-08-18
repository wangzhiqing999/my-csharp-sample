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

using WPF_0070_Binding.Service;


namespace WPF_0070_Binding
{
    /// <summary>
    /// Page009_ObjectDataProvider.xaml 的交互逻辑
    /// </summary>
    public partial class Page009_ObjectDataProvider : Page
    {
        public Page009_ObjectDataProvider()
        {
            InitializeComponent();


            // 设置绑定.
            SetBingding();
        }




        private void SetBingding()
        {

            // 创建并配置 ObjectDataProvider
            ObjectDataProvider odp = new ObjectDataProvider();
            odp.ObjectInstance = new Calculator();
            odp.MethodName = "Add";
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");


            // 参数绑定.
            Binding bingingToArg1 = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger =UpdateSourceTrigger.PropertyChanged
            };

            // 参数绑定.
            Binding bingingToArg2 = new Binding("MethodParameters[1]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };


            Binding bindingToResult = new Binding(".") {Source = odp};


            // 将 Binding 关联到 UI 元素上.
            this.txtArg1.SetBinding(TextBox.TextProperty, bingingToArg1);
            this.txtArg2.SetBinding(TextBox.TextProperty, bingingToArg2);
            this.txtResult.SetBinding(TextBox.TextProperty, bindingToResult);
        }
    }
}
