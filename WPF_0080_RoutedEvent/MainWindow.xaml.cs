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

namespace WPF_0080_RoutedEvent
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
        /// Bubble策略
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkBubble_Click(object sender, RoutedEventArgs e)
        {
            Page001_Bubble pg = new Page001_Bubble();
            pc.Content = pg;
        }


        /// <summary>
        /// Tunnel策略
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkTunnel_Click(object sender, RoutedEventArgs e)
        {
            Page002_Tunnel pg = new Page002_Tunnel();
            pc.Content = pg;
        }




    }
}
