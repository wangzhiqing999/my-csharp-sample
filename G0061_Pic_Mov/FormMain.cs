using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G0061_Pic_Mov
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 控件数组.
        /// </summary>
        private UserControlPic2Mov[] controlArray = new UserControlPic2Mov[8];

        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            controlArray[0] = this.userControlPic2Mov1;
            controlArray[1] = this.userControlPic2Mov2;
            controlArray[2] = this.userControlPic2Mov3;
            controlArray[3] = this.userControlPic2Mov4;
            controlArray[4] = this.userControlPic2Mov5;
            controlArray[5] = this.userControlPic2Mov6;
            controlArray[6] = this.userControlPic2Mov7;
            controlArray[7] = this.userControlPic2Mov8;

            foreach (UserControlPic2Mov ctl in controlArray)
            {
                ctl.InitMov();
            }
        }



        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (UserControlPic2Mov ctl in controlArray)
            {
                ctl.Start();
            }
        }



        /// <summary>
        /// 结束.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (UserControlPic2Mov ctl in controlArray)
            {
                ctl.Stop();
            }
        }
    }
}
