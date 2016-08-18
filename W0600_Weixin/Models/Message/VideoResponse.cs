using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using W0600_Weixin.Models;

namespace W0600_Weixin.Models.Message
{
    public class VideoResponse : AbstractResponse
    {

        public VideoResponse()
        {
            this.MsgType = "video";
        }


        /// <summary>
        /// 通过上传多媒体文件，得到的id。
        /// </summary>
        public string MediaId { set; get; }


        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { set; get; }


        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { set; get; }


        protected override string ResponseToString()
        {
            return String.Format("MediaId = {0};Title = {1};MediaId = {2};",
                MediaId, Title, Description);
        }

        protected override string ResponseToXml()
        {
            return String.Format(@"
<Video>
    <MediaId><![CDATA[{0}]]></MediaId>
    <Title><![CDATA[{1}]]></Title>
    <Description><![CDATA[{2}]]></Description>
</Video>",
                MediaId, Title, Description);
        }
    }
}