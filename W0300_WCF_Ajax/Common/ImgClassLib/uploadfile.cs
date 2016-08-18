using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace W0300_WCF_Ajax.Common.ImgClassLib
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public partial class ImageDealLib
    {
        /// <summary>
        /// 使用流方式,上传并保存文件
        /// </summary>
        /// <param name="s">文件流</param>
        /// <param name="savepath">保存文件路径</param>
        /// <param name="warning">处理警告信息,若为空,则处理成功</param>
        /// <returns>返回文件保存完整路径</returns>
        public static string uploadbystream(Stream s, string savepath, out string warning)
        {
            int be = 0;
            if (s.Length > 0)
            {
                MemoryStream ms = new MemoryStream();

                while ((be = s.ReadByte()) != -1)
                {
                    ms.WriteByte((byte)be);
                }

                string newpath = savepath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";

                string lastpath = "";

                FileExistMapPath(newpath, FileCheckModel.M, out lastpath);

                FileStream fs = new FileStream(lastpath, FileMode.Create);

                ms.WriteTo(fs);

                //释放
                ms.Dispose();
                fs.Dispose();

                warning = "";
                return newpath;
            }

            warning = "error";
            return "";
        }
    }
}