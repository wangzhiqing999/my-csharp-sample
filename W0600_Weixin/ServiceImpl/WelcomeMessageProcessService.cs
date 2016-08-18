using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using W0600_Weixin.Models;
using W0600_Weixin.Models.Event;
using W0600_Weixin.Models.Message;



namespace W0600_Weixin.ServiceImpl
{

    /// <summary>
    /// 欢迎服务.
    /// </summary>
    public class WelcomeMessageProcessService : AbstractMessageProcessService<SubscribeEventRequest, TextResponse>
    {

        /// <summary>
        /// 命令文本.
        /// </summary>
        public override string CommandText
        {
            get
            {
                return "Welcome";
            }
        }


        /// <summary>
        /// 命令描述.
        /// </summary>
        public override string CommandDesc
        {
            get
            {
                return "用户关注时，提示欢迎信息.";
            }
        }



        /// <summary>
        /// 没有逻辑， 就是简单 回复
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        protected override TextResponse DoProcessRequest(SubscribeEventRequest req)
        {
            TextResponse res = new TextResponse()
            {
                // 内容.
                Content = "欢迎！这是一个测试号！",
            };

            return res;
        }
    }

}