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


using WPF_0070_Binding.Model;

namespace WPF_0070_Binding
{
    /// <summary>
    /// Interaction logic for Page005_ItemSource.xaml
    /// </summary>
    public partial class Page005_ItemSource : Page
    {
        public Page005_ItemSource()
        {
            InitializeComponent();


            // 准备数据源.
            List<NormalUser> dataList = new List<NormalUser>()
            {
                new NormalUser() { Id= 1, Name = "张三",  Age = 23},
                new NormalUser() { Id= 2, Name = "李四",  Age = 24},
                new NormalUser() { Id= 3, Name = "王五",  Age = 25},
                new NormalUser() { Id= 4, Name = "赵六",  Age = 26},
            };


            // 设置 ListBox 控件的绑定.
            this.lstData.ItemsSource = dataList;
            //this.lstData.DisplayMemberPath = "Name";

            // 设置 TextBox 控件的绑定.
            Binding binding = new Binding("SelectedItem.Id") { Source = this.lstData };
            this.txtID.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
