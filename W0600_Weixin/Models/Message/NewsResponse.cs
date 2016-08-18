using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;

using W0600_Weixin.Models;

namespace W0600_Weixin.Models.Message
{
    public class NewsResponse : AbstractResponse
    {

        public NewsResponse()
        {
            this.MsgType = "news";
        }



        /// <summary>
        /// 图文消息个数，限制为10条以内
        /// </summary>
        public int ArticleCount {
            get
            {
                return NewsItemList.Count;
            }
        }


        /// <summary>
        /// 图文列表.
        /// </summary>
        public List<NewsItem> NewsItemList { set; get; }



        protected override string ResponseToString()
        {
            StringBuilder buff = new StringBuilder();
            foreach (NewsItem item in this.NewsItemList)
            {
                buff.Append(item.ToString());
            }
            return buff.ToString();
        }



        protected override string ResponseToXml()
        {
            StringBuilder buff = new StringBuilder();
            buff.AppendFormat("<ArticleCount>{0}</ArticleCount>", ArticleCount);
            buff.Append("<Articles>");
            foreach (NewsItem item in this.NewsItemList)
            {
                buff.Append(item.ToXml());
            }
            buff.Append("</Articles>");

            return buff.ToString();
        }
    }



    /// <summary>
    /// 图文消息.
    /// </summary>
    public class NewsItem
    {

        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string Title { set; get; }


        /// <summary>
        /// 图文消息描述
        /// </summary>
        public string Description { set; get; }


        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        public string PicUrl { set; get; }


        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        public string Url { set; get; }



        public override string ToString()
        {
            return String.Format("Title={0}; Description={1}; PicUrl={2}; Url={3}",
                Title, Description, PicUrl, Url);
        }



        public string ToXml()
        {
            return String.Format(@"
<item>
    <Title><![CDATA[{0}]]></Title>
    <Description><![CDATA[{1}]]></Description>
    <PicUrl><![CDATA[{2}]]></PicUrl>
    <Url><![CDATA[{3}]]></Url>
</item>", 
                Title, Description, PicUrl, Url);
        }

    }


}