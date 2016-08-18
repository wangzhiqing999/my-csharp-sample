using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using System.IO;

namespace W0300_WCF_Ajax.Common.ImgClassLib
{
    /// <summary>
    /// 图片处理:缩略图片
    /// </summary>
    public partial class ImageDealLib
    {

        /// <summary>
        /// 根据指定：缩略宽、高,缩略图片并保存
        /// 返回图片虚拟路径,和一个警告信息,可根据此信息获取图片合成信息
        /// </summary>
        /// <param name="picpath">原图路径</param>
        /// <param name="model">缩略模式[X,Y,XY](默认XY模式)</param>
        /// <param name="spath">文件保存路径(默认跟路径)</param>
        /// <param name="imgtype">图片保存类型</param>
        /// <param name="mwidth">缩略宽度(默认原图高度)</param>
        /// <param name="mheight">缩略高度(默认原图高度)</param>
        /// <param name="filecache">原文件处理方式</param>
        /// <param name="warning">处理警告信息</param>
        /// <returns>错误,返回错误信息;成功,返回图片路径</returns>

        public static string Resizepic(string picpath, ResizeType model, string spath, ImageType imgtype, double? mwidth, double? mheight, FileCache filecache, out string warning)
        {
            //反馈信息
            System.Text.StringBuilder checkmessage = new System.Text.StringBuilder();

            //文件保存路径
            spath = string.IsNullOrEmpty(spath) ? "/" : spath;

            //缩略宽度
            double swidth = mwidth.HasValue ? double.Parse(mwidth.ToString()) : 0;

            //缩略高度
            double sheight = mheight.HasValue ? double.Parse(mheight.ToString()) : 0;

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

                #region 缩略模式
                //缩略模式
                switch (model)
                {
                    case ResizeType.X:

                        #region X模式

                        //根据给定尺寸,获取绘制比例
                        double _width_scale = swidth / _sourceimg_common.Width;
                        //高着比例
                        sheight = _sourceimg_common.Height * _width_scale;

                        #endregion
                        ; break;
                    case ResizeType.Y:
                        #region Y模式

                        //根据给定尺寸,获取绘制比例
                        double _height_scale = sheight / _sourceimg_common.Height;
                        //宽着比例
                        swidth = _sourceimg_common.Width * _height_scale;

                        #endregion
                        ; break;
                    case ResizeType.XY:
                        #region XY模式

                        //当选择XY模式时,mwidth,mheight为必须值
                        if (swidth < 0 || sheight < 0)
                        {
                            checkmessage.Append("error:XY模式,mwidth,mheight为必须值;");
                        }

                        #endregion
                        ; break;
                    default:

                        #region 默认XY模式

                        //当默认XY模式时,mwidth,mheight为必须值
                        if (swidth < 0 || sheight < 0)
                        {
                            checkmessage.Append("error:你当前未选择缩略模式,系统默认XY模式,mwidth,mheight为必须值;");
                        }

                        ; break;
                        #endregion
                }
                #endregion
            }
            else
            {
                checkmessage.Append("error:未能找到缩略原图片," + picpath + ";");
            }

            if (string.IsNullOrEmpty(checkmessage.ToString()))
            {
                //创建bitmap对象
                _currimg_common = new System.Drawing.Bitmap((int)swidth, (int)sheight);

                _g_common = Graphics.FromImage(_currimg_common);

                //设置画笔
                _g_common.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                _g_common.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                _g_common.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                //绘制图片
                _g_common.DrawImage(_sourceimg_common, new Rectangle(0, 0, (int)swidth, (int)sheight), new Rectangle(0, 0, _sourceimg_common.Width, _sourceimg_common.Height), GraphicsUnit.Pixel);

                //保存图片
                string _spath_common_mappath = "";

                //获取图片类型的hashcode值,生成图片后缀名
                int extro = imgtype.GetHashCode();

                string extend = extro == 0 ? ".jpg" : (extro == 1 ? ".gif" : (extro == 2 ? ".png" : ".jpg"));

                //全局文件名
                spath = spath + Guid.NewGuid().ToString() + extend;

                FileExistMapPath(spath, FileCheckModel.M, out _spath_common_mappath);

                switch (imgtype)
                {
                    case ImageType.JPEG: _currimg_common.Save(_spath_common_mappath, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case ImageType.GIF: _currimg_common.Save(_spath_common_mappath, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case ImageType.PNG: _currimg_common.Save(_spath_common_mappath, System.Drawing.Imaging.ImageFormat.Png); break;
                }

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

            //释放
            if (_sourceimg_common != null)
            {
                _sourceimg_common.Dispose();
            }
            if (_currimg_common != null)
            {
                _currimg_common.Dispose();
            }
            if (_g_common != null)
            {
                _g_common.Dispose();
            }

            warning = checkmessage.ToString().TrimEnd(';');

            return "";
        }
    }
}