using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;




namespace W1030_MVC_ActionFilter.ActionFilters
{

    /// <summary>
    /// 用于去掉空格的 Filter.
    /// </summary>
    public class WhitespaceFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            // If it's a sitemap, just return.
            if (filterContext.HttpContext.Request.RawUrl == "/sitemap.xml") return;

            if (response.ContentType != "text/html" || response.Filter == null) return;

            response.Filter = new HelperClass(response.Filter);
        }



        private class HelperClass : Stream
        {
            private readonly Stream _base;
            StringBuilder _s = new StringBuilder();

            public HelperClass(Stream responseStream)
            {
                if (responseStream == null)
                    throw new ArgumentNullException("responseStream");
                _base = responseStream;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                var html = Encoding.UTF8.GetString(buffer, offset, count);
                var reg = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
                html = reg.Replace(html, string.Empty);
                buffer = Encoding.UTF8.GetBytes(html);
                _base.Write(buffer, 0, buffer.Length);
            }


            #region Other Members
            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            public override bool CanRead { get { return false; } }
            public override bool CanSeek { get { return false; } }
            public override bool CanWrite { get { return true; } }
            public override long Length { get { throw new NotSupportedException(); } }
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
            public override void Flush()
            {
                _base.Flush();
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
            #endregion
        }
    }


}