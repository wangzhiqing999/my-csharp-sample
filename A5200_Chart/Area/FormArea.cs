using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;


namespace A5200_Chart.Area
{
    public partial class FormArea : Form
    {
        public FormArea()
        {
            InitializeComponent();
        }



        private void FormArea_Load(object sender, EventArgs e)
        {


            // Add data
            chart1.Series["Series1"].Points.AddY(8.1);
            chart1.Series["Series1"].Points.AddY(7.6);
            chart1.Series["Series1"].Points.AddY(9.5);
            chart1.Series["Series1"].Points.AddY(8.5);
            chart1.Series["Series1"].Points.AddY(9.0);
            chart1.Series["Series1"].Points.AddY(8.0);

            chart1.Series["Series2"].Points.AddY(2.3);
            chart1.Series["Series2"].Points.AddY(4.2);
            chart1.Series["Series2"].Points.AddY(3.6);
            chart1.Series["Series2"].Points.AddY(2.3);
            chart1.Series["Series2"].Points.AddY(1.6);
            chart1.Series["Series2"].Points.AddY(2.9);



            // Set SplineArea chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedArea100;
            chart1.Series["Series2"].ChartType = SeriesChartType.StackedArea100;



            // Set spline line tension 
            chart1.Series["Series1"]["LineTension"] = "0.6";
            chart1.Series["Series2"]["LineTension"] = "0.6";


            // Enable data points labels
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series2"].IsValueShownAsLabel = true;







            // Disable X axis margin
            chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;

            // Show as 3D
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = true;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 30;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;


        }





        /// <summary>
        /// StackedArea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStackedArea_Click(object sender, EventArgs e)
        {
            // Set chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedArea;
            chart1.Series["Series2"].ChartType = SeriesChartType.StackedArea;
        }



        /// <summary>
        /// Area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArea_Click(object sender, EventArgs e)
        {
            // Set chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Area;
            chart1.Series["Series2"].ChartType = SeriesChartType.Area;
        }



        /// <summary>
        /// SplineArea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSplineArea_Click(object sender, EventArgs e)
        {
            // Set chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Series2"].ChartType = SeriesChartType.SplineArea;
        }



        /// <summary>
        /// StackedArea100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStackedArea100_Click(object sender, EventArgs e)
        {
            // Set chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedArea100;
            chart1.Series["Series2"].ChartType = SeriesChartType.StackedArea100;
        }





        /// <summary>
        /// 3D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk3D_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            // Show as 3D
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = chk.Checked; 
        }






    }
}
