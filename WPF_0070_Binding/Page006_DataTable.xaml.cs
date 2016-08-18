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


using System.Data;


namespace WPF_0070_Binding
{
    /// <summary>
    /// Page006_DataTable.xaml 的交互逻辑
    /// </summary>
    public partial class Page006_DataTable : Page
    {

        private const String DATATABLE_XML_FILE = "datatable.xml";
        private const String DATATABLE_SCHEMA_XML_FILE = "datatable_schema.xml";


        public Page006_DataTable()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // 加载 DataTable.
            DataTable newDt = new DataTable();
            newDt.ReadXmlSchema(DATATABLE_SCHEMA_XML_FILE);
            newDt.ReadXml(DATATABLE_XML_FILE);

            
            // ListBox 数据绑定.
            this.lstTest.DisplayMemberPath = "member_type_name";
            this.lstTest.ItemsSource = newDt.DefaultView;



            // ListView 数据绑定.
            this.lsvTest.ItemsSource = newDt.DefaultView;

        }
    }
}
