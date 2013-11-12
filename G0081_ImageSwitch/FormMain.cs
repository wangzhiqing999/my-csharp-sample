using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G0081_ImageSwitch
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
            foreach (UcImageSwitch ucIS in this.tlpMain.Controls)
            {
                ucIS.Pic1 = new Bitmap("1.jpg");
                ucIS.Pic2 = new Bitmap("2.jpg");
                ucIS.ShowPic();
            }

            

            
        }



        /// <summary>
        /// 切换.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (UcImageSwitch ucIS in this.tlpMain.Controls)
            {
                ucIS.Switch();
            }
            
        }


    }
}
