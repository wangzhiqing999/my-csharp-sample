using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Drawing;
using System.Drawing.Imaging;



namespace A1070_Image_Process.Sample
{
    class TwoImageInOne
    {


        /// <summary>
        /// 两张图片， 合并成一张图片.
        /// 
        /// 结果图片， 为一上一下.
        /// </summary>
        public static void DoImageProc()
        {
            // 加载第一张图片.
            Image bmp1 = Bitmap.FromFile("Chrysanthemum.jpg");

            // 加载第二张图片.
            Image bmp2 = Bitmap.FromFile("Desert.jpg");

            // 新的图片大小， 宽度为 两张种较大的一张，  高度为 两张之和.
            Bitmap newBmp = new Bitmap(Math.Max(bmp1.Width, bmp2.Width), bmp1.Height + bmp2.Height);

            // 结果图像绘图.
            Graphics g = Graphics.FromImage(newBmp);

            // 绘制第一张.
            g.DrawImage(bmp1, 0, 0);

            // 绘制第二张.
            g.DrawImage(bmp2, 0, bmp1.Height);

            // 存储处理结果.
            newBmp.Save("result.jpg", ImageFormat.Jpeg);
        }

    }
}
