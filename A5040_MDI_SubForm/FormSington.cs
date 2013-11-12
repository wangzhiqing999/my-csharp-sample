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
    public partial class FormSington : Form
    {

        /// <summary>
        /// 因为是单例， 所以构造函数不能是 public.
        /// </summary>
        private FormSington()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 单例类.
        /// </summary>
        private static FormSington me;


        /// <summary>
        /// 获取实例.
        /// </summary>
        /// <returns></returns>
        public static FormSington GetInstance()
        {
            if (me == null)
            {
                me = new FormSington();
            }
            return me;
        }


        /// <summary>
        /// 窗口关闭事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSington_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 因为是单例， 因此窗口关闭的时候，做隐藏的处理， 不做关闭的操作.
            this.Hide();

            // 不过后续的关窗操作.
            e.Cancel = true;
        }
    }
}
