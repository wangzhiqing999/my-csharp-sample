using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A5300_UDP_P2P.Message;



namespace A5300_UDP_P2P.MessageCoding
{

    /// <summary>
    /// 消息编码、解码.
    /// </summary>
    public class SystemMessageCoding : AbstractMessageCoding<SystemMessage>
    {

        /// <summary>
        /// 消息头编码解码.
        /// </summary>
        private static MessageHeaderCoding headerCoding = new MessageHeaderCoding();





        /// <summary>
        /// 登录请求消息  编码、解码处理.
        /// </summary>
        private static LoginRequestCoding loginRequestCoding = new LoginRequestCoding();
        /// <summary>
        /// 登录应答消息  编码、解码处理.
        /// </summary>
        private static LoginRespondCoding loginRespondCoding = new LoginRespondCoding();



        /// <summary>
        /// 登出请求消息  编码、解码处理.
        /// </summary>
        private static LogoutRequestCoding logoutRequestCoding = new LogoutRequestCoding();
        /// <summary>
        /// 登出应答消息  编码、解码处理.
        /// </summary>
        private static LogoutRespondCoding logoutRespondCoding = new LogoutRespondCoding();



        /// <summary>
        /// 心跳包请求消息  编码、解码处理.
        /// </summary>
        private static KeepAliveRequestCoding keepAliveRequestCoding = new KeepAliveRequestCoding();
        /// <summary>
        /// 心跳包应答消息  编码、解码处理.
        /// </summary>
        private static KeepAliveRespondCoding keepAliveRespondCoding = new KeepAliveRespondCoding();





        /// <summary>
        /// 用户列表请求消息  编码、解码处理.
        /// </summary>
        private static UserListRequestCoding userListRequestCoding = new UserListRequestCoding();
        /// <summary>
        /// 用户列表应答消息  编码、解码处理.
        /// </summary>
        private static UserListRespondCoding userListRespondCoding = new UserListRespondCoding();



        /// <summary>
        /// 请求独立通话请求消息  编码、解码处理.
        /// </summary>
        private static AskRequestCoding askRequestCoding = new AskRequestCoding();
        /// <summary>
        /// 请求独立通话应答消息  编码、解码处理.
        /// </summary>
        private static AskRespondCoding askRespondCoding = new AskRespondCoding();






        /// <summary>
        /// 通话请求消息  编码、解码处理.
        /// </summary>
        private static TalkRequestCoding talkRequestCoding = new TalkRequestCoding();
        /// <summary>
        /// 通话应答消息  编码、解码处理.
        /// </summary>
        private static TalkRespondCoding talkRespondCoding = new TalkRespondCoding();






        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="messageData"></param>
        public override void Encode(BinaryWriter writer, SystemMessage messageData)
        {
            messageData.SetCommandLength();
            // 写入 消息头信息.
            headerCoding.Encode(writer, messageData.Header);

            // 写入消息体.
            switch (messageData.Header.CommandID)
            {
                case MessageHeader.QM_Login_Req:
                    //  登录请求消息.
                    loginRequestCoding.Encode(writer, messageData.Body as LoginRequest);
                    break;
                case MessageHeader.QM_Login_Resp:
                    //  登录应答消息.
                    loginRespondCoding.Encode(writer, messageData.Body as LoginRespond);
                    break;


                case MessageHeader.QM_Logout_Req:
                    // 登出请求消息
                    logoutRequestCoding.Encode(writer, messageData.Body as LogoutRequest);
                    break;
                case MessageHeader.QM_Logout_Resp:
                    // 登出应答消息
                    logoutRespondCoding.Encode(writer, messageData.Body as LogoutRespond);
                    break;



                case MessageHeader.QM_KeepAlive_Req:
                    // 心跳包请求消息
                    keepAliveRequestCoding.Encode(writer, messageData.Body as KeepAliveRequest);
                    break;
                case MessageHeader.QM_KeepAlive_Resp:
                    // 心跳包应答消息
                    keepAliveRespondCoding.Encode(writer, messageData.Body as KeepAliveRespond);
                    break;





                case MessageHeader.QM_UserList_Req:
                    // 用户列表请求消息
                    userListRequestCoding.Encode(writer, messageData.Body as UserListRequest);
                    break;
                case MessageHeader.QM_UserList_Resp:
                    // 用户列表应答消息
                    userListRespondCoding.Encode(writer, messageData.Body as UserListRespond);
                    break;



                case MessageHeader.QM_Ask_Req:
                    // 请求独立通话请求消息
                    askRequestCoding.Encode(writer, messageData.Body as AskRequest);
                    break;
                case MessageHeader.QM_Ask_Resp:
                    // 请求独立通话应答消息
                    askRespondCoding.Encode(writer, messageData.Body as AskRespond);
                    break;





                case MessageHeader.QM_Talk_Req:
                    // 通话请求消息
                    talkRequestCoding.Encode(writer, messageData.Body as TalkRequest);
                    break;
                case MessageHeader.QM_Talk_Resp:
                    // 通话应答消息
                    talkRespondCoding.Encode(writer, messageData.Body as TalkRespond);
                    break;
            }

        }



        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="messageData"></param>
        public override void Decode(BinaryReader reader, SystemMessage messageData)
        {
            // 初始化头信息.
            messageData.Header = new MessageHeader();            
            // 读取 消息头信息.
            headerCoding.Decode(reader, messageData.Header);

            // 读取  消息体.
            switch (messageData.Header.CommandID)
            {

                case MessageHeader.QM_Login_Req:
                    //  登录请求消息.
                    messageData.Body = new LoginRequest();
                    loginRequestCoding.Decode(reader, messageData.Body as LoginRequest);
                    break;
                case MessageHeader.QM_Login_Resp:
                    // 登录应答消息.               
                    messageData.Body = new LoginRespond();
                    loginRespondCoding.Decode(reader, messageData.Body as LoginRespond);
                    break;


                case MessageHeader.QM_Logout_Req:
                    // 登出请求消息
                    messageData.Body = new LogoutRequest();
                    logoutRequestCoding.Decode(reader, messageData.Body as LogoutRequest);
                    break;
                case MessageHeader.QM_Logout_Resp:
                    // 登出应答消息
                    messageData.Body = new LogoutRespond();
                    logoutRespondCoding.Decode(reader, messageData.Body as LogoutRespond);
                    break;


                case MessageHeader.QM_KeepAlive_Req:
                    // 心跳包请求消息
                    messageData.Body = new KeepAliveRequest();
                    keepAliveRequestCoding.Decode(reader, messageData.Body as KeepAliveRequest);
                    break;
                case MessageHeader.QM_KeepAlive_Resp:
                    // 心跳包应答消息
                    messageData.Body = new KeepAliveRespond();
                    keepAliveRespondCoding.Decode(reader, messageData.Body as KeepAliveRespond);
                    break;



                case MessageHeader.QM_UserList_Req:
                    // 用户列表请求消息
                    messageData.Body = new UserListRequest();
                    userListRequestCoding.Decode(reader, messageData.Body as UserListRequest);
                    break;
                case MessageHeader.QM_UserList_Resp:
                    // 用户列表应答消息
                    messageData.Body = new UserListRespond();
                    userListRespondCoding.Decode(reader, messageData.Body as UserListRespond);
                    break;




                case MessageHeader.QM_Ask_Req:
                    // 请求独立通话请求消息
                    messageData.Body = new AskRequest();
                    askRequestCoding.Decode(reader, messageData.Body as AskRequest);
                    break;
                case MessageHeader.QM_Ask_Resp:
                    // 请求独立通话应答消息
                    messageData.Body = new AskRespond();
                    askRespondCoding.Decode(reader, messageData.Body as AskRespond);
                    break;



                case MessageHeader.QM_Talk_Req:
                    // 通话请求消息
                    messageData.Body = new TalkRequest();
                    talkRequestCoding.Decode(reader, messageData.Body as TalkRequest);
                    break;
                case MessageHeader.QM_Talk_Resp:
                    // 通话应答消息
                    messageData.Body = new TalkRespond();
                    talkRespondCoding.Decode(reader, messageData.Body as TalkRespond);
                    break;

            }
            
        }
    }
}
