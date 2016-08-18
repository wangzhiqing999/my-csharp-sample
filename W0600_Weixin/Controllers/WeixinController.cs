using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Text;
using System.Xml;

using log4net;


using W0600_Weixin.Models;
using W0600_Weixin.ServiceImpl;


namespace W0600_Weixin.Controllers
{
    public class WeixinController : Controller
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 消息读取器
        /// </summary>
        private MessageReader messageReader = new MessageReader();



        /// <summary>
        /// 微信 Token(令牌)， 需要在 微信公众平台那里设置.
        /// </summary>
        private static readonly string Token = "wweixin";




        //
        // GET: /Weixin/
        [HttpGet]
        public ActionResult Index()
        {
            string echoStr = Request.QueryString["echoStr"];
            logger.InfoFormat("接受到来自外部的请求数据：echoStr = {0} ", echoStr);

            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    return Content(echoStr);
                }
            }
            return null;
        }


        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        /// <returns></returns>
        private bool CheckSignature()
        {
            string signature = Request.QueryString["signature"];
            string timestamp = Request.QueryString["timestamp"];
            string nonce = Request.QueryString["nonce"];

            logger.InfoFormat("验证微信签名: signature={0};timestamp={1};nonce={2}", signature, timestamp, nonce);

            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                logger.Debug("验证成功！");
                return true;
            }
            else
            {
                logger.Debug("验证成功！");
                return false;
            }
        }




        /// <summary>
        /// 消息处理.
        /// </summary>
        /// <returns></returns>
        [HttpPost, ActionName("Index")]
        public ActionResult MessageProcess()
        {
            string xml = PostInput(Request);
            logger.DebugFormat("接收到的 XML 数据：{0}", xml);

            return ResponseMsg(xml);
        }



        /// <summary>
        /// 获取post请求数据
        /// </summary>
        /// <returns></returns>
        private string PostInput(HttpRequestBase request)
        {
            Stream s = request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            return Encoding.UTF8.GetString(b);
        }


        /// <summary>
        /// 服务器响应微信请求
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        private ActionResult ResponseMsg(string weixin)
        {

            // 尝试读取消息.
            AbstractRequest requestMessage = messageReader.ReadMessage(weixin);

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("尝试读取消息, 读取结果: {0}", requestMessage);
            }

            if (requestMessage == null)
            {
                logger.Warn("无法识别的消息！");

                // 无法识别的消息.
                return Content("");
            }




            // 消息处理管理器.
            ProcessServerManager manager = ProcessServerManager.Instance();
            // 处理具体请求.
            AbstractResponse response = manager.ProcessRequest(requestMessage);


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("尝试处理消息, 处理结果: {0}", response);
            }


            if (response != null)
            {
                // 处理成功.
                string xmlData = response.ToXml();

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("提交反馈的 XML 消息: {0}", xmlData);
                }

                return Content(xmlData, "text/xml", Encoding.UTF8);
            }

            logger.WarnFormat("存在有消息，没有进行处理：{0}", weixin);
            return Content("");
        }


    }
}
