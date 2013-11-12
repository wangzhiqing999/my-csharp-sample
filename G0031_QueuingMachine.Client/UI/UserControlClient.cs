using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


using System.Net;
using System.Net.Sockets;

using G0031_QueuingMachine.Message;
using G0031_QueuingMachine.ServiceImpl;



namespace G0031_QueuingMachine.Client.UI
{

    public partial class UserControlClient : UserControl
    {
        public UserControlClient()
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
        /// 监听端口的主线程;
        /// </summary>
        private Thread mainListenerThread;

        /// <summary>
        /// 主线程方法.
        /// </summary>
        private ThreadStart mainThreadStart;


        /// <summary>
        /// 处理标志.
        /// </summary>
        private bool runningFlag = true;


        /// <summary>
        /// 随机数处理.
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// 工作时间.
        /// </summary>
        private int workingTimes = 0;

        /// <summary>
        /// 最大工作时间.
        /// </summary>
        private int maxWorkingTimes = 0;


        /// <summary>
        /// 服务代码.
        /// </summary>
        public string ServiceCode { set; get; }


        /// <summary>
        /// 设置窗口代码.
        /// </summary>
        /// <param name="windowNo"></param>
        public void SetWindowNumber(string windowNo)
        {
            this.lblWindow.Text = windowNo;
        }


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControlClient_Load(object sender, EventArgs e)
        {
            // 取得配置信息.
            Properties.Settings config = Properties.Settings.Default;

            // IP地址.
            localAddr = IPAddress.Parse(config.IPAddress);

            // 接入点.
            ephost = new IPEndPoint(localAddr, config.Port);

            // 初始化 主线程方法.
            mainThreadStart = new ThreadStart(StartService);


            // 初始化时， 没有 号码.
            this.lblNumberInfo.Text = String.Empty;
        }



        public void StartClient()
        {
            // 启动线程处理.
            mainListenerThread = new Thread(mainThreadStart);
            mainListenerThread.Start();

            // 启动定时器.
            this.timerProcess.Start();
        }
        

        /// <summary>
        /// 开始服务.
        /// </summary>
        private void StartService()
        {
            while (runningFlag)
            {
                int result = SendMessage();

                if (result == 1)
                {
                    // 休眠 最大工作时间.
                    Thread.Sleep(maxWorkingTimes * 1000);
                }
                else
                {
                    // 休眠3秒.
                    Thread.Sleep(3000);
                }

            }
        }


        /// <summary>
        /// 终止服务.
        /// </summary>
        public void StopClient()
        {
            runningFlag = false;
        }


        /// <summary>
        /// 发送请求消息.
        /// </summary>
        /// <param name="code"></param>
        private int SendMessage()
        {

            QueuingMachineMessage message = new QueuingMachineMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_AskWorkNumber_Req,
                    SequenceNo = sequenceNo++,
                },
                Body = new AskWorkNumberRequest()
                {
                    ServiceCode = ServiceCode,                     
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

                AskWorkNumberRespond body = resultMessage.Body as AskWorkNumberRespond;


                if (body.ResultStatus == 0)
                {
                    ShowProcessMessage(String.Empty, "休息中......");

                    this.maxWorkingTimes = 0;
                    this.workingTimes = 0;
                }
                else
                {
                    ShowProcessMessage(body.ResultWorkNumber, "服务中......");

                    // 随机服务时间.
                    this.maxWorkingTimes = random.Next(5, 15);
                    this.workingTimes = 0;
                    
                }


                return body.ResultStatus;
            }
            catch (Exception ex)
            {
                ShowProcessMessage(String.Empty,  "连接/发送/接收过程中，发生了错误！" + ex.Message );

                return 0;
            }
            finally
            {
                mySocket.Close();
            }

        }



        /// <summary>
        /// 向结果文本框输出消息.
        /// </summary>
        /// <param name="message"></param>
        private void ShowProcessMessage(string numberMessage, string workingMessage)
        {
            Invoke(new Action(() =>
            {
                this.lblNumberInfo.Text = numberMessage;
                lblWorkInfo.Text = workingMessage;
            }));
        }


        /// <summary>
        /// 定时器处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerProcess_Tick(object sender, EventArgs e)
        {
            if (this.maxWorkingTimes == 0 || this.workingTimes >= this.maxWorkingTimes)
            {
                this.lblTimes.Text = String.Empty;
                return;
            }

            this.workingTimes++;
            this.lblTimes.Text = String.Format("{0} / {1}", this.workingTimes, this.maxWorkingTimes);
        }

    }
}
