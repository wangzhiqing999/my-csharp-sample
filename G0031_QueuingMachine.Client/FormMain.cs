using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using G0031_QueuingMachine.Client.UI;


namespace G0031_QueuingMachine.Client
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
        private UserControlClient[] clientArray = new UserControlClient[5];
        

        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userControlClient5_Load(object sender, EventArgs e)
        {
            this.userControlClient1.SetWindowNumber("①");
            this.userControlClient2.SetWindowNumber("②");
            this.userControlClient3.SetWindowNumber("③");
            this.userControlClient4.SetWindowNumber("④");
            this.userControlClient5.SetWindowNumber("⑤");


            this.userControlClient1.ServiceCode = "A";
            this.userControlClient2.ServiceCode = "A";
            this.userControlClient3.ServiceCode = "B";
            this.userControlClient4.ServiceCode = "B";
            this.userControlClient5.ServiceCode = "C";

            clientArray[0] = userControlClient1;
            clientArray[1] = userControlClient2;
            clientArray[2] = userControlClient3;
            clientArray[3] = userControlClient4;
            clientArray[4] = userControlClient5;

            for (int i = 0; i < clientArray.Length; i++)
            {
                // 开始服务.
                clientArray[i].StartClient();
            }
        }

        /// <summary>
        /// 关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < clientArray.Length; i++)
            {
                // 开始服务.
                clientArray[i].StopClient();
            }
        }
    }
}
