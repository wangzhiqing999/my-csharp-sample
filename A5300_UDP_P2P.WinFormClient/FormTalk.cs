using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using System.Net;
using System.Net.Sockets;
using A5300_UDP_P2P.Message;
using A5300_UDP_P2P.ServiceImpl;




namespace A5300_UDP_P2P
{
    public partial class FormTalk : Form
    {
        public FormTalk()
        {
            InitializeComponent();
        }



        /// <summary>
        /// udp 客户端.
        /// </summary>
        protected UdpClient udpClient;


        /// <summary>
        /// 服务端.
        /// </summary>
        protected IPEndPoint serverPoint;


        /// <summary>
        /// 消息发送器
        /// </summary>
        protected UdpClientMessageSender messageSender;


        /// <summary>
        /// 消息接收器
        /// </summary>
        protected UdpClientMessageReceiver messageReceiver;


        /// <summary>
        /// 用户的 Token
        /// </summary>
        protected Guid userToken;



        /// <summary>
        /// 流水
        /// </summary>
        protected uint sequence = 1;



        /// <summary>
        /// 客户端消息处理.
        /// </summary>
        private ClientMessageProcess clientMessageProcess = new ClientMessageProcess();




        /// <summary>
        /// 用户列表.
        /// </summary>
        protected List<string> UserList = new List<string>();

        /// <summary>
        /// 用户名 ip端口 对照表.
        /// </summary>
        protected Dictionary<string, IPEndPoint> userDictionary = new Dictionary<string, IPEndPoint>();



        /// <summary>
        /// 未登录.
        /// </summary>
        protected void NotLogin()
        {
            this.txtServerIP.Enabled = true;
            this.nudServerPort.Enabled = true;
            this.txtUserName.Enabled = true;

            this.btnLogin.Enabled = true;


            this.btnSendMessage.Enabled = false;
            this.lstUserList.Enabled = false;
            this.txtMessage.Enabled = false;

            this.btnLogout.Enabled = false;
        }

        /// <summary>
        /// 已登录.
        /// </summary>
        protected void HadLogin()
        {
            this.txtServerIP.Enabled = false;
            this.nudServerPort.Enabled = false;
            this.txtUserName.Enabled = false;

            this.btnLogin.Enabled = false;


            this.btnSendMessage.Enabled = true;
            this.lstUserList.Enabled = true;
            this.txtMessage.Enabled = true;

            this.btnLogout.Enabled = true;
        }




        private void FormTalk_Load(object sender, EventArgs e)
        {
            udpClient = new UdpClient();


            // 消息发送器.
            messageSender = new UdpClientMessageSender();
            messageSender.UdpClient = udpClient;

            // 消息接收器.
            messageReceiver = new UdpClientMessageReceiver();
            messageReceiver.UdpClient = udpClient;


            
            messageReceiver.IPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            // 初始情况下，未登录.
            NotLogin();
        }


        


        /// <summary>
        /// 显示消息.
        /// </summary>
        /// <param name="message"></param>
        protected void ShowMessage(string message)
        {
            this.txtResult.AppendText(message);
            this.txtResult.AppendText("\r\n");
        }


        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            serverPoint = new IPEndPoint(IPAddress.Parse(this.txtServerIP.Text), Convert.ToInt32(this.nudServerPort.Value));
            messageSender.IPEndPoint = serverPoint;


            SystemMessage message = new SystemMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_Login_Req,
                    SequenceNo = sequence++,
                },

                Body = new LoginRequest()
                {
                    UserName = this.txtUserName.Text,
                    Password = "123456"
                },
            };


            ShowMessage("发送 ：" + message.ToString());

            // 发送登录消息.
            messageSender.SendMessage(message);



            // 接收反馈.
            SystemMessage resultMessage = messageReceiver.ReceiveMessage();


            ShowMessage("接收 ：" + resultMessage.ToString());


            userToken = ((LoginRespond)(resultMessage.Body)).UserToken;


            if (userToken != Guid.Empty)
            {
                // 已登录.
                HadLogin();


                // 心跳包后台处理.
                if (bgwKeepAlive.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    bgwKeepAlive.RunWorkerAsync();
                }


                if (bgwReceive.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    bgwReceive.RunWorkerAsync();
                }
            }

        }



        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 心跳包后台处理.
            if (bgwKeepAlive.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bgwKeepAlive.CancelAsync();
            }


            if (bgwReceive.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bgwReceive.CancelAsync();
            }


            SystemMessage message = new SystemMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_Logout_Req,
                    SequenceNo = sequence++,
                },

                Body = new LogoutRequest()
                {
                    UserToken = userToken
                },
            };


            ShowMessage("发送 ：" + message.ToString());

            // 发送登录消息.
            messageSender.SendMessage(message);



            // 登出后，未登录.
            NotLogin();
        }




        /// <summary>
        /// 窗口关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTalk_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 心跳包后台处理.
            if (bgwKeepAlive.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bgwKeepAlive.CancelAsync();
            }


            // 接收处理.
            if (bgwReceive.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bgwReceive.CancelAsync();
            }
        }



        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (this.lstUserList.SelectedItem == null)
            {
                MessageBox.Show("先选择目标用户！");
                return;
            }

            string toUserName = this.lstUserList.SelectedItem.ToString();
            if (toUserName == this.txtUserName.Text)
            {
                MessageBox.Show("自己无法给自己发送消息！");
                return;
            }

            if (String.IsNullOrEmpty(this.txtMessage.Text))
            {
                MessageBox.Show("不要发送空白消息！");
                return;
            }


            if (!userDictionary.ContainsKey(toUserName))
            {
                // 发送消息第一步， 获取 目标用户的 ip 与端口.
                SendMessageStep1(toUserName);
            }
            else
            {
                IPEndPoint userPoint = userDictionary[toUserName];

                // 已知 目标用户的 ip 与端口.
                SendMessageStep2(userPoint, this.txtMessage.Text);
            }
        }


        /// <summary>
        /// 发送消息第一步， 获取 目标用户的 ip 与端口.
        /// </summary>
        private void SendMessageStep1(string userName)
        {
            // 取得目标用户的 ip 与 端口.
            SystemMessage message = new SystemMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_Ask_Req,
                    SequenceNo = this.sequence++,
                },

                Body = new AskRequest()
                {
                    UserToken = userToken,
                    AskUserName = userName,
                },
            };

            messageSender.IPEndPoint = serverPoint;

            // 发送请求消息.
            messageSender.SendMessage(message);
            ShowMessage("发送：" + message.ToString());


        }


        /// <summary>
        /// 发送消息第二步， 向目标ip/端口， 发送信息.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="messageText"></param>
        private void SendMessageStep2(IPEndPoint userPoint, string messageText)
        {
            SystemMessage message = new SystemMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_Talk_Req,
                    SequenceNo = this.sequence++,
                },

                Body = new TalkRequest()
                {
                    FromUser = this.txtUserName.Text,
                    TalkMessage = messageText
                },
            };


            messageSender.IPEndPoint = userPoint;

            // 发送 文本 消息.
            messageSender.SendMessage(message);



            string info = string.Format("{0} : {1} \r\n", this.txtUserName.Text, messageText);

            this.txtTalkResult.AppendText(info);
        }





        #region 消息接收


        private void bgwReceive_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                messageReceiver.IPEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // 接收消息.
                SystemMessage message = messageReceiver.ReceiveMessage();
                worker.ReportProgress(1, message);

                if (message.Header.IsRequestCommand)
                {
                    // 如果发过来的消息， 是 请求消息， 那么 客户端需要回复.
                    SystemMessage resultMessage = clientMessageProcess.DoMessageProcess(messageReceiver.IPEndPoint, message);

                    // 发送应答消息.
                    // 设置接收方.
                    messageSender.IPEndPoint = messageReceiver.IPEndPoint;
                    // 发送.
                    messageSender.SendMessage(resultMessage);
                    worker.ReportProgress(2, resultMessage);

                    continue;
                }

            }
        }



        private void bgwReceive_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                SystemMessage message = e.UserState as SystemMessage;

                switch (message.Header.CommandID)
                {
                    case MessageHeader.QM_UserList_Resp:
                        // 收到的消息是  当前用户列表.
                        UserListRespond userListRespond = message.Body as UserListRespond;
                        if (String.Join(",", this.UserList) != String.Join(",", userListRespond.UserList))
                        {
                            this.UserList = userListRespond.UserList;
                            this.lstUserList.DataSource = this.UserList;
                        }
                        break;

                    case MessageHeader.QM_Ask_Resp:
                        // 收到的是 请求通话应答.
                        AskRespond askRespond = message.Body as AskRespond;
                        if (askRespond.Status == 1)
                        {
                            IPEndPoint userPoint = new IPEndPoint(IPAddress.Parse(askRespond.IpAddress), askRespond.Port);

                            if (!this.userDictionary.ContainsKey(askRespond.UserName))
                            {
                                this.userDictionary.Add(askRespond.UserName, userPoint);
                            }
                            else
                            {
                                // 刷新.
                                this.userDictionary[askRespond.UserName] = userPoint;
                            }

                            this.SendMessageStep2(userPoint, this.txtMessage.Text);
                        }
                        break;


                    case MessageHeader.QM_Talk_Req:
                        // 收到的是 消息.
                        TalkRequest talkRequest = message.Body as TalkRequest;

                        string info = string.Format("{0} : {1} \r\n", talkRequest.FromUser, talkRequest.TalkMessage);

                        this.txtTalkResult.AppendText(info);

                        break;
                }
            }

            // 简单输出.
            ShowMessage(e.UserState.ToString());
        }


        #endregion 消息接收








        #region 心跳包事件.


        private void bgwKeepAlive_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {                                       
                    SystemMessage message;
                    if (this.sequence % 2 == 0)
                    {
                        // 心跳包.
                        message = new SystemMessage()
                        {
                            Header = new MessageHeader()
                            {
                                CommandID = MessageHeader.QM_KeepAlive_Req,
                                SequenceNo = this.sequence++,
                            },

                            Body = new KeepAliveRequest()
                            {
                               UserToken = userToken
                            },
                        };

                    }
                    else
                    {
                        // 取得用户列表.
                        message = new SystemMessage()
                        {
                            Header = new MessageHeader()
                            {
                                CommandID = MessageHeader.QM_UserList_Req,
                                SequenceNo = this.sequence++,
                            },

                            Body = new UserListRequest()
                            {
                                UserToken = userToken
                            },
                        };
                    }

                    messageSender.IPEndPoint = serverPoint;
                    // 发送 消息.
                    messageSender.SendMessage(message);
                    worker.ReportProgress((int)sequence, message);
                }

                // 周期处理.
                System.Threading.Thread.Sleep(5000);
            }
        }



        private void bgwKeepAlive_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ShowMessage(e.UserState.ToString());
        }

        #endregion 心跳包事件.





    }
}
