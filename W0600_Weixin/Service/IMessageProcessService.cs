using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using W0600_Weixin.Models;


namespace W0600_Weixin.Service
{

    /// <summary>
    /// 消息处理服务.
    /// </summary>
    public interface IMessageProcessService
    {

        /// <summary>
        /// 命令文本.
        /// </summary>
        string CommandText {  get; }


        /// <summary>
        /// 命令描述.
        /// </summary>
        string CommandDesc {  get; }



        /// <summary>
        /// 处理请求.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        AbstractResponse ProcessRequest(AbstractRequest req);

    }
}
