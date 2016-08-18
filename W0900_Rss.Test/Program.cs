using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using W0900_Rss.Model;
using W0900_Rss.Service;


namespace W0900_Rss.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Rss rss = new Rss()
            {
                Channel = new RssChannel()
                {
                    Title = "测试网站",
                    Link = "www.测试网站.com",
                    Description = "网站描述",

                    Category = "测试",
                    Copyright = "20XX  www.测试网站.com All rights reserved.",
                    Language = "zh-cn",

                    PubDate = DateTime.Now,
                    LastBuildDate = DateTime.Now,


                    Items = new RssChannelItem[3],
                },
            };

            for (int i = 0; i < 3; i++)
            {
                rss.Channel.Items[i] = new RssChannelItem()
                {
                    Title = "文章" + i,
                    Link = "www.测试网站.com/Doc/" + i,
                    Description = "文章描述.  <a href='#'> 链接信息 </a> ......  " + i,

                    PubDate = DateTime.Now,
                };
            }



            RssWriter writer = new RssWriter();
            writer.WriteRssFile(rss, "test.xml");


        }
    }
}
