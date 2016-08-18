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

using System.Xml.Linq;
using WPF_0070_Binding.Model;


namespace WPF_0070_Binding
{
    /// <summary>
    /// Page008_Linq.xaml 的交互逻辑
    /// </summary>
    public partial class Page008_Linq : Page
    {
        public Page008_Linq()
        {
            InitializeComponent();
        }


        // 准备数据源.
        private List<NormalUser> dataList = new List<NormalUser>()
        {
            new NormalUser() { Id= 1, Name = "张三",  Age = 23},
            new NormalUser() { Id= 2, Name = "李四",  Age = 24},
            new NormalUser() { Id= 3, Name = "王五",  Age = 25},
            new NormalUser() { Id= 4, Name = "赵六",  Age = 26},
        };

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            
            int queryValue = 0;
            Int32.TryParse(this.txtQueryCode.Text, out queryValue);

            // LINQ 查询.
            var query =
                from data in dataList
                where data.Id > queryValue
                select data;

            // 数据绑定.
            this.listViewTest.ItemsSource = query;
        }




        private void btnQuery2_Click(object sender, RoutedEventArgs e)
        {
            string code = this.txtQueryCode2.Text;

            XDocument xdoc = XDocument.Load(@"datatable.xml");


            // LINQ 查询 XML.
            var query =
                from element in xdoc.Descendants("team_member_type")
                where element.Element("member_type_code").Value.Contains(code)
                select new 
                {
                    member_type_code = element.Element("member_type_code").Value,
                    member_type_name = element.Element("member_type_name").Value
                };


            // 数据绑定.
            this.listViewTest2.ItemsSource = query;

        }




    }
}
