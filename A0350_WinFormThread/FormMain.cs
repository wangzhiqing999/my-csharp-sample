using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace A0350_WinFormThread
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 用于暂存长时间执行的结果.
        /// </summary>
        private string longTimeProcessResult = String.Empty;


        /// <summary>
        /// 开始处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // 首先清空结果.
            this.txtResult.Text = String.Empty;

            int second = (int)nudSecond.Value;

            if (this.rdoUseUIThread.Checked)
            {
                // 使用 UI 的线程来处理.

                // 长时间操作.
                LongTimeProcess(second);

                // 显示结果.
                ShowResult();
            }
            else
            {
                // 使用新的线程来处理.

                new Thread(() =>
                    {
                        // 长时间操作.
                        LongTimeProcess(second);

                        Invoke(new Action(() =>
                            {
                                // 显示结果.
                                ShowResult();
                            }));

                    }).Start();
            }

        }



        /// <summary>
        /// 用于模拟一个长时间的处理.
        /// </summary>
        /// <param name="second"></param>
        private void LongTimeProcess(int second)
        {
            // 这里用于 模拟 一个固定秒数的长时间操作.
            Thread.Sleep(second * 1000);

            // 设置 长时间执行操作的返回结果.
            longTimeProcessResult = String.Format("某个长时间操作，执行了{0}秒", second);
        }


        /// <summary>
        /// 用于显示处理结果.
        /// </summary>
        private void ShowResult()
        {
            this.txtResult.Text = longTimeProcessResult;
        }

    }
}
