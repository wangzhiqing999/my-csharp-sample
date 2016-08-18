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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 简单绑定.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkSimpleBinding_Click(object sender, RoutedEventArgs e)
        {
            Page001_SimpleBinding pg = new Page001_SimpleBinding();
            pc.Content = pg;
        }


        /// <summary>
        /// 控件之间绑定.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkControlBinding_Click(object sender, RoutedEventArgs e)
        {
            Page002_ControlBinding pg = new Page002_ControlBinding();
            pc.Content = pg;
        }


        /// <summary>
        /// DataContext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkDataContext_Click(object sender, RoutedEventArgs e)
        {
            Page003_DataContext pg = new Page003_DataContext();
            pc.Content = pg;
        }


        /// <summary>
        /// DataContext2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkDataContext2_Click(object sender, RoutedEventArgs e)
        {
            Page004_DataContext2 pg = new Page004_DataContext2();
            pc.Content = pg;
        }


        /// <summary>
        /// Item Source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkItemSource_Click(object sender, RoutedEventArgs e)
        {
            Page005_ItemSource pg = new Page005_ItemSource();
            pc.Content = pg;
        }



        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkDataTable_Click(object sender, RoutedEventArgs e)
        {
            Page006_DataTable pg = new Page006_DataTable();
            pc.Content = pg;
        }



        /// <summary>
        /// Xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkXml_Click(object sender, RoutedEventArgs e)
        {
            Page007_Xml pg = new Page007_Xml();
            pc.Content = pg;

        }


        /// <summary>
        /// Linq
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkLinq_Click(object sender, RoutedEventArgs e)
        {
            Page008_Linq pg = new Page008_Linq();
            pc.Content = pg;
        }



        /// <summary>
        /// ObjectDataProvider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkObjectDataProvider_Click(object sender, RoutedEventArgs e)
        {
            Page009_ObjectDataProvider pg = new Page009_ObjectDataProvider();
            pc.Content = pg;
        }


        /// <summary>
        /// RelativeSource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkRelativeSource_Click(object sender, RoutedEventArgs e)
        {
            Page010_RelativeSource pg = new Page010_RelativeSource();
            pc.Content = pg;
        }


        /// <summary>
        /// 验证.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkValidation_Click(object sender, RoutedEventArgs e)
        {
            Page011_Validation pg = new Page011_Validation();
            pc.Content = pg;
        }



        /// <summary>
        /// 数据转换.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkConverter_Click(object sender, RoutedEventArgs e)
        {
            Page012_Converter pg = new Page012_Converter();
            pc.Content = pg;
        }



        /// <summary>
        /// 多路绑定.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LnkMultiBinding_Click(object sender, RoutedEventArgs e)
        {
            Page013_MultiBinding pg = new Page013_MultiBinding();
            pc.Content = pg;
        }



    }
}
