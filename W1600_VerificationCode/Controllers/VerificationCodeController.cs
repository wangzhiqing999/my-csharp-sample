using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


using AnimatedGif;


namespace W1600_VerificationCode.Controllers
{
    public class VerificationCodeController : Controller
    {
        // GET: VerificationCode
        public ActionResult Index()
        {
            return View();
        }





        /// <summary>
        /// 简单的验证码处理.
        /// </summary>
        /// <returns></returns>
        public ActionResult Simple()
        {
            //创建验证码的图片
            using (Bitmap image = GetValidateImage("123456"))
            {
                // 图片数据
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, ImageFormat.Jpeg);

                    byte[] bytes = stream.ToArray();

                    // 最后将验证码图片返回
                    return File(bytes, @"image/jpeg");
                }
            }            
        }




        public ActionResult Gif()
        {
            using (Bitmap image = GetValidateImage("123456"))
            {
                List<Bitmap> imageList = GetClearImageList(image);

                // 注意： 这里是测试，因此写个固定的文件名.
                // 实际环境下， 需要生成唯一的文件名，并定期清理.
                string webFileName = "/Output/test.gif";
                string fileName = Server.MapPath(webFileName);

                using (AnimatedGifCreator gifCreator = AnimatedGif.AnimatedGif.Create(fileName, 300))
                {
                    //Enumerate through a List<System.Drawing.Image> or List<System.Drawing.Bitmap> for example
                    foreach (Image img in imageList)
                    {
                        using (img)
                        {
                            //Add the image to gifEncoder with default Quality
                            gifCreator.AddFrame(img, GifQuality.Default);
                        } //Image disposed
                    }
                } // gifCreator.Finish and gifCreator.Dispose is called here


                return File(webFileName, @"image/gif");
            
            }

        }




        private Bitmap GetValidateImage(string validateCode, int lineCount = 25, int pointCount = 100)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 24.0), 48);
            using (Graphics g = Graphics.FromImage(image))
            {
                //生成随机生成器
                Random random = new Random();

                //清空图片背景色
                g.Clear(Color.White);

                Pen[] penArray = new Pen[] { 
                    new Pen(Color.Silver), 
                    new Pen(Color.AliceBlue), 
                    new Pen(Color.DarkCyan), 
                    new Pen(Color.DarkViolet), 
                    new Pen(Color.Ivory), 
                };



                //画图片的干扰线
                for (int i = 0; i < lineCount; i++)
                {
                    int x1 = random.Next(image.Width / 2);
                    int x2 = image.Width / 2 + random.Next(image.Width / 2);

                    int y1 = random.Next(image.Height / 2);
                    int y2 = image.Height / 2 + random.Next(image.Height / 2);


                    g.DrawLine(penArray[i % penArray.Length], x1, y1, x2, y2);
                    g.DrawLine(penArray[i % penArray.Length], x1 + 1, y1, x2 + 1, y2);

                    g.DrawLine(penArray[i % penArray.Length], x2, y1, x1, y2);
                    g.DrawLine(penArray[i % penArray.Length], x2 + 1, y1, x1 + 1, y2);
                }



                Font font = new Font("Arial", 24, FontStyle.Italic);

                LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);

                g.DrawString(validateCode, font, brush, 6, 6);


                //画图片的前景干扰点
                for (int i = 0; i < pointCount; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));

                }

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                return image;
            }         
        }



        private Bitmap ClearImage(Bitmap sourceImage, int count = 5, int index = 0)
        {
            Bitmap image = new Bitmap(sourceImage);

            using (Graphics g = Graphics.FromImage(image))
            {

                // 每一个单元的大小.
                int oneSize = image.Width / count;

                // 清空画面区域
                g.FillRectangle(new SolidBrush(Color.White), index * oneSize, 0, oneSize, image.Height);

            }

            return image;
        }


        private List<Bitmap> GetClearImageList(Bitmap sourceImage, int count = 5)
        {
            List<Bitmap> resultList = new List<Bitmap>();
            for (int i = 0; i < count; i++)
            {
                var oneImage = ClearImage(sourceImage, count, i);
                resultList.Add(oneImage);
            }

            // 随机排序.
            var query =
                from data in resultList
                orderby Guid.NewGuid()
                select data;
            resultList = query.ToList();

            return resultList;
        }

    }
}