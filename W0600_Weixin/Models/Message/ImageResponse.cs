using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;


using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Message
{
    /// <summary>
    /// 微信 图片信息反馈.
    /// </summary>
    public class ImageResponse : AbstractResponse
    {

        public ImageResponse()
        {
            this.MsgType = "image";
        }

        /// <summary>
        /// 通过上传多媒体文件，得到的id。
        /// </summary>
        public string MediaId { set; get; }


        protected override string ResponseToString()
        {
            return String.Format("MediaId = {0};", MediaId);
        }

        protected override string ResponseToXml()
        {
            return String.Format("<Image><MediaId><![CDATA[{0}]]></MediaId></Image>", MediaId);
        }
    }
}