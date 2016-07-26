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
    public partial class FormPolar : Form
    {
        public FormPolar()
        {
            InitializeComponent();
        }



        private void FormPolar_Load(object sender, EventArgs e)
        {
            // Populate series data
            for (double angle = 0.0; angle <= 360.0; angle += 10.0)
            {
                double yValue = (1.0 + Math.Sin(angle / 180.0 * Math.PI)) * 10.0;
                chart1.Series["Series1"].Points.AddXY(angle, yValue);
            }

            // Set polar chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Polar;

            // Set polar chart style (Line or Marker)
            chart1.Series["Series1"]["PolarDrawingStyle"] = "Marker";

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
        /// PolarDrawingStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPolarDrawingStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            // Set polar chart style (Line or Marker)
            chart1.Series["Series1"]["PolarDrawingStyle"] = cbo.Text;
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
