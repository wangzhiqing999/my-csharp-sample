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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void LnkBasicResource_Click(object sender, RoutedEventArgs e)
        {
            Page001_BasicResource pg = new Page001_BasicResource();
            pc.Content = pg;
        }


        private void LnkStaticDynamic_Click(object sender, RoutedEventArgs e)
        {
            Page002_StaticDynamic pg = new Page002_StaticDynamic();
            pc.Content = pg;
        }


        private void LnkPropertiesResources_Click(object sender, RoutedEventArgs e)
        {
            Page003_PropertiesResources pg = new Page003_PropertiesResources();
            pc.Content = pg;
        }


        private void LnkImageResources_Click(object sender, RoutedEventArgs e)
        {
            Page004_Images pg = new Page004_Images();
            pc.Content = pg;
        }



    }
}
