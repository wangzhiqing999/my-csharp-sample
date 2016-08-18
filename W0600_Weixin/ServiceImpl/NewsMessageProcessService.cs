using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using W0600_Weixin.Models;
using W0600_Weixin.Models.Message;


namespace W0600_Weixin.ServiceImpl
{

    /// <summary>
    /// 文字请求， 回复新闻的处理.
    /// </summary>
    public class NewsMessageProcessService : AbstractMessageProcessService<TextRequest, NewsResponse>
    {

        /// <summary>
        /// 命令文本.
        /// </summary>
        public override string CommandText
        {
            get
            {
                return "NEWS";
            }
        }


        /// <summary>
        /// 命令描述.
        /// </summary>
        public override string CommandDesc
        {
            get
            {
                return "测试新闻";
            }
        }



        protected override NewsResponse DoProcessRequest(TextRequest req)
        {

            NewsResponse result = new NewsResponse()
            {
                //// 接收方帐号（收到的OpenID）  
                //ToUserName = req.FromUserName,
                //// 开发者微信号
                //FromUserName = req.ToUserName,
            };


            // 初始化新闻列表.
            result.NewsItemList = new List<NewsItem>();


            NewsItem news1 = new NewsItem()
            {
                Title = "测试新闻标题1",
                Description = "测试新闻描述1",
                Url = "http://tech.huanqiu.com/photo/2016-08/2842117.html",
                PicUrl = "http://himg2.huanqiu.com/attachment2010/2016/0818/14/50/20160818025052461.jpg"
            };

            NewsItem news2 = new NewsItem()
            {
                Title = "测试新闻标题2",
                Description = "测试新闻描述2",
                Url = "http://tech.huanqiu.com/photo/2016-08/2842054.html",
                PicUrl = "http://himg2.huanqiu.com/attachment2010/2016/0818/09/45/20160818094552379.png"
            };


            result.NewsItemList.Add(news1);
            result.NewsItemList.Add(news2);

            return result;
        }
    }


}