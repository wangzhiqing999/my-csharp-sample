using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Message
{
    public class VoiceResponse : AbstractResponse
    {

        public VoiceResponse()
        {
            this.MsgType = "voice";
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
            return String.Format("<Voice><MediaId><![CDATA[{0}]]></MediaId></Voice>", MediaId);
        }
    }
}