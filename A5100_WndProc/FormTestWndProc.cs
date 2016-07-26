using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5100_WndProc
{
    public partial class FormTestWndProc : Form
    {
        public FormTestWndProc()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 当某个窗口将被激活时，
        /// 将被激活窗口和当前活动（即将失去激活）窗口会收到此消息，
        /// 发此消息给应用程序哪个窗口是激活的，哪个是非激活的
        /// </summary>
        private const int WM_ACTIVATEAPP = 0x001C;


        // 一些其他的 消息ID，  可参考：
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ff468922(v=vs.85).aspx





        /// <summary>
        /// 处理 Windows 消息。
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            Console.WriteLine("消息ID = {0}; LParam = {1}; WParam = {2}", m.Msg, m.LParam, m.WParam);
            switch (m.Msg)
            {
                case WM_ACTIVATEAPP:
                    // The WParam value identifies what is occurring.
                    if (((int)m.WParam != 0))
                    {
                        this.lblTest.Text = "应用程序处理 Active 状态！";
                    }
                    else
                    {
                        this.lblTest.Text = "应用程序处理处于 Inactive 状态！";
                    }
                    break;
            }
            base.WndProc(ref m);
        }


    }
}
