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
    /// Page001_SimpleBinding.xaml 的交互逻辑
    /// </summary>
    public partial class Page001_SimpleBinding : Page
    {

        /// <summary>
        /// 内部变量.
        /// </summary>
        Student stu;



        public Page001_SimpleBinding()
        {
            InitializeComponent();


            // 初始化数据源.
            stu = new Student()
            {
                Name = "初始值"
            };


            // 准备绑定.
            Binding binging = new Binding();
            binging.Source = stu;
            binging.Path = new PropertyPath("Name");

            // 使用 Binding 连接数据源 与 Binding 目标.
            BindingOperations.SetBinding(this.txtName, TextBox.TextProperty, binging);
        }


        /// <summary>
        /// 测试变更属性 按钮按下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 注意： 按钮的事件， 没有  主动去修改 画面上控件的数据.
            Random r = new Random ();
            this.stu.Name += r.Next(10);
        }
    }
}
