using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;



namespace A5200_Chart.Circular
{
    public partial class FormRadar : Form
    {
        public FormRadar()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCircular_Load(object sender, EventArgs e)
        {
            // Populate series data
            double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42, 55.9, 63.6, 55.2, 77.1 };
            string[] xValues = { "France", "Canada", "Germany", "USA", "Italy", "Spain", "Russia", "Sweden", "Japan" };

            chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);

            // Set radar chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Radar;

            // Set radar chart style (Area, Line or Marker)
            chart1.Series["Series1"]["RadarDrawingStyle"] = "Area";

            // Set circular area drawing style (Circle or Polygon)
            chart1.Series["Series1"]["AreaDrawingStyle"] = "Polygon";

            // Set labels style (Auto, Horizontal, Circular or Radial)
            chart1.Series["Series1"]["CircularLabelsStyle"] = "Horizontal";



            // Show as 3D
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
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





        /// <summary>
        /// RadarDrawingStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboRadarDrawingStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            // Set radar chart style (Area, Line or Marker)
            chart1.Series["Series1"]["RadarDrawingStyle"] = cbo.Text;
        }



        /// <summary>
        /// AreaDrawingStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAreaDrawingStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            // Set circular area drawing style (Circle or Polygon)
            chart1.Series["Series1"]["AreaDrawingStyle"] = cbo.Text;
        }


        /// <summary>
        /// CircularLabelsStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCircularLabelsStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            // Set labels style (Auto, Horizontal, Circular or Radial)
            chart1.Series["Series1"]["CircularLabelsStyle"] = cbo.Text;
        }







    }
}
