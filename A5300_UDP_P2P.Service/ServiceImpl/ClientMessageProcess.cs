using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;


using A5300_UDP_P2P.Model;
using A5300_UDP_P2P.Message;
using A5300_UDP_P2P.Service;




namespace A5300_UDP_P2P.ServiceImpl
{

    /// <summary>
    /// 客户端消息处理.
    /// </summary>
    public class ClientMessageProcess : IMessageProcess
    {


        /// <summary>
        /// 消息处理.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public SystemMessage DoMessageProcess(IPEndPoint ipEndPoint, SystemMessage message)
        {
            SystemMessage result = new SystemMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = message.Header.CommandID + 0x80000000,
                    SequenceNo = message.Header.SequenceNo,
                },
            };


            switch (message.Header.CommandID)
            {
                case MessageHeader.QM_Talk_Req:
                    result.Body = new TalkRespond();
                    break;
            }

            // 返回.
            return result;

        }


    }


}
