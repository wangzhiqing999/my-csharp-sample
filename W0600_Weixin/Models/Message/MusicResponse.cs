using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Message
{

    /// <summary>
    /// 微信 音乐信息反馈.
    /// </summary>
    public class MusicResponse : AbstractResponse
    {

        public MusicResponse()
        {
            this.MsgType = "music";
        }



        /// <summary>
        /// 音乐标题
        /// </summary>
        public string Title { set; get; }


        /// <summary>
        /// 音乐描述
        /// </summary>
        public string Description { set; get; }


        /// <summary>
        /// 音乐描述
        /// </summary>
        public string MusicURL { set; get; }


        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// </summary>
        public string HQMusicUrl { set; get; }


        /// <summary>
        /// 缩略图的媒体id，通过上传多媒体文件，得到的id
        /// </summary>
        public string ThumbMediaId { set; get; }




        protected override string ResponseToString()
        {
            return String.Format("Title = {0};Description = {1};MusicURL = {2};HQMusicUrl = {3};ThumbMediaId = {4};",
                Title, Description, MusicURL, HQMusicUrl, ThumbMediaId);
        }

        protected override string ResponseToXml()
        {
            return String.Format(@"
<Music>
    <Title><![CDATA[{0}]]></Title>
    <Description><![CDATA[{1}]]></Description>
    <MusicURL><![CDATA[{2}]]></MusicURL>
    <HQMusicUrl><![CDATA[{3}]]></HQMusicUrl>
    <ThumbMediaId><![CDATA[{4}]]></ThumbMediaId>
</Music>",
                Title, Description, MusicURL, HQMusicUrl, ThumbMediaId);
        }


    }
}