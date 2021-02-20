using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace W1030_MVC_ActionFilter.ActionFilters
{

    public class AddScriptFilter : FilterAttribute, IResultFilter
    {


        private const string AddScript = @"
<script>
    console.log('我是一段 js 脚本，我将被安置在 html 的 </head> 的上面！');
</script>
";


        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                // 仅仅处理视图的结果.

                var response = filterContext.HttpContext.Response;


                if (response.ContentType != "text/html" || response.Filter == null) return;


                response.Filter = new AddScriptHelper(response.Filter);
            }


            
            // 下面这种写法，是简单粗暴的，把 <script> 追加在 </html> 的后面.
            // 不推荐使用.
            // filterContext.RequestContext.HttpContext.Response.Write(AddScript);
            
        }


        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            // Do Nothing.
        }



        private class AddScriptHelper : Stream
        {
            private readonly Stream _base;
            StringBuilder _s = new StringBuilder();

            public AddScriptHelper(Stream responseStream)
            {
                if (responseStream == null)
                    throw new ArgumentNullException("responseStream");
                _base = responseStream;
            }

            public override bool CanRead => _base.CanRead;

            public override bool CanSeek => _base.CanSeek;

            public override bool CanWrite => _base.CanWrite;

            public override long Length => _base.Length;

            public override long Position { get => _base.Position; set => _base.Position = value; }

            public override void Flush()
            {
                _base.Flush();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _base.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _base.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _base.SetLength(value);
            }




            public override void Write(byte[] buffer, int offset, int count)
            {
                var html = Encoding.UTF8.GetString(buffer, offset, count);

                int headIndex = html.IndexOf("</head>");


                if(headIndex > 0)
                {
                    string step0 = html.Substring(0, headIndex);
                    string step2 = html.Substring(headIndex);

                    html = string.Format(@"{0}
{1}
{2}", step0, AddScript, step2);
                }



                buffer = Encoding.UTF8.GetBytes(html);
                _base.Write(buffer, 0, buffer.Length);
            }
        }



    }

}