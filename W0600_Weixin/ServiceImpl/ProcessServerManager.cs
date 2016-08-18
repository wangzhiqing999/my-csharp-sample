using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using W0600_Weixin.Models;
using W0600_Weixin.Models.Message;
using W0600_Weixin.Models.Event;

using W0600_Weixin.Service;



namespace W0600_Weixin.ServiceImpl
{

    /// <summary>
    /// 处理服务管理器.
    /// </summary>
    public class ProcessServerManager 
    {

        /// <summary>
        /// 私有构造函数.
        /// </summary>
        private ProcessServerManager()
        {
            // 消息服务列表.
            MessageServiceList = new List<IMessageProcessService>();

            // ECHO 服务.
            MessageServiceList.Add(new EchoMessageProcessService());

            // NEWS 服务.
            MessageServiceList.Add(new NewsMessageProcessService());





            // 事件服务键值.
            EventServiceDictionary = new Dictionary<string, IMessageProcessService>();

            // 用户关注时，发出 欢迎消息.
            EventServiceDictionary.Add(EventType.SubscribeEventType, new WelcomeMessageProcessService());

        }


        /// <summary>
        /// 单例类.
        /// </summary>
        private static ProcessServerManager me = new ProcessServerManager();


        /// <summary>
        /// 取得实例.
        /// </summary>
        /// <returns></returns>
        public static ProcessServerManager Instance()
        {
            return me;
        }



        /// <summary>
        /// 处理请求.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AbstractResponse ProcessRequest(AbstractRequest req)
        {
            if (req.MsgType == MessageType.EventMsgType)
            {
                // 处理事件.
                AbstractEventRequest e = req as AbstractEventRequest;

                if (!this.EventServiceDictionary.ContainsKey(e.Event))
                {
                    // 不包含特定的事件处理.
                    return null;
                }

                IMessageProcessService service = this.EventServiceDictionary[e.Event];
                return service.ProcessRequest(req);
            }


            if (req.MsgType == MessageType.TextMsgType)
            {
                // 处理文本请求.

                IMessageProcessService service = this.MessageServiceList.FirstOrDefault(p => p.CommandText.ToUpper() == ((TextRequest)req).Content.ToUpper());

                if (service != null)
                {
                    // 找到服务， 进行处理.
                    return service.ProcessRequest(req);
                }

            }

            // 未知的命令， 或者未知的 消息类型.
            return GetHelp(req);
        }




        /// <summary>
        /// 消息服务列表.
        /// </summary>
        public List<IMessageProcessService> MessageServiceList { set; get; }



        /// <summary>
        /// 事件服务键值.
        /// </summary>
        public Dictionary<string, IMessageProcessService> EventServiceDictionary { set; get; }




        /// <summary>
        /// 帮助信息.
        /// </summary>
        /// <returns></returns>
        private TextResponse GetHelp(AbstractRequest req)
        {
            TextResponse result = new TextResponse()
            {
                // 接收方帐号（收到的OpenID）  
                ToUserName = req.FromUserName,
                // 开发者微信号
                FromUserName = req.ToUserName,
            };



            StringBuilder buff = new StringBuilder("您好，输入下列信息选择服务类型：");
            buff.AppendLine();

            foreach (IMessageProcessService service in MessageServiceList)
            {
                buff.AppendFormat("{0}:{1}", service.CommandText, service.CommandDesc);
                buff.AppendLine();
            }

            result.Content = buff.ToString();


            return result;
        }


    }
}