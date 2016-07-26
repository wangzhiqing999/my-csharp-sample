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
    public partial class FormBase : Form
    {
        public FormBase()
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
        /// 未登录.
        /// </summary>
        protected void NotLogin()
        {
            this.btnLogin.Enabled = true;

            this.btnFunc1.Enabled = false;
            this.btnFunc2.Enabled = false;

            this.btnFunc3.Enabled = false;
            this.btnFunc4.Enabled = false;

            this.btnLogout.Enabled = false;
        }

        /// <summary>
        /// 已登录.
        /// </summary>
        protected void HadLogin()
        {
            this.btnLogin.Enabled = false;

            this.btnFunc1.Enabled = true;
            this.btnFunc2.Enabled = true;

            this.btnFunc3.Enabled = true;
            this.btnFunc4.Enabled = true;

            this.btnLogout.Enabled = true;
        }



        protected void FormBase_Load(object sender, EventArgs e)
        {
            udpClient = new UdpClient();


            // 消息发送器.
            messageSender = new UdpClientMessageSender();
            messageSender.UdpClient = udpClient;

            // 消息接收器.
            messageReceiver = new UdpClientMessageReceiver();
            messageReceiver.UdpClient = udpClient;


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







        #region 登录登出事件


        /// <summary>
        /// 登录结束.
        /// (这里做 登录后的初始化相关工作.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void LoginFinish(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 开始登出.
        /// (这里做登出前的， 相关资源释放工作。)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void LogoutStart(object sender, EventArgs e)
        {
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
            messageReceiver.IPEndPoint = serverPoint;


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


                LoginFinish(sender, e);
            }



            
        }




        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {

            
            LogoutStart(sender, e);


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



            // 接收反馈.
            SystemMessage resultMessage = messageReceiver.ReceiveMessage();


            ShowMessage("接收 ：" + resultMessage.ToString());



            // 登出后，未登录.
            NotLogin();


            
        }





        #endregion 登录登出事件









        #region  按钮处理事件.


        protected virtual void Func1(object sender, EventArgs e)
        {
        }
        protected virtual void Func2(object sender, EventArgs e)
        {
        }
        protected virtual void Func3(object sender, EventArgs e)
        {
        }
        protected virtual void Func4(object sender, EventArgs e)
        {
        }


        private void btnFunc1_Click(object sender, EventArgs e)
        {
            Func1(sender, e);
        }
        private void btnFunc2_Click(object sender, EventArgs e)
        {
            Func2(sender, e);
        }
        private void btnFunc3_Click(object sender, EventArgs e)
        {
            Func3(sender, e);
        }
        private void btnFunc4_Click(object sender, EventArgs e)
        {
            Func4(sender, e);
        }


        #endregion  按钮处理事件.




    }
}
