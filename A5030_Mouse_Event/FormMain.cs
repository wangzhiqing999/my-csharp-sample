using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5030_Mouse_Event
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // 窗体的显示位置设置为手动。
            this.StartPosition = FormStartPosition.Manual;

            // 获取显示器屏幕宽度
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;

            // 获取显示器屏幕高度
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;

            // 让窗口处于右下角.
            this.Location = new Point(xWidth - this.Width, yHeight - this.Height);
        }


        /// <summary>
        /// 测试.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            MyMouseEvent myMouseEvent = new MyMouseEvent();

            // 绝对地址移动.
            myMouseEvent.AbsoluteMove(200, 200);

            

            // 绝对地址鼠标右键点击.
            myMouseEvent.AbsoluteRightClick(200, 200);
        }
    }
}
