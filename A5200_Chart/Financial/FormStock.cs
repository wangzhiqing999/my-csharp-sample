using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Windows.Forms.DataVisualization.Charting;


namespace A5200_Chart.Financial
{
    public partial class FormStock : Form
    {
        public FormStock()
        {
            InitializeComponent();
        }



        private void FormStock_Load(object sender, EventArgs e)
        {
            // Set series chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.Candlestick;

            FillData();

            
            
            // 仅仅是画线.
            /*
            StripLine sl1 = new StripLine();
            sl1.BackColor = System.Drawing.Color.Red;
            sl1.IntervalOffset = 1.25;
            sl1.StripWidth = 0.001;
            sl1.Text = "上限";
            sl1.TextAlignment = StringAlignment.Near;
            chart1.ChartAreas[0].AxisY.StripLines.Add(sl1);
             */



            // 仅仅是选择.
            // chart1.ChartAreas[0].CursorY.SetSelectionPosition(1.25, 5);


        }




        /// <summary>
        /// Random Stock Data Generator
        /// </summary>
        private void FillData()
        {
            // 4个参数： (分別是最高、最低、開盤和收盤)。
            chart1.Series["Series1"].Points.AddY(2.655, 2.316, 2.580, 2.367);
            chart1.Series["Series1"].Points.AddY(2.465, 2.270, 2.301, 2.438);
            chart1.Series["Series1"].Points.AddY(2.815, 2.289, 2.456, 2.707);
            chart1.Series["Series1"].Points.AddY(3.307, 2.704, 2.713, 3.198);
            chart1.Series["Series1"].Points.AddY(3.351, 2.940, 3.200, 3.066);
            chart1.Series["Series1"].Points.AddY(3.465, 2.481, 3.066, 2.851);
            chart1.Series["Series1"].Points.AddY(3.010, 2.406, 2.810, 2.462);
            chart1.Series["Series1"].Points.AddY(2.630, 1.869, 2.440, 2.209);
            chart1.Series["Series1"].Points.AddY(2.285, 2.085, 2.152, 2.147);
            chart1.Series["Series1"].Points.AddY(2.385, 2.193, 2.241, 2.310);
            chart1.Series["Series1"].Points.AddY(2.589, 2.264, 2.291, 2.329);
            chart1.Series["Series1"].Points.AddY(2.545, 2.309, 2.330, 2.416);
            chart1.Series["Series1"].Points.AddY(2.413, 1.906, 2.411, 1.975);
            chart1.Series["Series1"].Points.AddY(2.065, 1.890, 1.974, 1.937);
            chart1.Series["Series1"].Points.AddY(2.215, 1.929, 1.940, 2.156);
            chart1.Series["Series1"].Points.AddY(2.197, 2.093, 2.152, 2.156);



            chart1.Series["Ma5"].Points.AddY(2.023);
            chart1.Series["Ma5"].Points.AddY(2.186);
            chart1.Series["Ma5"].Points.AddY(2.395);
            chart1.Series["Ma5"].Points.AddY(2.652);
            chart1.Series["Ma5"].Points.AddY(2.755);
            chart1.Series["Ma5"].Points.AddY(2.852);
            chart1.Series["Ma5"].Points.AddY(2.857);
            chart1.Series["Ma5"].Points.AddY(2.757);
            chart1.Series["Ma5"].Points.AddY(2.547);
            chart1.Series["Ma5"].Points.AddY(2.396);
            chart1.Series["Ma5"].Points.AddY(2.291);
            chart1.Series["Ma5"].Points.AddY(2.282);
            chart1.Series["Ma5"].Points.AddY(2.235);
            chart1.Series["Ma5"].Points.AddY(2.193);
            chart1.Series["Ma5"].Points.AddY(2.163);
            chart1.Series["Ma5"].Points.AddY(2.128);


            chart1.Series["Ma10"].Points.AddY(1.766);
            chart1.Series["Ma10"].Points.AddY(1.865);
            chart1.Series["Ma10"].Points.AddY(1.992);
            chart1.Series["Ma10"].Points.AddY(2.166);
            chart1.Series["Ma10"].Points.AddY(2.311);
            chart1.Series["Ma10"].Points.AddY(2.438);
            chart1.Series["Ma10"].Points.AddY(2.522);
            chart1.Series["Ma10"].Points.AddY(2.576);
            chart1.Series["Ma10"].Points.AddY(2.600);
            chart1.Series["Ma10"].Points.AddY(2.576);
            chart1.Series["Ma10"].Points.AddY(2.572);
            chart1.Series["Ma10"].Points.AddY(2.570);
            chart1.Series["Ma10"].Points.AddY(2.496);
            chart1.Series["Ma10"].Points.AddY(2.370);
            chart1.Series["Ma10"].Points.AddY(2.279);
            chart1.Series["Ma10"].Points.AddY(2.210);



        }



        /// <summary>
        /// 保存为图片.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            chart1.SaveImage("test.jpg", ChartImageFormat.Jpeg);

            MessageBox.Show("Save OK!");
        }


    }
}
