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

using G0031_QueuingMachine.Message;
using G0031_QueuingMachine.ServiceImpl;


namespace G0031_QueuingMachine.Machine
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// IP地址.
        /// </summary>
        private IPAddress localAddr;


        /// <summary>
        /// 接入点.
        /// </summary>
        private IPEndPoint ephost;


        /// <summary>
        /// 流水号.
        /// </summary>
        private uint sequenceNo = 1;


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // 取得配置信息.
            Properties.Settings config = Properties.Settings.Default;

            // IP地址.
            localAddr = IPAddress.Parse(config.IPAddress);

            // 接入点.
            ephost = new IPEndPoint(localAddr, config.Port);

        }



        /// <summary>
        /// 请求服务代码按钮处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnA_Click(object sender, EventArgs e)
        {
            // 取得触发事件的按钮.
            Button btn = sender as Button;

            // 取得服务代码.
            string code = btn.Tag.ToString();

            // 发送.
            SendMessage(code);

        }


        /// <summary>
        /// 发送请求消息.
        /// </summary>
        /// <param name="code"></param>
        private void SendMessage(string code)
        {

            QueuingMachineMessage message = new QueuingMachineMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_NewWorkNumber_Req ,
                    SequenceNo = sequenceNo ++,
                },
                Body = new NewWorkNumberRequest()
                { 
                    ServiceCode = code,                    
                },
            };



            // 第一个参数：AddressFamily  = 指定 Socket 类的实例可以使用的寻址方案。
            //     Unspecified 未指定地址族。
            //     InterNetwork IP 版本 4 的地址。
            //     InterNetworkV6 IP 版本 6 的地址。
            //
            // 第二个参数：SocketType = 指定 Socket 类的实例表示的套接字类型。
            //     Stream 一个套接字类型，支持可靠、双向、基于连接的字节流，而不重复数据，也不保留边界。
            //            此类型的 Socket 与单个对方主机通信，并且在通信开始之前需要建立远程主机连接。
            //            此套接字类型使用传输控制协议 (Tcp)，AddressFamily 可以是 InterNetwork，也可以是 InterNetworkV6。
            //
            // 第三个参数：ProtocolType = 指定 Socket 类支持的协议。
            //     Tcp 传输控制协议 (TCP)。
            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //  尝试连接主机.
                mySocket.Connect(ephost);

                // 发送消息.
                SocketMessageSender sender = new SocketMessageSender();
                sender.Socket = mySocket;
                sender.SendMessage(message);
                

                // 接收消息.
                SocketMessageReceiver receiver = new SocketMessageReceiver();
                receiver.Socket = mySocket;
                QueuingMachineMessage resultMessage = receiver.ReceiveMessage();

                NewWorkNumberRespond body = resultMessage.Body as NewWorkNumberRespond;

                txtResult.Text = String.Format(@"您的排队号码为{0},
您前面共有{1}个用户处于等待中！",
                  body.ResultWorkNumber,
                  body.QueueLength -1
                  );

            }
            catch (Exception ex)
            {
                txtResult.AppendText("连接/发送/接收过程中，发生了错误！");
                txtResult.AppendText(ex.Message);
                txtResult.AppendText(ex.StackTrace);
            }
            finally
            {
                mySocket.Close();
            }
            
        }

    }
}
