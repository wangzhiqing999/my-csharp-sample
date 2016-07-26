using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5200_Chart.Financial
{
    public partial class FormStockPlus : Form
    {
        public FormStockPlus()
        {
            InitializeComponent();
        }

        private void FormStockPlus_Load(object sender, EventArgs e)
        {

            // 上涨时的颜色.
            chart1.Series["Series1"].SetCustomProperty("PriceUpColor", "Red");
            // 下跌时的颜色.
            chart1.Series["Series1"].SetCustomProperty("PriceDownColor", "Green");



            // 注意： 下面的设置很关键.
            // 因为默认情况下， y 轴坐标是从0开始的。
            // 而对于股价来说， 高的情况下， 上百也有， 如果 y 轴坐标从0开始， 那么画面中间，会出现一大块空白。
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chart1.ChartAreas[1].AxisY.IsStartedFromZero = false;




            FillData();
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


            chart1.Series["macd_dif"].Points.AddY(0.139);
            chart1.Series["macd_dif"].Points.AddY(0.175);
            chart1.Series["macd_dif"].Points.AddY(0.223);
            chart1.Series["macd_dif"].Points.AddY(0.297);
            chart1.Series["macd_dif"].Points.AddY(0.341);
            chart1.Series["macd_dif"].Points.AddY(0.355);
            chart1.Series["macd_dif"].Points.AddY(0.331);
            chart1.Series["macd_dif"].Points.AddY(0.288);
            chart1.Series["macd_dif"].Points.AddY(0.246);
            chart1.Series["macd_dif"].Points.AddY(0.224);
            chart1.Series["macd_dif"].Points.AddY(0.205);
            chart1.Series["macd_dif"].Points.AddY(0.195);
            chart1.Series["macd_dif"].Points.AddY(0.149);
            chart1.Series["macd_dif"].Points.AddY(0.109);
            chart1.Series["macd_dif"].Points.AddY(0.094);
            chart1.Series["macd_dif"].Points.AddY(0.081);


            chart1.Series["macd_dea"].Points.AddY(0.035);
            chart1.Series["macd_dea"].Points.AddY(0.063);
            chart1.Series["macd_dea"].Points.AddY(0.095);
            chart1.Series["macd_dea"].Points.AddY(0.135);
            chart1.Series["macd_dea"].Points.AddY(0.176);
            chart1.Series["macd_dea"].Points.AddY(0.212);
            chart1.Series["macd_dea"].Points.AddY(0.236);
            chart1.Series["macd_dea"].Points.AddY(0.246);
            chart1.Series["macd_dea"].Points.AddY(0.246);
            chart1.Series["macd_dea"].Points.AddY(0.242);
            chart1.Series["macd_dea"].Points.AddY(0.235);
            chart1.Series["macd_dea"].Points.AddY(0.227);
            chart1.Series["macd_dea"].Points.AddY(0.211);
            chart1.Series["macd_dea"].Points.AddY(0.191);
            chart1.Series["macd_dea"].Points.AddY(0.172);
            chart1.Series["macd_dea"].Points.AddY(0.154);



            chart1.Series["macd"].Points.AddY(0.208);
            chart1.Series["macd"].Points.AddY(0.224);
            chart1.Series["macd"].Points.AddY(0.256);
            chart1.Series["macd"].Points.AddY(0.324);
            chart1.Series["macd"].Points.AddY(0.330);
            chart1.Series["macd"].Points.AddY(0.286);
            chart1.Series["macd"].Points.AddY(0.190);
            chart1.Series["macd"].Points.AddY(0.084);
            chart1.Series["macd"].Points.AddY(0.000);
            chart1.Series["macd"].Points.AddY(-0.036);
            chart1.Series["macd"].Points.AddY(-0.060);
            chart1.Series["macd"].Points.AddY(-0.064);
            chart1.Series["macd"].Points.AddY(-0.124);
            chart1.Series["macd"].Points.AddY(-0.164);
            chart1.Series["macd"].Points.AddY(-0.156);
            chart1.Series["macd"].Points.AddY(-0.146);
        }



    }
}
