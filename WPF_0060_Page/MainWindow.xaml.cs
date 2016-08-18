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

namespace WPF_0060_Page
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


        private void LnkPre1_Click(object sender, RoutedEventArgs e)
        {
            Page2 p2 = new Page2();
            pc.Content = p2;
        }


        private void LnkPre_Click(object sender, RoutedEventArgs e)
        {
            Page1 p1 = new Page1();
            p1.Tag = this;

            pc.Content = p1;
        }
    }
}
