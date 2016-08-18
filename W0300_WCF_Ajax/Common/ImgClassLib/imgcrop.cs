using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Drawing;


namespace W0300_WCF_Ajax.Common.ImgClassLib
{


    /// <summary>
    /// 图片剪辑
    /// </summary>
    public partial class ImageDealLib
    {
        public static string lastcroppic = "";//上一张已剪切生成的文件名

        public static string diffpicpath = "";//上一张要被剪切的原图地址

        /// <summary>
        /// 图片剪切
        /// </summary>
        /// <param name="picpath">源图片文件地址</param>
        /// <param name="spath">剪切临时文件地址</param>
        /// <param name="x1">x起始坐标</param>
        /// <param name="y1">y起始坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="filecache">源文件处理方式</param>
        /// <param name="warning">处理警告信息</param>
        /// <returns>剪切图片地址</returns>
        public static string imgcrop(string picpath, string spath, int x1, int y1, int width, int height, FileCache filecache, out string warning)
        {
            //反馈信息
            System.Text.StringBuilder checkmessage = new System.Text.StringBuilder();

            //从指定源图片,创建image对象
            string _sourceimg_common_mappath = "";

            //检测源文件
            bool checkfile = false;
            checkfile = FileExistMapPath(picpath, FileCheckModel.C, out _sourceimg_common_mappath);

            System.Drawing.Image _sourceimg_common = null;
            System.Drawing.Bitmap _currimg_common = null;
            System.Drawing.Graphics _g_common = null;

            if (checkfile == true)
            {
                //从源文件创建imgage
                _sourceimg_common = System.Drawing.Image.FromFile(_sourceimg_common_mappath);

                //从指定width、height创建bitmap对象
                _currimg_common = new System.Drawing.Bitmap(width, height);

                //从_currimg_common创建画笔
                _g_common = Graphics.FromImage(_currimg_common);

                //设置画笔
                _g_common.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                _g_common.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                _g_common.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                //绘制图片
                _g_common.DrawImage(_sourceimg_common, new Rectangle(0, 0, width, height), new Rectangle(x1, y1, width, height), GraphicsUnit.Pixel);

                //保存图片
                string _spath_common_mappath = "";

                //判断是否是对同一张图片进行剪切
                //判断是否，已更新剪切图片,防止覆盖上一张已完成剪切的图片
                spath = string.IsNullOrEmpty(lastcroppic) ? spath + Guid.NewGuid().ToString() + ".jpg" : (diffpicpath == picpath ? lastcroppic : spath + Guid.NewGuid().ToString() + ".jpg");

                lastcroppic = spath;
                diffpicpath = picpath;

                FileExistMapPath(spath, FileCheckModel.M, out _spath_common_mappath);

                _currimg_common.Save(_spath_common_mappath, System.Drawing.Imaging.ImageFormat.Jpeg);

                //释放
                _sourceimg_common.Dispose();
                _currimg_common.Dispose();
                _g_common.Dispose();

                //处理原文件
                int filecachecode = filecache.GetHashCode();

                //文件缓存方式:Delete,删除原文件
                if (filecachecode == 1)
                {
                    System.IO.File.Delete(_sourceimg_common_mappath);
                }

                //返回相对虚拟路径
                warning = "";
                return spath;
            }

            checkmessage.Append("error:未能找到剪切原图片;");

            warning = checkmessage.ToString().TrimEnd(';');

            return "";
        }
    }


}