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

namespace WPF_0120_Async
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



        /// <summary>
        /// 简单异步处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkSimpleAsync_Click(object sender, RoutedEventArgs e)
        {
            Page001_SimpleAsync pg = new Page001_SimpleAsync();
            pc.Content = pg;
        }


        /// <summary>
        /// IsAsync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkIsAsync_Click(object sender, RoutedEventArgs e)
        {
            Page002_IsAsync pg = new Page002_IsAsync();
            pc.Content = pg;
        }



        /// <summary>
        /// PropertyChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkPropertyChanged_Click(object sender, RoutedEventArgs e)
        {
            Page003_PropertyChanged pg = new Page003_PropertyChanged();
            pc.Content = pg;
        }



    }
}
