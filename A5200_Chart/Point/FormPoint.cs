using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;



namespace A5200_Chart.Point
{
    public partial class FormPoint : Form
    {
        public FormPoint()
        {
            InitializeComponent();
        }



        private void FormPoint_Load(object sender, EventArgs e)
        {
            // Populate series data with random data
            Random random = new Random();
            for (int pointIndex = 0; pointIndex < 10; pointIndex++)
            {
                chart1.Series["Series1"].Points.AddY(random.Next(5, 60));
            }

            // Set point chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.FastPoint;

            // Enable data points labels
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"]["LabelStyle"] = "Center";

            // Set marker size
            chart1.Series["Series1"].MarkerSize = 15;

            // Set marker shape
            chart1.Series["Series1"].MarkerStyle = MarkerStyle.Diamond;

            // Set to 3D
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
        /// FastPoint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFastPoint_Click(object sender, EventArgs e)
        {
            // Set point chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.FastPoint;
        }



        /// <summary>
        /// Point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPoint_Click(object sender, EventArgs e)
        {
            // Set point chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Point;
        }




        /// <summary>
        /// Bubble
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBubble_Click(object sender, EventArgs e)
        {
            // Set point chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Bubble;
        }


        /// <summary>
        /// MarkerStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMarkerStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;


            MarkerStyle data = (MarkerStyle)Enum.Parse(typeof(MarkerStyle), cbo.Text, true);

            // Set marker shape
            chart1.Series["Series1"].MarkerStyle = data;
        }







    }
}
