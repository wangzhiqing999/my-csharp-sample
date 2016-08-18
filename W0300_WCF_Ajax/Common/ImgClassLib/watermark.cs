using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.IO;
using System.Drawing;


namespace W0300_WCF_Ajax.Common.ImgClassLib
{
    /// <summary>
    /// 图片处理:水印图片
    /// </summary>
    public partial class ImageDealLib
    {
        /// <summary>
        /// 水印图片
        /// 【如果图片需要缩略,请使用skeletonize.Resizepic()方法对图片进行缩略】
        /// 返回图片虚拟路径,和一个警告信息,可根据此信息获取图片合成信息
        /// </summary>
        /// <param name="picpath">需要水印的图片路径</param>
        /// <param name="waterspath">水印图片路径</param>
        /// <param name="watermodel">水印模式</param>
        /// <param name="spath">文件保存路径</param>
        /// <param name="imgtype">保存文件类型</param>
        /// <param name="filecache">原文件处理方式</param>
        /// <param name="warning">处理警告信息</param>
        /// <returns>错误,返回错误信息;成功,返回图片路径</returns>

        public static string makewatermark(string picpath, string waterspath, WaterType watermodel, string spath, ImageType imgtype, FileCache filecache, out string warning)
        {
            #region
            //反馈信息
            System.Text.StringBuilder checkmessage = new System.Text.StringBuilder();

            //检测源文件
            string _sourceimg_common_mappath = "";
            bool checkfile = false;

            //检测水印源文件
            string _sourceimg_water_mappath = "";
            bool checkfilewater = false;

            checkfile = FileExistMapPath(picpath, FileCheckModel.C, out _sourceimg_common_mappath);
            checkfilewater = FileExistMapPath(waterspath, FileCheckModel.C, out _sourceimg_water_mappath);

            System.Drawing.Image _sourceimg_common = null;
            System.Drawing.Image _sourceimg_water = null;

            if (checkfile == true)
            {
                //从指定源文件,创建image对象
                _sourceimg_common = System.Drawing.Image.FromFile(_sourceimg_common_mappath);
            }
            else
            {
                checkmessage.Append("error:找不到需要的水印图片!" + picpath + ";");
            }
            if (checkfilewater == true)
            {
                //从指定源文件,创建image对象
                _sourceimg_water = System.Drawing.Image.FromFile(_sourceimg_water_mappath);
            }
            else
            {
                checkmessage.Append("error:找不到需要水印图片!" + waterspath + ";");
            }
            #endregion

            #region
            if (string.IsNullOrEmpty(checkmessage.ToString()))
            {
                //源图宽、高
                int _sourceimg_common_width = _sourceimg_common.Width;
                int _sourceimg_common_height = _sourceimg_common.Height;

                //水印图片宽、高
                int _sourceimg_water_width = _sourceimg_water.Width;
                int _sourceimg_water_height = _sourceimg_water.Height;

                #region 水印坐标
                //水印坐标
                int _sourceimg_water_point_x = 0;
                int _sourceimg_water_point_y = 0;

                switch (watermodel)
                {
                    case WaterType.Center:
                        _sourceimg_water_point_x = (_sourceimg_common_width - _sourceimg_water_width) / 2;
                        _sourceimg_water_point_y = (_sourceimg_common_height - _sourceimg_water_height) / 2;
                        ; break;
                    case WaterType.CenterDown:
                        _sourceimg_water_point_x = (_sourceimg_common_width - _sourceimg_water_width) / 2;
                        _sourceimg_water_point_y = _sourceimg_common_height - _sourceimg_water_height;
                        ; break;
                    case WaterType.CenterUp:
                        _sourceimg_water_point_x = (_sourceimg_common_width - _sourceimg_water_width) / 2;
                        _sourceimg_water_point_y = 0;
                        ; break;
                    case WaterType.LeftDown:
                        _sourceimg_water_point_x = 0;
                        _sourceimg_water_point_y = _sourceimg_common_height - _sourceimg_water_height;
                        ; break;
                    case WaterType.LeftUp:
                        ; break;
                    case WaterType.Random:
                        Random r = new Random();
                        int x_random = r.Next(0, _sourceimg_common_width);
                        int y_random = r.Next(0, _sourceimg_common_height);

                        _sourceimg_water_point_x = x_random > (_sourceimg_common_width - _sourceimg_water_width)
                            ? _sourceimg_common_width - _sourceimg_water_width : x_random;

                        _sourceimg_water_point_y = y_random > (_sourceimg_common_height - _sourceimg_water_height)
                            ? _sourceimg_common_height - _sourceimg_water_height : y_random;

                        ; break;
                    case WaterType.RightDown:
                        _sourceimg_water_point_x = _sourceimg_common_width - _sourceimg_water_width;
                        _sourceimg_water_point_y = _sourceimg_common_height - _sourceimg_water_height;
                        ; break;
                    case WaterType.RightUp:
                        _sourceimg_water_point_x = _sourceimg_common_width - _sourceimg_water_width;
                        _sourceimg_water_point_y = 0;
                        ; break;
                }
                #endregion

                //从源图创建画板
                System.Drawing.Graphics _g_common = Graphics.FromImage(_sourceimg_common);

                //设置画笔
                _g_common.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                _g_common.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                _g_common.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                //绘制水印图片
                _g_common.DrawImage(_sourceimg_water, new Rectangle(_sourceimg_water_point_x, _sourceimg_water_point_y, _sourceimg_water_width, _sourceimg_water_height), new Rectangle(0, 0, _sourceimg_water_width, _sourceimg_water_height), GraphicsUnit.Pixel);

                //保存图片
                string _spath_common_mappath = "";
                //全局文件名

                //获取图片类型的hashcode值,生成图片后缀名
                int extro = imgtype.GetHashCode();
                string extend = extro == 0 ? ".jpg" : (extro == 1 ? ".gif" : (extro == 2 ? ".png" : ".jpg"));

                spath = spath + Guid.NewGuid().ToString() + extend;

                FileExistMapPath(spath, FileCheckModel.M, out _spath_common_mappath);

                switch (imgtype)
                {
                    case ImageType.JPEG: _sourceimg_common.Save(_spath_common_mappath, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case ImageType.GIF: _sourceimg_common.Save(_spath_common_mappath, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case ImageType.PNG: _sourceimg_common.Save(_spath_common_mappath, System.Drawing.Imaging.ImageFormat.Png); break;
                }


                //释放
                _sourceimg_common.Dispose();
                _sourceimg_water.Dispose();
                _g_common.Dispose();

                //处理原文件
                int filecachecode = filecache.GetHashCode();
                //删除原文件
                if (filecachecode == 1)
                {
                    System.IO.File.Delete(_sourceimg_common_mappath);
                }

                warning = "";
                return spath;

            }
            #endregion

            //释放
            if (_sourceimg_common != null)
            {
                _sourceimg_common.Dispose();
            }
            if (_sourceimg_water != null)
            {
                _sourceimg_water.Dispose();
            }

            warning = checkmessage.ToString().TrimEnd(';');
            return "";
        }
    }
}