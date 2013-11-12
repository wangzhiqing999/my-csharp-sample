using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G0051_Jigsaw.App
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 3X3 的拼图.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsml3x3_Click(object sender, EventArgs e)
        {
            Form3x3 form = new Form3x3();
            form.MdiParent = this;
            form.Show();
        }
    }
}
