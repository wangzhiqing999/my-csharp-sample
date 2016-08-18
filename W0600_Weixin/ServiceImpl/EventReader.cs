using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text;
using System.Xml;

using log4net;


using W0600_Weixin.Models;
using W0600_Weixin.Models.Event;



namespace W0600_Weixin.ServiceImpl
{

    /// <summary>
    /// 事件读取.
    /// </summary>
    public class EventReader
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        
        /// <summary>
        /// 从文本信息中， 获取事件数据.
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        public AbstractRequest ReadEvent(string weixin)
        {
            XmlDocument doc = new XmlDocument();
            //读取xml字符串
            doc.LoadXml(weixin);
            XmlElement root = doc.DocumentElement;

            // 获取收到的消息类型。文本(text)，图片(image)，语音等。
            XmlNode MsgType = root.SelectSingleNode("MsgType");
            string messageType = MsgType.InnerText;

            if (messageType != "event")
            {
                if (logger.IsDebugEnabled)
                {
                    logger.Debug("不是事件，忽略处理。");
                }
                return null;
            }


            AbstractRequest resultEvent = null;



            XmlNode Event = root.SelectSingleNode("Event");
            string eventType = Event.InnerText;

            try
            {
                switch (eventType)
                {
                    case EventType.SubscribeEventType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到用户订阅事件，尝试解析..");
                        }
                        resultEvent = new SubscribeEventRequest(doc);
                        break;


                    case EventType.UnsubscribeEventType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到用户取消订阅事件，尝试解析..");
                        }
                        resultEvent = new UnsubscribeEventRequest(doc);
                        break;

                    case EventType.ScanEventType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到用户扫码事件，尝试解析..");
                        }
                        resultEvent = new ScanEventRequest(doc);
                        break;


                    case EventType.LocationEventType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到用户上报地理位置事件，尝试解析..");
                        }
                        resultEvent = new LocationEventRequest(doc);
                        break;


                    case EventType.ClickEventType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到用户自定义菜单事件，尝试解析..");
                        }
                        resultEvent = new ClickEventRequest(doc);
                        break;


                    default:
                        logger.WarnFormat("检测到了无法识别的信息：{0}", eventType);
                        break;
                }


                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("消息解析结果：{0}", resultEvent);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return resultEvent;


        }

    }

}