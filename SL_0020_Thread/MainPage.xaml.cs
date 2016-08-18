using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Windows.Threading;

using System.Text.RegularExpressions;
using System.Threading;




namespace SL_0020_Thread
{
    public partial class MainPage : UserControl
    {

        /// <summary>
        /// 提示信息.
        /// </summary>
        private static System.Windows.Controls.TextBlock tbk;

        /// <summary>
        /// 等待线程.
        /// </summary>
        private Thread waitThread;




        public MainPage()
        {
            InitializeComponent();

            // 创建 DispatcherTimer
            DispatcherTimer timer = new DispatcherTimer();
            // 间隔1秒.
            timer.Interval = new TimeSpan(0, 0, 1);
            // 事件.
            timer.Tick += timer_Tick;
            // 开始计时.
            timer.Start();







            // 提示信息加到画面上.
            tbk = new TextBlock();
            // 父控件设置.
            this.border.Child = tbk;

            tbk.SizeChanged += tbk_SizeChanged;




        }


        private void timer_Tick(object sender, EventArgs e)
        {
            this.tbkTimer.Text = String.Format("当前时间：{0:HH:mm:ss}", DateTime.Now);
        }






        private void tbk_SizeChanged(object sender, RoutedEventArgs e)
        {
            if (tbk.Text == "")
            {
                this.btnSend.IsEnabled = true;
            }
        }



        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(this.txtPhone.Text, @"^[1]+[3,4,5,8]+\d{9}$"))
            {
                MessageBox.Show("请输入正确的手机号码", "输入错误", MessageBoxButton.OK);
                this.txtPhone.Focus();
                return;
            }


            // 这里应该是发送短消息的部分...

            // 按钮不可按.
            this.btnSend.IsEnabled = false;


            // 初始化线程.
            waitThread = new Thread(WaitMessageSend);

            // 开始线程处理.
            waitThread.Start();
        
        }




        public static void WaitMessageSend()
        {
            int i = 10;
            while (i > 0)
            {
                tbk.Dispatcher.BeginInvoke(delegate()
                {
                    tbk.Text = String.Format("{0}秒以后重新发送.", i);
                });
                i--;

                Thread.Sleep(1000);
            }


            tbk.Dispatcher.BeginInvoke(delegate()
            {
                tbk.Text = "";
            });
        }


    }
}
