using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace A0352_WinFormThreadInvokeParam
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取数据的委托。
        /// </summary>
        /// <param name="processer"></param>
        /// <returns></returns>
        delegate ListViewItem GetItemDelegate (string processer);

        /// <summary>
        /// 委托处理.
        /// </summary>
        GetItemDelegate GetItem;



        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //增加列标题
            this.lvSourceData.Columns.Add("ID编号", 30, HorizontalAlignment.Center);
            this.lvSourceData.Columns.Add("名称", 50, HorizontalAlignment.Center);
            this.lvSourceData.Columns.Add("处理线程", 60, HorizontalAlignment.Center);
            this.lvSourceData.Columns.Add("处理状态", 100, HorizontalAlignment.Center);

            
            for (int i = 1; i <= 20; i++)
            {
                string[] str = new string[] { i.ToString(), "项目" + i, "", "" };
                ListViewItem item = new ListViewItem(str, 0);
                lvSourceData.Items.Add(item);
            }


            GetItem = this.GetFirstNotProcessItem;
        }




        /// <summary>
        /// 开始处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(TestThread1);
            t1.Start();

            Thread t2 = new Thread(TestThread2);
            t2.Start();

            Thread t3 = new Thread(TestThread3);
            t3.Start();

            Thread t4 = new Thread(TestThread4);
            t4.Start();
        }

        

        /// <summary>
        /// 获取第一个还没有处理的 项目.
        /// </summary>
        /// <returns></returns>
        public ListViewItem GetFirstNotProcessItem(string processer)
        {
            foreach (ListViewItem item in lvSourceData.Items)
            {
                if (String.IsNullOrEmpty(item.SubItems[2].Text))
                {
                    // 设置处理人.
                    item.SubItems[2].Text = processer;

                    // 设置处理状态.
                    item.SubItems[3].Text = "开始处理...";

                    // 返回.
                    return item;
                }
            }
            // 全部处理了.
            return null;
        }



        #region 模拟不同的线程处理.


        /// <summary>
        /// 测试线程 (通用的处理逻辑)
        /// </summary>
        /// <param name="threadName"> 处理者的名称 </param>
        /// <param name="lblDisplay"> 显示处理的控件名 </param>
        /// <param name="workTime"> 模拟工作的时间 </param>
        private void TestThreadCommon(string threadName, Label lblDisplay, int workTime)
        {
            while (true)
            {
                // 通过 Invoke 调用委托， 获取画面数据.
                Object item = Invoke(GetItem, threadName);

                if (item == null)
                {
                    // 没有数据了， 结束线程处理.
                    break;
                }

                ListViewItem lvItem = item as ListViewItem;

                // 通过 Invoke 调用委托， 设置画面数据. 
                Invoke(new Action(() =>
                {
                    lblDisplay.Text = String.Format("开始处理 {0}", lvItem.Text);
                }));


                // 模拟一个耗时的处理.
                Thread.Sleep(workTime);


                // 通过 Invoke 调用委托， 设置画面数据. 
                Invoke(new Action(() =>
                {
                    lblDisplay.Text = "";
                    lvItem.SubItems[3].Text = "处理完毕";
                }));
            }
        }


        /// <summary>
        /// 测试线程1.
        /// </summary>
        private void TestThread1()
        {
            TestThreadCommon("线程1", this.lblThread1, 3000);
        }

        /// <summary>
        /// 测试线程2.
        /// </summary>
        private void TestThread2()
        {
            TestThreadCommon("线程2", this.lblThread2, 5000);
        }

        /// <summary>
        /// 测试线程3.
        /// </summary>
        private void TestThread3()
        {
            TestThreadCommon("线程3", this.lblThread3, 8000);
        }

        /// <summary>
        /// 测试线程4.
        /// </summary>
        private void TestThread4()
        {
            TestThreadCommon("线程4", this.lblThread4, 10000);
        }

        #endregion


    }
}
