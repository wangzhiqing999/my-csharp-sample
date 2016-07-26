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
    /// 服务端消息处理.
    /// </summary>
    public class ServerMessageProcess : IMessageProcess
    {


        private DefaultClientManager clientManager;



        /// <summary>
        /// 构造函数.
        /// </summary>
        private ServerMessageProcess()
        {
            // 用户管理.
            clientManager = DefaultClientManager.GetInstance();

        }


        /// <summary>
        /// 单例用.
        /// </summary>
        private static ServerMessageProcess me;


        public static ServerMessageProcess GetInstance()
        {
            if (me == null)
            {
                me = new ServerMessageProcess();
            }
            return me;
        }




        
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

                case MessageHeader.QM_Login_Req:
                    // 登录.
                    LoginRequest request = message.Body as LoginRequest;

                    MyClient loginResult = clientManager.Login(ipEndPoint, request.UserName, request.Password);

                    if (loginResult != null)
                    {
                        result.Body = new LoginRespond()
                        {
                            UserToken = loginResult.UserToken
                        };
                    }
                    else
                    {
                        result.Body = new LoginRespond()
                        {
                            UserToken = Guid.Empty
                        };
                    }

                    break;


                case MessageHeader.QM_KeepAlive_Req:
                    // 心跳包.
                    bool keepAliveResult = clientManager.KeepAlive(ipEndPoint, ((KeepAliveRequest)(message.Body)).UserToken);

                    result.Body = new KeepAliveRespond()
                    {
                        Status = keepAliveResult?1:-1
                    };

                    break;


                case MessageHeader.QM_Logout_Req:
                    // 登出.
                    clientManager.Logout(ipEndPoint, ((LogoutRequest)(message.Body)).UserToken);

                    result.Body = new LogoutRespond();

                    break;



                case MessageHeader.QM_UserList_Req:
                    // 用户列表.
                    UserListRequest userListRequest = message.Body as UserListRequest;

                    if (!clientManager.IsActiveToken(userListRequest.UserToken))
                    {
                        // 无效用户.
                        result.Body = new UserListRespond()
                        {
                            UserList = new List<string>()
                        };
                    }
                    else
                    {
                        // 有效用户.
                        result.Body = new UserListRespond()
                        {
                            UserList = clientManager.GetUserList()
                        };
                    }
                    break;



                case MessageHeader.QM_Ask_Req:
                    // 请求通话.
                    AskRequest askRequest = message.Body as AskRequest;

                    if (!clientManager.IsActiveToken(askRequest.UserToken))
                    {   
                        // 无效用户.
                        result.Body = new AskRespond()
                        {
                            Status = -1,
                            UserName = askRequest.AskUserName,
                            IpAddress = String.Empty,
                            Port = 0,
                        };
                    }
                    else
                    {
                        // 有效用户.
                        MyClient user = clientManager.GetUser(askRequest.AskUserName);

                        if (user == null)
                        {
                            // 目标用户不存在.
                            result.Body = new AskRespond()
                            {
                                Status = -2,
                                UserName = askRequest.AskUserName,
                                IpAddress = String.Empty,
                                Port = 0,
                            };
                        }
                        else
                        {
                            // 目标用户存在
                            result.Body = new AskRespond()
                            {
                                Status = 1,
                                UserName = askRequest.AskUserName,
                                IpAddress = user.ClientIP,
                                Port = user.ClientPort,
                            };
                        }                        
                    }
                    break;
            }

            // 返回.
            return result;

        }


    }

}
