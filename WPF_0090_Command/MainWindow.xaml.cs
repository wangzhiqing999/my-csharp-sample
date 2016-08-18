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

namespace WPF_0090_Command
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



        private void LnkClear_Click(object sender, RoutedEventArgs e)
        {
            Page001_SimpleClearCmd pg = new Page001_SimpleClearCmd();
            pc.Content = pg;
        }



        private void LnkCommandParameter_Click(object sender, RoutedEventArgs e)
        {
            Page002_CommandParameter pg = new Page002_CommandParameter();
            pc.Content = pg;
        }
    }
}
