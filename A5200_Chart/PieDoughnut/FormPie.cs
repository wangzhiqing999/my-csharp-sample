using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;


namespace A5200_Chart.PieDoughnut
{
    public partial class FormPie : Form
    {
        public FormPie()
        {
            InitializeComponent();
        }

        private void FormPie_Load(object sender, EventArgs e)
        {

            // Populate series data
            double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42 };
            string[] xValues = { "France", "Canada", "Germany", "USA", "Italy" };
            chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);

            // Set Doughnut chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;

            // Set labels style
            chart1.Series["Series1"]["PieLabelStyle"] = "Outside";

            // Set Doughnut radius percentage
            chart1.Series["Series1"]["DoughnutRadius"] = "30";

            // Explode data point with label "Italy"
            chart1.Series["Series1"].Points[4]["Exploded"] = "true";
           
            // Set drawing style
            chart1.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";



            // Enable 3D
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;



        }




        /// <summary>
        /// 3D 效果.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk3D_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            // Show as 3D
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = chk.Checked;

        }



        /// <summary>
        /// Doughnut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoughnut_Click(object sender, EventArgs e)
        {
            // Set Doughnut chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;
        }


        /// <summary>
        /// Pie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPie_Click(object sender, EventArgs e)
        {
            // Set Doughnut chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
        }









    }
}
