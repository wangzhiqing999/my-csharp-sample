using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.MessageCoding
{

    /// <summary>
    /// 消息编码、解码.
    /// </summary>
    public class QueuingMachineMessageCoding : AbstractMessageCoding<QueuingMachineMessage>
    {

        /// <summary>
        /// 消息头编码解码.
        /// </summary>
        private static MessageHeaderCoding headerCoding = new MessageHeaderCoding();


        /// <summary>
        /// 申请新号码请求  编码、解码处理.
        /// </summary>
        private static NewWorkNumberRequestCoding newWorkNumberRequestCoding = new NewWorkNumberRequestCoding();


        /// <summary>
        /// 申请新号码相应  编码、解码处理.
        /// </summary>
        private static NewWorkNumberRespondCoding newWorkNumberRespondCoding = new NewWorkNumberRespondCoding();



        /// <summary>
        /// 叫号请求消息  编码、解码处理.
        /// </summary>
        private static AskWorkNumberRequestCoding askWorkNumberRequestCoding = new AskWorkNumberRequestCoding();


        /// <summary>
        /// 叫号反馈消息  编码、解码处理.
        /// </summary>
        private static AskWorkNumberRespondCoding askWorkNumberRespondCoding = new AskWorkNumberRespondCoding();


        /// <summary>
        /// 完成服务处理请求消息 编码、解码处理.
        /// </summary>
        public static CloseWorkNumberRequestCoding closeWorkNumberRequestCoding = new CloseWorkNumberRequestCoding();


        /// <summary>
        /// 完成服务处理反馈消息    编码、解码处理.
        /// </summary>
        public static CloseWorkNumberRespondCoding closeWorkNumberRespondCoding = new CloseWorkNumberRespondCoding();



        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="messageData"></param>
        public override void Encode(BinaryWriter writer, QueuingMachineMessage messageData)
        {
            messageData.SetCommandLength();
            // 写入 消息头信息.
            headerCoding.Encode(writer, messageData.Header);

            // 写入消息体.
            switch (messageData.Header.CommandID)
            {
                case MessageHeader.QM_NewWorkNumber_Req:
                    //  申请新号码请求.
                    newWorkNumberRequestCoding.Encode(writer, messageData.Body as NewWorkNumberRequest);
                    break;

                case MessageHeader.QM_NewWorkNumber_Resp:
                    //  申请新号码相应.
                    newWorkNumberRespondCoding.Encode(writer, messageData.Body as NewWorkNumberRespond);
                    break;

                case MessageHeader.QM_AskWorkNumber_Req:
                    // 叫号请求.
                    askWorkNumberRequestCoding.Encode(writer, messageData.Body as AskWorkNumberRequest);
                    break;

                case MessageHeader.QM_AskWorkNumber_Resp :
                    // 叫号反馈
                    askWorkNumberRespondCoding.Encode(writer, messageData.Body as AskWorkNumberRespond);
                    break;

                case MessageHeader.QM_CloseWorkNumber_Req:
                    // 完成服务处理请求
                    closeWorkNumberRequestCoding.Encode(writer, messageData.Body as CloseWorkNumberRequest);
                    break;

                case MessageHeader.QM_CloseWorkNumber_Resp :
                    // 完成服务处理反馈
                    closeWorkNumberRespondCoding.Encode(writer, messageData.Body as CloseWorkNumberRespond);
                    break;
            }

        }



        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="messageData"></param>
        public override void Decode(BinaryReader reader, QueuingMachineMessage messageData)
        {
            // 初始化头信息.
            messageData.Header = new MessageHeader();            
            // 读取 消息头信息.
            headerCoding.Decode(reader, messageData.Header);

            // 读取  消息体.
            switch (messageData.Header.CommandID)
            {

                case MessageHeader.QM_NewWorkNumber_Req:
                    //  申请新号码请求.
                    messageData.Body = new NewWorkNumberRequest();
                    newWorkNumberRequestCoding.Decode(reader, messageData.Body as NewWorkNumberRequest);
                    break;

                case MessageHeader.QM_NewWorkNumber_Resp:
                    //  申请新号码相应.
                    messageData.Body = new NewWorkNumberRespond();
                    newWorkNumberRespondCoding.Decode(reader, messageData.Body as NewWorkNumberRespond);
                    break;

                case MessageHeader.QM_AskWorkNumber_Req:
                    // 叫号请求.
                    messageData.Body = new AskWorkNumberRequest();
                    askWorkNumberRequestCoding.Decode(reader, messageData.Body as AskWorkNumberRequest);
                    break;

                case MessageHeader.QM_AskWorkNumber_Resp:
                    // 叫号反馈
                    messageData.Body = new AskWorkNumberRespond();
                    askWorkNumberRespondCoding.Decode(reader, messageData.Body as AskWorkNumberRespond);
                    break;

                case MessageHeader.QM_CloseWorkNumber_Req:
                    // 完成服务处理请求
                    messageData.Body = new CloseWorkNumberRequest();
                    closeWorkNumberRequestCoding.Decode(reader, messageData.Body as CloseWorkNumberRequest);
                    break;

                case MessageHeader.QM_CloseWorkNumber_Resp:
                    // 完成服务处理反馈
                    messageData.Body = new CloseWorkNumberRespond();
                    closeWorkNumberRespondCoding.Decode(reader, messageData.Body as CloseWorkNumberRespond);
                    break;
            }
            
        }
    }
}
