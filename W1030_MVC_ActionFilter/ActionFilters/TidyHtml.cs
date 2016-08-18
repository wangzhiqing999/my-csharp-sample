using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.IO;
using System.Text;

using Tidy.Core;



namespace W1030_MVC_ActionFilter.ActionFilters
{
    public class TidyHtml : ActionFilterAttribute
    {
        public TidyHtml()
        {
            Xhtml = true;
            IndentContent = true;
            DocType = DocType.Strict;
            XmlOut = true;
            MakeClean = true;
            HideEndTags = true;
            LogicalEmphasis = true;
            DropFontTags = true;
        }
        #region Properties
        public DocType DocType { get; set; }
        public bool DropFontTags { get; set; }
        public bool LogicalEmphasis { get; set; }
        public bool XmlOut { get; set; }
        public bool Xhtml { get; set; }
        public bool IndentContent { get; set; }
        public bool HideEndTags { get; set; }
        public bool MakeClean { get; set; }
        public bool TidyMark { get; set; }
        #endregion
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                var tidy = new Tidy.Core.Tidy
                {
                    Options =
                    {
                        DocType = DocType,
                        DropFontTags = DropFontTags,
                        LogicalEmphasis = LogicalEmphasis,
                        XmlOut = XmlOut,
                        Xhtml = Xhtml,
                        IndentContent = IndentContent,
                        HideEndTags = HideEndTags,
                        MakeClean = MakeClean,
                        TidyMark = TidyMark,
                    }
                };
                filterContext.RequestContext.HttpContext.Response.Filter =
                    new HtmlTidyFilter(filterContext.RequestContext.HttpContext.Response.Filter, tidy);
            }
        }


        #region Nested type: HtmlTidyFilter
        private class HtmlTidyFilter : Stream
        {
            private readonly Stream _stream;
            private readonly Tidy.Core.Tidy _tidy;
            #region Properites
            public override bool CanRead
            {
                get { return true; }
            }
            public override bool CanSeek
            {
                get { return true; }
            }
            public override bool CanWrite
            {
                get { return true; }
            }
            public override long Length
            {
                get { return 0; }
            }
            public override long Position { get; set; }
            public override void Flush()
            {
                _stream.Flush();
            }
            #endregion
            #region Methods
            public override int Read(byte[] buffer, int offset, int count)
            {
                return _stream.Read(buffer, offset, count);
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                return _stream.Seek(offset, origin);
            }
            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }
            public override void Close()
            {
                _stream.Close();
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                var data = new byte[count];
                Buffer.BlockCopy(buffer, offset, data, 0, count);
                string html = Encoding.UTF8.GetString(buffer);
                using (var input = new MemoryStream())
                {
                    using (var output = new MemoryStream())
                    {
                        byte[] byteArray = Encoding.UTF8.GetBytes(html);
                        input.Write(byteArray, 0, byteArray.Length);
                        input.Position = 0;
                        _tidy.Parse(input, output, new TidyMessageCollection());
                        string result = Encoding.UTF8.GetString(output.ToArray());
                        byte[] outdata = Encoding.UTF8.GetBytes(result);
                        _stream.Write(outdata, 0, outdata.GetLength(0));
                    }
                }
            }
            #endregion
            public HtmlTidyFilter(Stream stream, Tidy.Core.Tidy tidy)
            {
                _stream = stream;
                _tidy = tidy;
            }
        }
        #endregion
    }

}