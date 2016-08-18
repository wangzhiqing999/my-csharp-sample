using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO.Compression;

using log4net;


namespace W1030_MVC_ActionFilter.ActionFilters
{


    /// <summary>
    /// 用于压缩的 Filter.
    /// </summary>
    public class CompressFilter : ActionFilterAttribute
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);





        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 是否允许压缩处理.
            bool allowCompression = false;

            // 从系统的 Web.config 中读取配置信息.
            bool.TryParse(ConfigurationManager.AppSettings["Compression"], out allowCompression);


            if (allowCompression)
            {
                HttpRequestBase request = filterContext.HttpContext.Request;
                string acceptEncoding = request.Headers["Accept-Encoding"];
                if (string.IsNullOrEmpty(acceptEncoding)) return;
                acceptEncoding = acceptEncoding.ToUpperInvariant();
                HttpResponseBase response = filterContext.HttpContext.Response;


                if (acceptEncoding.Contains("GZIP"))
                {

                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug("使用 GZIP 压缩！");
                    }

                    response.AppendHeader("Content-encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                }
                else if (acceptEncoding.Contains("DEFLATE"))
                {

                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug("使用 DEFLATE 压缩！");
                    }

                    response.AppendHeader("Content-encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
            }


        }
    }


}