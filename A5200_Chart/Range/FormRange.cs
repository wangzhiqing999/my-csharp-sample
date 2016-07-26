using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;



namespace A5200_Chart.Range
{
    public partial class FormRange : Form
    {
        public FormRange()
        {
            InitializeComponent();
        }

        private void FormRange_Load(object sender, EventArgs e)
        {
            // Populate series data with data
            double[] yValue1 = { 56, 74, 45, 59, 34, 87, 50, 87, 64, 34 };
            double[] yValue2 = { 42, 65, 30, 42, 25, 47, 40, 70, 34, 20 };
            chart1.Series["Series1"].Points.DataBindY(yValue1, yValue2);

            // Set chart type 
            chart1.Series["Series1"].ChartType = SeriesChartType.SplineRange;

            // Set Spline Range line tension
            chart1.Series["Series1"]["LineTension"] = "0.5";

            // Enable the ShowMarkerLines
            chart1.Series["Series1"]["ShowMarkerLines"] = "true";


            // Disable X axis margin
            chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;

            // Enable 3D
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            // Set the lighting choice
            chart1.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Simplistic;

            // Set 10% Perspective
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 10;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = false;
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
        /// SplineRange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSplineRange_Click(object sender, EventArgs e)
        {
            // Set chart type 
            chart1.Series["Series1"].ChartType = SeriesChartType.SplineRange;
        }


        /// <summary>
        /// Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRange_Click(object sender, EventArgs e)
        {
            // Set chart type 
            chart1.Series["Series1"].ChartType = SeriesChartType.Range;
        }




        /// <summary>
        /// RangeBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRangeBar_Click(object sender, EventArgs e)
        {
            // Set chart type 
            chart1.Series["Series1"].ChartType = SeriesChartType.RangeBar;
        }


        /// <summary>
        /// RangeColumn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRangeColumn_Click(object sender, EventArgs e)
        {
            // Set chart type 
            chart1.Series["Series1"].ChartType = SeriesChartType.RangeColumn;
        }







    }
}
