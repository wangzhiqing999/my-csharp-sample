using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace A0351_WinFormThreadTwoPart
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
        private string longTimeProcessResult1 = String.Empty;

        /// <summary>
        /// 用于暂存长时间执行的结果.
        /// </summary>
        private string longTimeProcessResult2 = String.Empty;

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
            this.txtResult1.Text = String.Empty;
            this.txtResult2.Text = String.Empty;
            this.txtResult.Text = String.Empty;

            int second = (int)nudSecond.Value;


            // 用于计算总运行时间的类.
            Stopwatch sw = Stopwatch.StartNew();



            if (this.rdoUseUIThread.Checked)
            {
                // 使用 UI 的线程来处理.
                // 长时间操作.
                LongTimeProcess1(second);
                // 显示结果.
                ShowResult1();

                // 长时间操作.
                LongTimeProcess2(second);
                // 显示结果.
                ShowResult2();

                // 显示总时间.
                this.txtResult.Text = String.Format("整个过程执行时间：{0}毫秒", sw.ElapsedMilliseconds);
            }
            else if (this.rdoUseNewThread.Checked)            
            {
                // 使用新的线程来处理.
                new Thread(() =>
                {
                    // 长时间操作.
                    LongTimeProcess1(second);
                    LongTimeProcess2(second);
                    Invoke(new Action(() =>
                    {
                        // 显示结果.
                        ShowResult1();
                        ShowResult2();
                        this.txtResult.Text = String.Format("整个过程执行时间：{0}毫秒", sw.ElapsedMilliseconds);
                    }));

                }).Start();
            }
            else if (this.rdoUseNewThread2.Checked)
            {
                // 使用新的线程来处理.
                new Thread(() =>
                {
                    // 长时间操作.
                    LongTimeProcess1(second);
                    Invoke(new Action(() =>
                    {
                        // 显示结果.
                        ShowResult1();

                        if (!String.IsNullOrEmpty(this.txtResult2.Text))
                        {
                            this.txtResult.Text = String.Format("整个过程执行时间：{0}毫秒", sw.ElapsedMilliseconds);
                        }
                    }));

                }).Start();

                // 使用新的线程来处理.
                new Thread(() =>
                {
                    // 长时间操作.
                    LongTimeProcess2(second);
                    Invoke(new Action(() =>
                    {
                        // 显示结果.
                        ShowResult2();

                        if (!String.IsNullOrEmpty(this.txtResult1.Text))
                        {
                            this.txtResult.Text = String.Format("整个过程执行时间：{0}毫秒", sw.ElapsedMilliseconds);
                        }
                    }));

                }).Start();
            }
            else {
                // 并行任务.
                Task[] tasks = new Task[2]
                {
                    // 加载左边的结构.
                    Task.Factory.StartNew(() => LongTimeProcess1(second)),
                    // 加载右边的结构.
                    Task.Factory.StartNew(() => LongTimeProcess2(second))
                };
                // 并行处理.
                Task.WaitAll(tasks);

                // 显示结果.
                ShowResult1();
                ShowResult2();
                this.txtResult.Text = String.Format("整个过程执行时间：{0}毫秒", sw.ElapsedMilliseconds);
            }

            


        }




        /// <summary>
        /// 用于模拟一个长时间的处理.
        /// </summary>
        /// <param name="second"></param>
        private void LongTimeProcess1(int second)
        {
            // 这里用于 模拟 一个固定秒数的长时间操作.
            Thread.Sleep(second * 1000);

            // 设置 长时间执行操作的返回结果.
            longTimeProcessResult1 = String.Format("某个长时间操作，执行了{0}毫秒", second * 1000);
        }


        /// <summary>
        /// 用于模拟一个长时间的处理.
        /// </summary>
        /// <param name="second"></param>
        private void LongTimeProcess2(int second)
        {
            // 这里用于 模拟 一个固定秒数的长时间操作.
            Thread.Sleep(second * 1000 / 2);

            // 设置 长时间执行操作的返回结果.
            longTimeProcessResult2 = String.Format("某个长时间操作，执行了{0}毫秒", second * 1000 / 2);
        }



        /// <summary>
        /// 用于显示处理结果.
        /// </summary>
        private void ShowResult1()
        {
            this.txtResult1.Text = longTimeProcessResult1;
        }

        /// <summary>
        /// 用于显示处理结果.
        /// </summary>
        private void ShowResult2()
        {
            this.txtResult2.Text = longTimeProcessResult2;
        }

    }
}
