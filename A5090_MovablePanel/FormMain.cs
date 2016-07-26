using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5090_MovablePanel
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnMoveImage_Click(object sender, EventArgs e)
        {
            FormMoveImage form = new FormMoveImage();
            form.ShowDialog();
        }


        private void btnMovePanel_Click(object sender, EventArgs e)
        {
            FormMovePanel form = new FormMovePanel();
            form.ShowDialog();
        }
    }
}
