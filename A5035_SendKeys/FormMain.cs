using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace A5035_SendKeys
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 测试输入 ABC.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnABC_Click(object sender, EventArgs e)
        {
            this.txtResult.Focus();
            SendKeys.Send("ABC");
            SendKeys.Send("{ENTER}");
        }

        /// <summary>
        /// 测试输入 123.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn123_Click(object sender, EventArgs e)
        {
            this.txtResult.Focus();
            SendKeys.Send("123");
            SendKeys.Send("{ENTER}");
        }


        /// <summary>
        /// 模拟  Alt + A 组合键.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AA_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("%A");
        }

        /// <summary>
        /// 模拟  Alt + 1 组合键.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_A1_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("%1");
        }



        /// <summary>
        /// 模拟 Shift+xyz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sxyz_Click(object sender, EventArgs e)
        {
            this.txtResult.Focus();

            // 实际输出结果，取决于当前键盘的 Caps Lock.
            SendKeys.Send("+x");
            SendKeys.Send("+y");
            SendKeys.Send("+z");
            SendKeys.Send("{ENTER}");


            SendKeys.Send("+X");
            SendKeys.Send("+Y");
            SendKeys.Send("+Z");
            SendKeys.Send("{ENTER}");
        }


        /// <summary>
        /// 模拟  Ctrl + V
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CV_Click(object sender, EventArgs e)
        {
            this.txtResult.Focus();

            // 由于 Ctrl+A 好像有点问题的样子
            // 这里只好手动向 剪贴板 中， 设置文本数据， 然后模拟 Ctrl+V 操作！
            Clipboard.SetText("测试 Ctrl+V 的操作！");
            SendKeys.Send("{ENTER}");
            SendKeys.Send("^V");
        }





    }
}
