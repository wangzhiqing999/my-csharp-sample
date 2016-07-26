using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




using System.Net;
using System.Net.Sockets;
using A5300_UDP_P2P.Message;
using A5300_UDP_P2P.ServiceImpl;


namespace A5300_UDP_P2P
{
    public partial class FormUserList : A5300_UDP_P2P.FormBase
    {



        public FormUserList()
        {
            InitializeComponent();

            base.btnFunc1.Text = "UserList";
            base.btnFunc2.Text = "Ask";


        }


        /// <summary>
        /// 用户列表.
        /// </summary>
        protected List<string> userList = new List<string> ();


        protected string toUserIp;

        protected int toUserPort;


        /// <summary>
        /// 用户列表.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Func1(object sender, EventArgs e)
        {


            SystemMessage message = new SystemMessage()
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

            // 发送登录消息.
            messageSender.SendMessage(message);
            ShowMessage("发送：" + message.ToString());


            // 接收反馈.
            SystemMessage resultMessage = messageReceiver.ReceiveMessage();
            ShowMessage("接收：" + resultMessage.ToString());

            UserListRespond resultBody = resultMessage.Body as UserListRespond;
            this.userList = resultBody.UserList;
        }



        /// <summary>
        /// 通话请求.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Func2(object sender, EventArgs e)
        {

            FormSelectUser subForm = new FormSelectUser();
            subForm.UserList = this.userList;
            DialogResult diaResult = subForm.ShowDialog();

            if (diaResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            // 已选择的用户.
            string selectUser = subForm.SelectUser;



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
                    AskUserName = selectUser,
                },
            };

            // 发送登录消息.
            messageSender.SendMessage(message);
            ShowMessage("发送：" + message.ToString());


            // 接收反馈.
            SystemMessage resultMessage = messageReceiver.ReceiveMessage();
            ShowMessage("接收：" + resultMessage.ToString());


            AskRespond resultBody = resultMessage.Body as AskRespond;


            if (resultBody.Status > 0)
            {
                this.toUserIp = resultBody.IpAddress;
                this.toUserPort = resultBody.Port;
            }

        }










    }
}
