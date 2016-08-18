using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using System.Diagnostics;


namespace W0300_WCF_Ajax.lazyload
{

    /// <summary>
    /// 模拟一个长时间加载的图片.
    /// </summary>
    public partial class LongTimeImage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            // 用于显示的数字.
            string number = Request["NO"];

            if (String.IsNullOrEmpty(number))
            {
                number = "123456"; 
            }


            // 定义图片大小.
            System.Drawing.Bitmap image =
                new System.Drawing.Bitmap(400, 200);

            Graphics g = Graphics.FromImage(image);

            // 字体.
            Font codeFont = new System.Drawing.Font("Vijaya", 32, (System.Drawing.FontStyle.Bold));

            LinearGradientBrush brush =
                new LinearGradientBrush(
                    new Rectangle(0, 0, image.Width, image.Height),
                        Color.Blue, Color.White, 1.2f, true);

            g.DrawString(number, codeFont, brush, 20, 20);


            // 用于模拟图片长时间下载.
            Thread.Sleep(2500);


            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());

        }



    }
}