using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Windows.Forms.DataVisualization.Charting;


namespace A5200_Chart.Line
{
    public partial class FormChartLine : Form
    {


        public FormChartLine()
        {
            InitializeComponent();
        }




        private void FormChartLine_Load(object sender, EventArgs e)
        {


            // 向图表， 填写随机数据.
            // Populate series with random data
            Random	random = new Random();
            for(int pointIndex = 0; pointIndex < 10; pointIndex++)
            {
                chart1.Series["Series1"].Points.AddY(random.Next(45, 95));
                chart1.Series["Series2"].Points.AddY(random.Next(5, 75));
            }


            // 图表类型.
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.Series["Series2"].ChartType = SeriesChartType.Spline;



            // 显示数字
            // Set point labels
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series2"].IsValueShownAsLabel = false;




            // Enable X axis margin
            chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = true;




            // Show as 3D
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = false;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 40;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 20;
            chart1.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Realistic;




        }



        /// <summary>
        /// FastLine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFastLine_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Series2"].ChartType = SeriesChartType.FastLine;
        }



        /// <summary>
        /// Line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLine_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.Series["Series2"].ChartType = SeriesChartType.Line;
        }


        /// <summary>
        /// Spline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpline_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Spline;
            chart1.Series["Series2"].ChartType = SeriesChartType.Spline;
        }



        /// <summary>
        /// StepLine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStepline_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.StepLine;
            chart1.Series["Series2"].ChartType = SeriesChartType.StepLine;

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









    }
}
