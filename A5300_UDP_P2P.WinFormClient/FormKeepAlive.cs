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
    public partial class FormKeepAlive : A5300_UDP_P2P.FormBase
    {

        private System.ComponentModel.BackgroundWorker backgroundWorker1;


        public FormKeepAlive()
        {
            InitializeComponent();


            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);


            base.btnFunc1.Text = "KeepAlive";
            base.btnFunc2.Text = "Stop KeepAlive";

        }


        /// <summary>
        /// 心跳.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Func1(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }


        /// <summary>
        /// 停止发送心跳包.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Func2(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }



        /// <summary>
        /// 心跳包后台处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
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
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);


                    SystemMessage message = new SystemMessage()
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

                    // 发送登录消息.
                    messageSender.SendMessage(message);
                    worker.ReportProgress((int)sequence, message);



                    // 接收反馈.
                    SystemMessage resultMessage = messageReceiver.ReceiveMessage();
                    worker.ReportProgress((int)sequence, resultMessage);

                }
            }





        }



        /// <summary>
        /// 心跳包日志输出.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ShowMessage(e.UserState.ToString());
        }



        /// <summary>
        /// 登出前， 停止心跳包发送.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void LogoutStart(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }


    }
}
