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
    /// Interaction logic for Page004_DataContext2.xaml
    /// </summary>
    public partial class Page004_DataContext2 : Page
    {
        public Page004_DataContext2()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("用于测试 依次向上查询 DataContext 的处理逻辑！" + btnTest.DataContext.ToString());
        }
    }
}
