using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using A5200_Chart.Line;
using A5200_Chart.Area;
using A5200_Chart.BarColumn;
using A5200_Chart.Circular;
using A5200_Chart.Financial;
using A5200_Chart.PieDoughnut;
using A5200_Chart.Point;
using A5200_Chart.PyramidFunnel;
using A5200_Chart.Range;


namespace A5200_Chart
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChartLine subForm = new FormChartLine();
            subForm.MdiParent = this;
            subForm.Show();

        }



        /// <summary>
        /// Area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArea subForm = new FormArea();
            subForm.MdiParent = this;
            subForm.Show();
        }




        /// <summary>
        /// BarColumn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBarColumn subForm = new FormBarColumn();
            subForm.MdiParent = this;
            subForm.Show();
        }



        private void polarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPolar subForm = new FormPolar();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void redarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRadar subForm = new FormRadar();
            subForm.MdiParent = this;
            subForm.Show();
        }


        /// <summary>
        /// Stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStock subForm = new FormStock();
            subForm.MdiParent = this;
            subForm.Show();
        }

        /// <summary>
        /// Stock Plus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stockPlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormStockPlus();
            subForm.MdiParent = this;
            subForm.Show();
        }


        /// <summary>
        /// Pie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPie subForm = new FormPie();
            subForm.MdiParent = this;
            subForm.Show();
        }



        /// <summary>
        /// Point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPoint subForm = new FormPoint();
            subForm.MdiParent = this;
            subForm.Show();
        }



        private void pyramidFunnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPyramidFunnel subForm = new FormPyramidFunnel();
            subForm.MdiParent = this;
            subForm.Show();
        }


        /// <summary>
        /// Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRange subForm = new FormRange();
            subForm.MdiParent = this;
            subForm.Show();
        }




    }
}
