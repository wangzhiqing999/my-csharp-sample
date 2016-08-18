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

namespace WPF_0100_Resource
{
    /// <summary>
    /// Page002_StaticDynamic.xaml 的交互逻辑
    /// </summary>
    public partial class Page002_StaticDynamic : Page
    {
        public Page002_StaticDynamic()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["res1"] = new TextBlock() { Text = "尝试更新资源1" };
            this.Resources["res2"] = new TextBlock() { Text = "尝试更新资源2" };
        }
    }
}
