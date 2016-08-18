using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Mvc;
using System.IO;
using System.Security.Cryptography;



namespace W1030_MVC_ActionFilter.ActionFilters
{


    /// <summary>
    /// ETag Filter.
    /// 
    /// 该 Filter 把网站内容的 内容， 计算 MD5. 来生成一个  ETag.
    /// 
    /// 
    /// 如果客户端发送过来的数据， ETag  与 本次计算的 ETag 数据一致， 那么， 将不发送内容回去，而是简单 设置 StatusCode = 304;
    /// 
    /// 
    /// 注意： 这个 Filter， 处理机制， 是简单 判断  内容的  MD5。   
    /// 
    /// 也就是说， 如果 目标 Action， 是一个查询大量数据的操作。 该 Filter 要等 数据查询完毕后， 判断， 是不是把 网页结果， 发给客户端。
    /// 
    /// 
    /// 该 Filter 一定程度上， 能降低网络的开销。
    /// 
    /// </summary>
    public class ETagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Filter = new ETagFilter(filterContext.HttpContext.Response, filterContext.RequestContext.HttpContext.Request);
        }
    }

    public class ETagFilter : MemoryStream
    {
        private HttpResponseBase _response = null;
        private HttpRequestBase _request;
        private Stream _filter = null;
        public ETagFilter(HttpResponseBase response, HttpRequestBase request)
        {
            _response = response;
            _request = request;
            _filter = response.Filter;
        }


        /// <summary>
        /// 根据网页内容， 生成 MD5 字符串的处理.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private string GetToken(Stream stream)
        {
            var checksum = new byte[0];
            checksum = MD5.Create().ComputeHash(stream);
            return Convert.ToBase64String(checksum, 0, checksum.Length);
        }


        public override void Write(byte[] buffer, int offset, int count)
        {
            var data = new byte[count];
            Buffer.BlockCopy(buffer, offset, data, 0, count);

            // 计算本次内容的 MD5.
            var token = GetToken(new MemoryStream(data));

            // 获取客户端发送过来的 If-None-Match.
            var clientToken = _request.Headers["If-None-Match"];


            if (token != clientToken)
            {
                // If-None-Match 不一致的情况下， 设置 ETag， 并 将网页内容， 发送给客户端.
                _response.AddHeader("ETag", token);
                _filter.Write(data, 0, count);
            }
            else
            {
                // If-None-Match  一致的情况下， 设置 StatusCode = 304， 告诉客户端，客户端那里的内容，已经是最新的了，返回空白内容。
                _response.SuppressContent = true;
                _response.StatusCode = 304;
                _response.StatusDescription = "Not Modified";
                _response.AddHeader("Content-Length", "0");
            }
        }
    }


}
