using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace W0300_WCF_Ajax.Common.ImgClassLib
{

    /// <summary>
    /// 公用函数
    /// 
    /// http://www.cnblogs.com/hinton/archive/2012/03/01/2375465.html
    /// </summary>
    public partial class ImageDealLib
    {
        /// <summary>
        /// 根据文件路径判断文件是否存在
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="model">返回模式,m:返回map地址不检查文件是否存在,c:检测文件是否存在,并返回map地址</param>
        /// <param name="mappath">map路径</param>
        /// <returns></returns>
        public static bool FileExistMapPath(string filepath, FileCheckModel model, out string mappath)
        {
            bool checkresult = false;
            switch (model)
            {
                case FileCheckModel.M:
                    mappath = HttpContext.Current.Server.MapPath(filepath);
                    checkresult = true;
                    break;
                case FileCheckModel.C:
                    if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(filepath)))
                    {
                        mappath = HttpContext.Current.Server.MapPath(filepath);
                        checkresult = true;
                    }
                    else
                    {
                        mappath = null;
                        checkresult = false;
                    }
                    break;
                default:
                    mappath = "";
                    checkresult = false;
                    break;
            }
            return checkresult;
        }

        /// <summary>
        /// 图片保存类型
        /// JPEG:.jpg格式;
        /// GIF:.gif格式;
        /// PNG:.png格式;
        /// </summary>
        public enum ImageType
        {
            JPEG,
            GIF,
            PNG
        }

        /// <summary>
        /// 水印模式
        /// Center:中间;
        /// CenterUp:中上;
        /// CenterDown:中下;
        /// LeftUp:左上;
        /// LeftDown:左下;
        /// RightUp:右上;
        /// RightDown:右下;
        /// Random:随机;
        /// </summary>
        public enum WaterType 
        {
            Center,
            CenterUp,
            CenterDown,
            LeftUp,
            LeftDown,
            RightUp,
            RightDown,
            Random
        }

        /// <summary>
        /// 缩略模式
        /// X--按宽度缩放,高着宽比例;
        /// Y--按高度缩放,宽着宽比例;
        /// XY--按给定mwidth,mheight(此模式mwidth,mheight为必须值)进行缩略;
        /// </summary>
        public enum ResizeType 
        {
            X,
            Y,
            XY
        }

        /// <summary>
        /// 文件检测模式
        /// M:不检测文件是否存在,返回ServerMapPath;
        /// C:检测文件是否存在,返回ServerMapPath;
        /// </summary>
        public enum FileCheckModel 
        {
            M,
            C
        }

        /// <summary>
        /// 原图文件是否保存
        /// Delete:保存
        /// Save:不保存,删除
        /// </summary>
        public enum FileCache
        {
            Save,
            Delete
        }

    }
}