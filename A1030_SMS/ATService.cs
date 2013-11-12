using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;


namespace A1030_SMS
{



    public class ATService
    {


        /// <summary>
        /// 默认构造函数.
        /// </summary>
        public ATService()
        {
            this.sp = new SerialPort();
            
            // 读超时时间 发送短信时间的需要
            this.sp.ReadTimeout = -1;

            // 必须为true 这样串口才能接收到数据
            this.sp.RtsEnable = true;

            // 接收到数据时触发的事件.
            this.sp.DataReceived += new SerialDataReceivedEventHandler(this.sp_DataReceived);

        }


        /// <summary>
        /// 析构函数
        /// </summary>
        ~ATService()
        {
            // 假如端口还打开着， 那么尝试关闭掉.
            if (sp != null && sp.IsOpen)
            {
                CloseComm();
            }
        }





        #region 变量、属性.



        /// <summary>
        /// SerialPort串口对象
        /// </summary>
        protected SerialPort sp = null;


        /// <summary>
        /// 新消息序号
        /// </summary>
        private int newMsgIndex;


        /// <summary>
        /// 波特率 运行时只读 设备打开状态写入将引发异常
        /// </summary>
        public int BaudRate
        {
            get { return this.sp.BaudRate; }
            set { this.sp.BaudRate = value; }
        }


        /// <summary>
        /// 串口号 运行时只读 设备打开状态写入将引发异常
        /// 提供对串口端口号的访问
        /// </summary>
        public string ComPort
        {
            get { return this.sp.PortName; }
            set
            {
                try
                {
                    this.sp.PortName = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 设备是否打开
        /// </summary>
        public bool IsOpen
        {
            get { return this.sp.IsOpen; }
        }




        #endregion







        #region 方法.


        /// <summary>
        /// 获取当前计算机的串行端口名称数组。
        /// </summary>
        /// <returns></returns>
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }



        /// <summary>
        /// 打开设备
        /// </summary>
        public void OpenComm()
        {
            try
            {
                this.sp.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (this.sp.IsOpen)
            {
                this.sp.DataReceived -= this.sp_DataReceived;
                this.sp.Write("AT\r");
                Thread.Sleep(1000);
                string s = this.sp.ReadExisting().Trim();
                s = s.Substring(s.Length - 2, 2);
                if (s != "OK")
                {
                    throw new Exception("硬件连接错误");
                }

                //try
                //{
                //    this.SendAT("AT+CMGF=0");//选择短消息格式默认为PDU
                //    Thread.Sleep(100);
                //    this.SendAT("AT+CNMI=2,1");//选择当有新短消息来时提示方式
                //    Thread.Sleep(100);
                //}
                //catch { }
            }
        }


        /// <summary>
        /// 关闭设备
        /// </summary>
        public void CloseComm()
        {
            try
            {
                this.sp.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        /// <summary>
        /// 发送AT命令
        /// </summary>
        /// <param name="ATCom">AT命令</param>
        /// <returns> AT 命令执行结果 </returns>
        public string SendAT(string ATCom)
        {
            string str = string.Empty;
            // 忽略接收缓冲区内容，准备发送
            this.sp.DiscardInBuffer();
            // 注销事件关联，为发送做准备
            this.sp.DataReceived -= this.sp_DataReceived;

            try
            {
                this.sp.Write(ATCom + "\r");
            }
            catch (Exception ex)
            {
                this.sp.DataReceived += this.sp_DataReceived;
                throw ex;
            }
            try
            {
                string temp = string.Empty;
                while ((temp.Trim() != "OK") && (temp.Trim() != "ERROR"))
                {
                    temp = this.sp.ReadLine();
                    str += temp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.sp.DataReceived += this.sp_DataReceived;
            }
            return str;
        }





        #endregion






        #region 事件


        /// <summary>
        /// 创建事件收到信息的委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OnRecievedHandler(object sender, EventArgs e);

        /// <summary>
        /// 收到短信息事件 OnRecieved 
        /// 收到短信将引发此事件
        /// </summary>
        public event OnRecievedHandler GetNewMsg;


        protected void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string str = this.sp.ReadLine();
            if ((str.Length > 8) && (str.Substring(0, 6) == "+CMTI:"))
            {
                // 设置 新消息序号
                this.newMsgIndex = Convert.ToInt32(str.Split(',')[1]);

                // 触发 外部事件.
                if (this.GetNewMsg != null)
                {
                    this.GetNewMsg(this, e);
                }
            }
        }


        #endregion











    }


}
