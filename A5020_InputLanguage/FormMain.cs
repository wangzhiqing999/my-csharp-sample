using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5020_InputLanguage
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
            // 当前输入法.
            this.lblCurrentInputLanguage.Text = "当前输入法：" + InputLanguage.CurrentInputLanguage.LayoutName;


            // 已安装输入法.
            foreach (InputLanguage nextLang in InputLanguage.InstalledInputLanguages)
            {
                this.cboInstalledInputLanguages.Items.Add(nextLang.LayoutName);
            }
        }


        /// <summary>
        /// 修改输入法.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.cboInstalledInputLanguages.SelectedIndex != -1)
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[this.cboInstalledInputLanguages.SelectedIndex];
            }
        }



        /// <summary>
        /// 密码 获得输入焦点时， 判断 CAPS LOCK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            this.lblWarn.Visible = Console.CapsLock;
        }


        /// <summary>
        /// 按键点击.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.lblWarn.Visible = Console.CapsLock;
        }


    }
}
