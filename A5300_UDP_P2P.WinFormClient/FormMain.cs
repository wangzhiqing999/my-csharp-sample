using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5300_UDP_P2P
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 仅仅保持激活.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keepAliveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKeepAlive subForm = new FormKeepAlive();
            subForm.MdiParent = this;
            subForm.Show();
        }


        /// <summary>
        /// 用户列表.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserList subForm = new FormUserList();
            subForm.MdiParent = this;
            subForm.Show();
        }



        /// <summary>
        /// 通话.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void talkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTalk subForm = new FormTalk();
            subForm.MdiParent = this;
            subForm.Show();
        }


    }
}
