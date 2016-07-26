using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;



namespace A5200_Chart.PyramidFunnel
{
    public partial class FormPyramidFunnel : Form
    {
        public FormPyramidFunnel()
        {
            InitializeComponent();
        }



        private void FormPyramidFunnel_Load(object sender, EventArgs e)
        {

            // Populate series data
            double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42 };
            string[] xValues = { "France", "Canada", "Germany", "USA", "Italy" };
            chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);



            // Set funnel chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Pyramid;

            // Set funnel Y values style
            chart1.Series["Series1"]["FunnelStyle"] = "YIsHeight";

            // Set funnel data point labels style
            chart1.Series["Series1"]["FunnelLabelStyle"] = "Outside";

            // Place labels on the left side
            chart1.Series["Series1"]["FunnelOutsideLabelPlacement"] = "Left";

            // Set gap between points
            chart1.Series["Series1"]["FunnelPointGap"] = "2";

            // Set minimum point height
            chart1.Series["Series1"]["FunnelMinPointHeight"] = "1";

            
            // Set 3D angle
            chart1.Series["Series1"]["Funnel3DRotationAngle"] = "7";

            // Set 3D drawing style
            chart1.Series["Series1"]["Funnel3DDrawingStyle"] = "CircularBase";




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
        /// Funnel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFunnel_Click(object sender, EventArgs e)
        {
            // Set funnel chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Funnel;
        }


        /// <summary>
        /// Pyramid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPyramid_Click(object sender, EventArgs e)
        {
            // Set funnel chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Pyramid;
        }



    }
}
