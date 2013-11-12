using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G0071_BlackJack.App
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 单例.
        /// </summary>
        private static FormMain me;


        private FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取实例.
        /// </summary>
        /// <returns></returns>
        public static FormMain GetFormMain()
        {
            if (me == null)
            {
                me = new FormMain();
            }
            return me;
        }



        /// <summary>
        /// 单人游戏.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnePlayer_Click(object sender, EventArgs e)
        {
            // 本窗口隐藏
            this.Hide();

            // 显示子窗口.
            FormOnePlayer form = new FormOnePlayer();
            form.Show();
        }



    }
}
