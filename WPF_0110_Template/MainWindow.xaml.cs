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

namespace WPF_0110_Template
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

        private void LnkDataTemplate_Click(object sender, RoutedEventArgs e)
        {
            Page001_DataTemplate pg = new Page001_DataTemplate();
            pc.Content = pg;
        }

        private void LnkControlTemplate_Click(object sender, RoutedEventArgs e)
        {
            Page002_ControlTemplate pg = new Page002_ControlTemplate();
            pc.Content = pg;
        }

        private void LnkDataTemplateAll_Click(object sender, RoutedEventArgs e)
        {
            Page003_DataTemplateAll pg = new Page003_DataTemplateAll();
            pc.Content = pg;
        }

        private void LnkControlTemplateAll_Click(object sender, RoutedEventArgs e)
        {
            Page004_ControlTemplateAll pg = new Page004_ControlTemplateAll();
            pc.Content = pg;
        }

        private void LnkDataTemplateXml_Click(object sender, RoutedEventArgs e)
        {
            Page005_DataTemplateXml pg = new Page005_DataTemplateXml();
            pc.Content = pg;
        }


        private void LnkDataTemplateXmlTreeView_Click(object sender, RoutedEventArgs e)
        {
            Page006_DataTemplateXmlTreeView pg = new Page006_DataTemplateXmlTreeView();
            pc.Content = pg;
        }

        private void LnkDataTemplateXmlMenu_Click(object sender, RoutedEventArgs e)
        {
            Page007_DataTemplateXmlMenu pg = new Page007_DataTemplateXmlMenu();
            pc.Content = pg;
        }

        private void LnkStyle_Click(object sender, RoutedEventArgs e)
        {
            Page008_Style pg = new Page008_Style();
            pc.Content = pg;
        }

        private void LnkStyleTrigger_Click(object sender, RoutedEventArgs e)
        {
            Page009_StyleTrigger pg = new Page009_StyleTrigger();
            pc.Content = pg;
        }

        private void LnkStyleMultiTrigger_Click(object sender, RoutedEventArgs e)
        {
            Page010_StyleMultiTrigger pg = new Page010_StyleMultiTrigger();
            pc.Content = pg;
        }

        private void LnkDataTrigger_Click(object sender, RoutedEventArgs e)
        {
            Page011_DataTrigger pg = new Page011_DataTrigger();
            pc.Content = pg;
        }

        private void LnkMultiDataTrigger_Click(object sender, RoutedEventArgs e)
        {
            Page012_MultiDataTrigger pg = new Page012_MultiDataTrigger();
            pc.Content = pg;
        }

        private void LnkEventTrigger_Click(object sender, RoutedEventArgs e)
        {
            Page013_EventTrigger pg = new Page013_EventTrigger();
            pc.Content = pg;
        }



    }
}
