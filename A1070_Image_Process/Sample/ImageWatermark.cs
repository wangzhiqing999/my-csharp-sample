using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace A1070_Image_Process.Sample
{

    /// <summary>
    /// 水印
    /// </summary>
    class ImageWatermark
    {




        public static void DoImageWatermark()
        {
            BuildWatermark("Chrysanthemum.jpg", "MarkImg.png", "测试水印文字", "WatermarkResult1.jpg");

            BuildWatermark("Desert.jpg", "MarkImg.png", "", "WatermarkResult2.jpg");
        }





        /// <summary>    
        /// Creating a Watermarked Photograph with GDI+ for .NET    
        /// </summary>    
        /// <param name="rSrcImgPath">原始图片的物理路径</param>    
        /// <param name="rMarkImgPath">水印图片的物理路径</param>    
        /// <param name="rMarkText">水印文字（不显示水印文字设为空串）</param>    
        /// <param name="rDstImgPath">输出合成后的图片的物理路径</param>    
        public static void BuildWatermark(string rSrcImgPath, string rMarkImgPath, string rMarkText, string rDstImgPath)
        {
            //以下（代码）从一个指定文件创建了一个Image 对象，然后为它的 Width 和 Height定义变量。    
            //这些长度待会被用来建立一个以24 bits 每像素的格式作为颜色数据的Bitmap对象。    
            Image imgPhoto = Image.FromFile(rSrcImgPath);
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);


            //这个代码载入水印图片，水印图片已经被保存为一个BMP文件，以绿色(A=0,R=0,G=255,B=0)作为背景颜色。    
            //再一次，会为它的Width 和Height定义一个变量。    
            Image imgWatermark = new Bitmap(rMarkImgPath);
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;


            //这个代码以100%它的原始大小绘制imgPhoto 到Graphics 对象的（x=0,y=0）位置。    
            //以后所有的绘图都将发生在原来照片的顶部。    
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.DrawImage(
                 imgPhoto,
                 new Rectangle(0, 0, phWidth, phHeight),
                 0,
                 0,
                 phWidth,
                 phHeight,
                 GraphicsUnit.Pixel);


            //为了最大化版权信息的大小，我们将测试7种不同的字体大小来决定我们能为我们的照片宽度使用的可能的最大大小。    
            //为了有效地完成这个，我们将定义一个整型数组，接着遍历这些整型值测量不同大小的版权字符串。    
            //一旦我们决定了可能的最大大小，我们就退出循环，绘制文本    
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < 7; i++)
            {
                crFont = new Font("arial", sizes[i],
                      FontStyle.Bold);
                crSize = grPhoto.MeasureString(rMarkText,
                      crFont);
                if ((ushort)crSize.Width < (ushort)phWidth)
                    break;
            }


            //因为所有的照片都有各种各样的高度，所以就决定了从图象底部开始的5%的位置开始。    
            //使用rMarkText字符串的高度来决定绘制字符串合适的Y坐标轴。    
            //通过计算图像的中心来决定X轴，然后定义一个StringFormat 对象，设置StringAlignment 为Center。    
            int yPixlesFromBottom = (int)(phHeight * .05);
            float yPosFromBottom = ((phHeight -
                 yPixlesFromBottom) - (crSize.Height / 2));
            float xCenterOfImg = (phWidth / 2);
            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;


            //现在我们已经有了所有所需的位置坐标来使用60%黑色的一个Color(alpha值153)创建一个SolidBrush 。    
            //在偏离右边1像素，底部1像素的合适位置绘制版权字符串。    
            //这段偏离将用来创建阴影效果。使用Brush重复这样一个过程，在前一个绘制的文本顶部绘制同样的文本。    
            SolidBrush semiTransBrush2 =
                 new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            grPhoto.DrawString(rMarkText,
                 crFont,
                 semiTransBrush2,
                 new PointF(xCenterOfImg + 1, yPosFromBottom + 1),
                 StrFormat);
            SolidBrush semiTransBrush = new SolidBrush(
                 Color.FromArgb(153, 255, 255, 255));
            grPhoto.DrawString(rMarkText,
                 crFont,
                 semiTransBrush,
                 new PointF(xCenterOfImg, yPosFromBottom),
                 StrFormat);


            //根据前面修改后的照片创建一个Bitmap。把这个Bitmap载入到一个新的Graphic对象。    
            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(
                 imgPhoto.HorizontalResolution,
                 imgPhoto.VerticalResolution);
            Graphics grWatermark =
                 Graphics.FromImage(bmWatermark);


            //通过定义一个ImageAttributes 对象并设置它的两个属性，我们就是实现了两个颜色的处理，以达到半透明的水印效果。    
            //处理水印图象的第一步是把背景图案变为透明的(Alpha=0, R=0, G=0, B=0)。我们使用一个Colormap 和定义一个RemapTable来做这个。    
            //就像前面展示的，我的水印被定义为100%绿色背景，我们将搜到这个颜色，然后取代为透明。    
            ImageAttributes imageAttributes =
                 new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };


            //第二个颜色处理用来改变水印的不透明性。    
            //通过应用包含提供了坐标的RGBA空间的5x5矩阵来做这个。    
            //通过设定第三行、第三列为0.3f我们就达到了一个不透明的水平。结果是水印会轻微地显示在图象底下一些。    
            imageAttributes.SetRemapTable(remapTable,
                 ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {     
                                             new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},    
                                             new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},    
                                             new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},    
                                             new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},    
                                             new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}    
                                        };
            ColorMatrix wmColorMatrix = new
                 ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(wmColorMatrix,
                 ColorMatrixFlag.Default,
                 ColorAdjustType.Bitmap);


            //随着两个颜色处理加入到imageAttributes 对象，我们现在就能在照片右手边上绘制水印了。    
            //我们会偏离10像素到底部，10像素到左边。    
            int markWidth;
            int markHeight;


            //mark比原来的图宽    
            if (phWidth <= wmWidth)
            {
                markWidth = phWidth - 10;
                markHeight = (markWidth * wmHeight) / wmWidth;
            }
            else if (phHeight <= wmHeight)
            {
                markHeight = phHeight - 10;
                markWidth = (markHeight * wmWidth) / wmHeight;
            }
            else
            {
                markWidth = wmWidth;
                markHeight = wmHeight;
            }


            //// 水印在右上角.
            //int xPosOfWm = ((phWidth - markWidth) - 10);
            //int yPosOfWm = 10;


            // 水印在左下角.
            int xPosOfWm = 10;
            int yPosOfWm = ((phHeight - markHeight) - 10);



            grWatermark.DrawImage(imgWatermark,
                 new Rectangle(xPosOfWm, yPosOfWm, markWidth,  markHeight),
                 0,
                 0,
                 wmWidth,
                 wmHeight,
                 GraphicsUnit.Pixel,
                 imageAttributes);


            //最后的步骤将是使用新的Bitmap取代原来的Image。 销毁两个Graphic对象，然后把Image 保存到文件系统。    
            imgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();
            imgPhoto.Save(rDstImgPath, ImageFormat.Jpeg);
            imgPhoto.Dispose();
            imgWatermark.Dispose();
        }


    }
}
