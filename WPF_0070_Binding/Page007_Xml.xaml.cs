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


namespace WPF_0070_Binding
{
    /// <summary>
    /// Page007_Xml.xaml 的交互逻辑
    /// </summary>
    public partial class Page007_Xml : Page
    {
        public Page007_Xml()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            XmlDataDocument doc = new XmlDataDocument();
            doc.Load(@"datatable.xml");


            XmlDataProvider xdp = new XmlDataProvider();
            xdp.Document = doc;

            // 使用 XPaht 选择需要暴露的数据.
            xdp.XPath = @"/NewDataSet/team_member_type";

            // 数据绑定.
            this.lsvTest.DataContext = xdp;
            this.lsvTest.SetBinding(ListView.ItemsSourceProperty, new Binding());

        }
    }
}
