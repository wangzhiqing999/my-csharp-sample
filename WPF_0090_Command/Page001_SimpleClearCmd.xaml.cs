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
    /// Page001_SimpleClearCmd.xaml 的交互逻辑
    /// </summary>
    public partial class Page001_SimpleClearCmd : Page
    {
        public Page001_SimpleClearCmd()
        {
            InitializeComponent();


            InitializeCommand();
        }



        /// <summary>
        /// 命令.
        /// </summary>
        private RoutedCommand clearCmd = new RoutedCommand("Clear", typeof(Page001_SimpleClearCmd));


        /// <summary>
        /// 初始化命令.
        /// </summary>
        private void InitializeCommand()
        {
            // 设置按钮的 命令.
            this.btnClear.Command = this.clearCmd;
            // 增加热键.
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            // 指定命令的目标.
            this.btnClear.CommandTarget = this.txtTest;

            // 创建命令关联.
            CommandBinding cb = new CommandBinding();
            cb.Command = this.clearCmd;

            // 使用命令可以避免自己写代码判断 按钮是否可用.
            cb.CanExecute += new CanExecuteRoutedEventHandler(this.cb_CanExecute);


            cb.Executed += new ExecutedRoutedEventHandler(this.cb_Executed);



            // 命令关联在外围控件上.
            // 如果不是外围控件的话， 可能无法捕捉到 CanExecute 与 Executed 等路由事件.
            this.stackPanel.CommandBindings.Add(cb);
        }


        /// <summary>
        /// 探测命令是否可以执行.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTest.Text))
            {
                // 内容已经为空了， 按钮不可执行.
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
        void cb_Executed(object sender,  ExecutedRoutedEventArgs e)
        {
            this.txtTest.Clear();

            // 为了避免事件继续向上传递而影响性能. 这里标记处理已完成.
            e.Handled = true;
        }



    }
}
