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

namespace WPF_0050_X
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public static string StaticValue = "x:Static 获取 静态变量 （注：需要定义 xmlns:local）";

        public static string StaticProp
        {
            get
            {
                return "x:Static 获取 静态属性 （注：需要定义 xmlns:local）";
            }
        }


        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            string str = this.FindResource("Key") as string;
            this.txtTest.Text = str;
        }
    }
}
