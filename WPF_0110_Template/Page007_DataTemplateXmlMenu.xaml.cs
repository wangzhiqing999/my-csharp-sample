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

using System.Xml;

namespace WPF_0110_Template
{
    /// <summary>
    /// Page007_DataTemplateXmlMenu.xaml 的交互逻辑
    /// </summary>
    public partial class Page007_DataTemplateXmlMenu : Page
    {
        public Page007_DataTemplateXmlMenu()
        {
            InitializeComponent();
        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = e.OriginalSource as MenuItem;
            XmlElement xe = mi.Header as XmlElement;
            MessageBox.Show(xe.Attributes["Name"].Value);
        }



    }
}
