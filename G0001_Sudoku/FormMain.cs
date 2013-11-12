using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G0001_Sudoku
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void temi9X9_Click(object sender, EventArgs e)
        {
            Form9x9 subForm = new Form9x9()
            {
                MdiParent = this,
            };

            subForm.Show();
        }
    }
}
