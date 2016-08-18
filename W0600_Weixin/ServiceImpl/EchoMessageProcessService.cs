using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using W0600_Weixin.Models;
using W0600_Weixin.Models.Message;


namespace W0600_Weixin.ServiceImpl
{

    /// <summary>
    /// 简单回复的消息处理器.
    /// </summary>
    public class EchoMessageProcessService : AbstractMessageProcessService<TextRequest, TextResponse>
    {

        /// <summary>
        /// 命令文本.
        /// </summary>
        public override string CommandText { 
            get {
                return "ECHO";
            } 
        }


        /// <summary>
        /// 命令描述.
        /// </summary>
        public override string CommandDesc
        {
            get
            {
                return "简单回复用户输入";
            }
        }



        /// <summary>
        /// 没有逻辑， 就是简单 回复
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        protected override TextResponse DoProcessRequest(TextRequest req)
        {
            TextResponse res = new TextResponse()
            {
                //// 接收方帐号（收到的OpenID）  
                //ToUserName = req.FromUserName,
                //// 开发者微信号
                //FromUserName = req.ToUserName,
                // 内容.
                Content = "[测试结果] 您输入了:" + req.Content,
            };

            return res;
        }
    }
}