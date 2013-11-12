using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5040_MDI_SubForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 普通方式打开.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 简单创建新窗口 并显示.
            FormNormal newForm = new FormNormal();
            newForm.MdiParent = this;
            newForm.Show();
        }


        /// <summary>
        /// 单例方式.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void singtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSington newForm = FormSington.GetInstance();
            newForm.MdiParent = this;
            newForm.Show();
        }


        /// <summary>
        /// 先关后开.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 遍历当前窗口的所有 mid 子窗口.
            foreach (Form oldForm in this.MdiChildren)
            {
                // 如果窗口类型为 指定类型，那么先关闭掉.
                if (oldForm is FormCloseOpen)
                {
                    oldForm.Close();
                }
            }

            // 关闭旧窗口以后，简单创建新窗口 并显示.
            FormCloseOpen newForm = new FormCloseOpen();
            newForm.MdiParent = this;
            newForm.Show();
        }



    }
}
