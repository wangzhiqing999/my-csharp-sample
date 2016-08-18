using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using W0600_Weixin.Service;


using W0600_Weixin.Models;


namespace W0600_Weixin.ServiceImpl
{

    /// <summary>
    /// 文本命令.
    /// </summary>
    public abstract class AbstractMessageProcessService <T1, T2> : IMessageProcessService
        where T1 : AbstractRequest
        where T2 : AbstractResponse
    {

        /// <summary>
        /// 命令文本.
        /// </summary>
        public abstract string CommandText {  get; }


        /// <summary>
        /// 命令描述.
        /// </summary>
        public abstract string CommandDesc {  get; }


        /// <summary>
        /// 抽象请求.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        protected abstract T2 DoProcessRequest(T1 req);



        /// <summary>
        /// 处理请求.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AbstractResponse ProcessRequest(AbstractRequest req)
        {
            T1 t1 = (T1)req;

            T2 result = DoProcessRequest(t1);



            // 接收方帐号（收到的OpenID）  
            result.ToUserName = t1.FromUserName;

            // 开发者微信号
            result.FromUserName = t1.ToUserName;



            return result;
        }
    }
}