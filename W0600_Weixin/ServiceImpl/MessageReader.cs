using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text;
using System.Xml;

using log4net;


using W0600_Weixin.Models;
using W0600_Weixin.Models.Message;


namespace W0600_Weixin.ServiceImpl
{
    public class MessageReader
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 事件读取.
        /// </summary>
        private EventReader eventReader = new EventReader();




        /// <summary>
        /// 从文本信息中， 获取消息数据.
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        public AbstractRequest ReadMessage(string weixin)
        {
            XmlDocument doc = new XmlDocument();
            //读取xml字符串
            doc.LoadXml(weixin);
            XmlElement root = doc.DocumentElement;

            // 获取收到的消息类型。文本(text)，图片(image)，语音等。
            XmlNode MsgType = root.SelectSingleNode("MsgType");
            string messageType = MsgType.InnerText;


            
            AbstractRequest resultMessage = null;

            try
            {
                switch (messageType)
                {
                    case MessageType.TextMsgType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到文本消息，尝试解析..");
                        }
                        resultMessage = new TextRequest(doc);
                        break;

                    case MessageType.ImageMsgType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到图片消息，尝试解析..");
                        }
                        resultMessage = new ImageRequest(doc);
                        break;

                    case MessageType.VoiceMsgType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到语音消息，尝试解析..");
                        }
                        resultMessage = new VoiceRequest(doc);
                        break;

                    case MessageType.VideoMsgType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到视频消息，尝试解析..");
                        }
                        resultMessage = new VideoRequest(doc);
                        break;

                    case MessageType.LocationMsgType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到地理位置消息，尝试解析..");
                        }
                        resultMessage = new LocationRequest(doc);
                        break;


                    case MessageType.LinkMsgType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到链接消息，尝试解析..");
                        }
                        resultMessage = new LinkRequest(doc);
                        break;



                    case MessageType.EventMsgType:
                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("检测到事件消息，尝试解析..");
                        }
                        resultMessage = eventReader.ReadEvent(weixin);
                        break;


                    default:
                        logger.WarnFormat("检测到了无法识别的信息：{0}", messageType);
                        break;
                }


                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("消息解析结果：{0}", resultMessage);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return resultMessage;
        }


    }
}