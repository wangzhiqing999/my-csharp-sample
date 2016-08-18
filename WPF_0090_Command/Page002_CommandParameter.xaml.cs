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

namespace WPF_0090_Command
{
    /// <summary>
    /// Page002_CommandParameter.xaml 的交互逻辑
    /// </summary>
    public partial class Page002_CommandParameter : Page
    {
        public Page002_CommandParameter()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 探测命令是否可以执行.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtName.Text))
            {
                // 内容为空， 不可执行.
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }


            // 为了避免事件继续向上传递而影响性能. 这里标记处理已完成.
            e.Handled = true;
        }



        /// <summary>
        /// 执行命令代码.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string name = this.txtName.Text;

            this.lstResult.Items.Add(String.Format("{0} : {1}", e.Parameter, name));
        }



    }
}
