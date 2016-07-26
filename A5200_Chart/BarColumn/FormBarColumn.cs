using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;



namespace A5200_Chart.BarColumn
{
    public partial class FormBarColumn : Form
    {
        public FormBarColumn()
        {
            InitializeComponent();
        }



        private void FormBarColumn_Load(object sender, EventArgs e)
        {

            // Add data
            chart1.Series["Series1"].Points.AddY(8.1);
            chart1.Series["Series1"].Points.AddY(7.6);
            chart1.Series["Series1"].Points.AddY(9.5);
            chart1.Series["Series1"].Points.AddY(8.5);
            chart1.Series["Series1"].Points.AddY(9.0);
            chart1.Series["Series1"].Points.AddY(8.0);

            chart1.Series["Series2"].Points.AddY(-2.3);
            chart1.Series["Series2"].Points.AddY(4.2);
            chart1.Series["Series2"].Points.AddY(3.6);
            chart1.Series["Series2"].Points.AddY(2.3);
            chart1.Series["Series2"].Points.AddY(-1.6);
            chart1.Series["Series2"].Points.AddY(2.9);




            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
            chart1.Series["Series2"].ChartType = SeriesChartType.Bar;

            
            // Set series point width
            chart1.Series["Series1"]["PointWidth"] = "0.6";
            chart1.Series["Series2"]["PointWidth"] = "0.6";


            // Show data points labels
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series2"].IsValueShownAsLabel = true;


            // Set data points label style
            chart1.Series["Series1"]["BarLabelStyle"] = "Center";
            chart1.Series["Series2"]["BarLabelStyle"] = "Center";




            // Display chart as 3D
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

        }



        /// <summary>
        /// DrawingStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDrawingStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            chart1.Series["Series1"]["DrawingStyle"] = cbo.Text;
            chart1.Series["Series2"]["DrawingStyle"] = cbo.Text;
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
            chart1.ChartAreas[0].Area3DStyle.Enable3D = chk.Checked; 
        }




        /// <summary>
        /// Bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBar_Click(object sender, EventArgs e)
        {
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
            chart1.Series["Series2"].ChartType = SeriesChartType.Bar;
        }


        /// <summary>
        /// Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColumn_Click(object sender, EventArgs e)
        {
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            chart1.Series["Series2"].ChartType = SeriesChartType.Column;
        }


        /// <summary>
        /// StackedBar100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStackedBar100_Click(object sender, EventArgs e)
        {
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedBar100;
            chart1.Series["Series2"].ChartType = SeriesChartType.StackedBar100;
        }


        /// <summary>
        /// StackedColumn100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStackedColumn100_Click(object sender, EventArgs e)
        {
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedColumn100;
            chart1.Series["Series2"].ChartType = SeriesChartType.StackedColumn100;
        }



        /// <summary>
        /// StackedBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStackedBar_Click(object sender, EventArgs e)
        {
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedBar;
            chart1.Series["Series2"].ChartType = SeriesChartType.StackedBar;
        }


        /// <summary>
        /// StackedColumn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStackedColumn_Click(object sender, EventArgs e)
        {
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedColumn;
            chart1.Series["Series2"].ChartType = SeriesChartType.StackedColumn;
        }












    }
}
