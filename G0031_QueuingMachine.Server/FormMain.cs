using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;


using G0031_QueuingMachine.Message;
using G0031_QueuingMachine.ServiceImpl;


namespace G0031_QueuingMachine.Server
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 消息管理实例.
        /// </summary>
        private DefaultMessageProcess processer = DefaultMessageProcess.GetInstance();




        /// <summary>
        /// 监听端口的主线程;
        /// </summary>
        private Thread mainListenerThread;

        /// <summary>
        /// 主线程方法.
        /// </summary>
        private ThreadStart mainThreadStart;



        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // 初始化 主线程方法.
            mainThreadStart = new ThreadStart(StartServer);


            // 设置线程池的最小数.
            ThreadPool.SetMinThreads(2, 2);

            // 设置线程池的最大数.
            ThreadPool.SetMaxThreads(5, 5);


            // 加入3组号码.
            processer.AddNewIWorkNumberManager(new DefaultWorkNumberManager("A", 6));
            processer.AddNewIWorkNumberManager(new DefaultWorkNumberManager("B", 6));
            processer.AddNewIWorkNumberManager(new DefaultWorkNumberManager("C", 6));
        }


        /// <summary>
        /// 窗口关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStart.Text != "启动服务")
            {
                myListener.Stop();

                // 终止线程.
                mainListenerThread.Abort();
            }
        }


        /// <summary>
        /// 启动服务.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "启动服务")
            {
                // 启动.
                mainListenerThread = new Thread(mainThreadStart);
                mainListenerThread.Start();

                // 设置按钮文本.
                btnStart.Text = "停止服务";
            }
            else
            {
                myListener.Stop();

                // 终止线程.
                mainListenerThread.Abort();

                // 设置按钮文本.
                btnStart.Text = "启动服务";
            }            
        }



        /// <summary>
        /// 侦听来自 TCP 网络客户端的连接。
        /// </summary>
        private TcpListener myListener = null;


        /// <summary>
        /// 启动 Socket 服务.
        /// </summary>
        private void StartServer()
        {
            try
            {
                // 端口号.
                int port =  Convert.ToInt32 (this.nudPort.Value);

                // IP地址.
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                // 在 指定 端口 开一个侦听.
                myListener = new TcpListener(localAddr, port);

                Console.WriteLine("开始侦听 {0} 端口……", port);


                while (true)
                {

                    // 开始侦听.
                    myListener.Start();

                    // 程序在这里暂停， 等待客户端的接入.
                    Socket mySocket = myListener.AcceptSocket();

                    PorcessOneRequest(mySocket);

                    // 管理当前连接.
                    mySocket.Close(5);
                }
                

            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message);

                Console.WriteLine(e.StackTrace);
            }
            finally
            {

                myListener.Stop();
            }
        }







        private void PorcessOneRequest(Socket mySocket)
        {
            ShowProcessMessage("接收到客户的连接...");

            // 消息接收器.
            SocketMessageReceiver receiver = new SocketMessageReceiver();
            receiver.Socket = mySocket;

            // 接收消息.
            QueuingMachineMessage message = receiver.ReceiveMessage();
            // 输出消息.
            ShowProcessMessage("接收->" + message.ToString());



            // 处理消息.
            QueuingMachineMessage resultMessage = processer.DoMessageProcess(message);
            // 输出消息.
            ShowProcessMessage("反馈->" + resultMessage.ToString());

            SocketMessageSender sender = new SocketMessageSender();
            sender.Socket = mySocket;
            sender.SendMessage(resultMessage);


        }



        /// <summary>
        /// 向结果文本框输出消息.
        /// </summary>
        /// <param name="message"></param>
        private void ShowProcessMessage(string message)
        {
            Invoke(new Action(() =>
            {
                this.txtResult.AppendText(message);

            }));
        }


          
    }
}
