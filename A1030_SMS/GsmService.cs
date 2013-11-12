using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1030_SMS
{


    /// <summary>
    /// 枚举 短信类型 
    /// AUSC2 A7Bit：7位编码 （中文用AUSC2，英文都可以 但7Bit能发送160字符，USC2仅70）
    /// </summary>
    public enum MsgType { 
        AUSC2, 
        A7Bit 
    };




    public class GsmService : ATService 
    {

        /// <summary>
        /// 服务中心号码
        /// </summary>
        private string msgCenter;


        /// <summary>
        /// 是否自动删除短信(默认为false)
        /// </summary>
        public bool AutoDelMsg { set; get; }







        #region 方法.



        /// <summary>
        /// 获取机器码
        /// </summary>
        /// <returns></returns>
        public string GetMachineNo()
        {
            string temp = this.SendAT("AT+CGMI");
            if (temp.Substring(temp.Length - 4, 3).Trim() == "OK")
            {
                temp = temp.Split('\r')[2].Trim();
            }
            else
            {
                throw new Exception("获取机器码失败");
            }
            return temp;
        }


        /// <summary>
        /// 获取短信中心号码
        /// </summary>
        /// <returns></returns>
        public string GetMsgCenterNo()
        {
            string temp = string.Empty;
            if (msgCenter != null && msgCenter.Length != 0)
            {
                return msgCenter;
            }
            else
            {
                temp = this.SendAT("AT+CSCA?");
                if (temp.Substring(temp.Length - 4, 3).Trim() == "OK")
                {
                    msgCenter = temp.Split('\"')[1].Trim();
                    return msgCenter;
                }
                else
                {
                    throw new Exception("获取短信中心失败");
                }
            }
        }




        /// <summary>
        /// 取得未读信息列表
        /// </summary>
        /// <returns>未读信息列表（中心号码，手机号码，发送时间，短信内容）</returns>
        public List<string> GetUnReadMsg()
        {
            // 预期结果.
            List<string> result = new List<string>();

            string[] temp = null;
            string tt = string.Empty;

            // 读取未读信息
            tt = this.SendAT("AT+CMGL=0");

            if (tt.EndsWith("OK\r"))
            {
                temp = tt.Split('\r');
            }

            if (tt.EndsWith("ERROR\r"))
            {
                return result;
            }

            
            PDUEncoding pe = new PDUEncoding();

            // 计数
            int i = 0;
            foreach (string str in temp)
            {
                if (str != null && str.Length != 0 && str.Substring(0, 2).Trim() != "+C" && str.Substring(0, 2) != "OK" && str.Substring(0, 2) != "AT")
                {
                    result.Add(pe.PDUDecoder(str));
                    i++;
                }
            }
            return result;
        }



        /// <summary>
        /// 取得已读信息列表
        /// </summary>
        /// <returns>已读信息列表（中心号码，手机号码，发送时间，短信内容）</returns>
        public List<string> GetIsReadMsg()
        {
            // 预期结果.
            List<string> result = new List<string>();

            string[] temp = null;
            string tt = string.Empty;

            // 读取已读信息
            tt = this.SendAT("AT+CMGL=1");


            if (tt.EndsWith("OK\r"))
            {
                temp = tt.Split('\r');
            }

            if (tt.EndsWith("ERROR\r"))
            {
                return result;
            }


            PDUEncoding pe = new PDUEncoding();
            // 计数
            int i = 0;
            foreach (string str in temp)
            {
                if (str != null && str.Length != 0 && str.Substring(0, 2).Trim() != "+C" && str.Substring(0, 2) != "OK" && str.Substring(0, 2) != "AT")
                {
                    result.Add ( pe.PDUDecoder(str));
                    i++;
                }
            }
            return result;
        }




        /// <summary>
        /// 取得待发信息列表
        /// </summary>
        /// <returns>待发信息列表（中心号码，手机号码，发送时间，短信内容）</returns>
        public List<string> GetUnSendMsg()
        {
            // 预期结果.
            List<string> result = new List<string>();

            string[] temp = null;
            string tt = string.Empty;

            // 读取待发信息
            tt = this.SendAT("AT+CMGL=2");

            if (tt.EndsWith("OK\r"))
            {
                temp = tt.Split('\r');
            }

            if (tt.EndsWith("ERROR\r"))
            {
                return result;
            }


            PDUEncoding pe = new PDUEncoding();

            // 计数
            int i = 0;
            foreach (string str in temp)
            {
                if (str != null && str.Length != 0 && str.Substring(0, 2).Trim() != "+C" && str.Substring(0, 2) != "OK" && str.Substring(0, 2) != "AT")
                {
                    result.Add ( pe.PDUDecoder(str));
                    i++;
                }
            }
            return result;
        }



        /// <summary>
        /// 取得已发信息列表
        /// </summary>
        /// <returns>已发信息列表（中心号码，手机号码，发送时间，短信内容）</returns>
        public List<string> GetIsSendMsg()
        {
            // 预期结果.
            List<string> result = new List<string>();

            string[] temp = null;
            string tt = string.Empty;

            // 读取已发信息
            tt = this.SendAT("AT+CMGL=3");


            if (tt.EndsWith("OK\r"))
            {
                temp = tt.Split('\r');
            }

            if (tt.EndsWith("ERROR\r"))
            {
                return result;
            }


            PDUEncoding pe = new PDUEncoding();
            
            // 计数
            int i = 0;
            foreach (string str in temp)
            {
                if (str != null && str.Length != 0 && str.Substring(0, 2).Trim() != "+C" && str.Substring(0, 2) != "OK" && str.Substring(0, 2) != "AT")
                {
                    result.Add (pe.PDUDecoder(str));
                    i++;
                }
            }
            return result;
        }





        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllMsg()
        {
            // 预期结果.
            List<string> result = new List<string>();

            string[] temp = null;
            string tt = string.Empty;

            tt = this.SendAT("AT+CMGL=4");


            if (tt.EndsWith("OK\r"))
            {
                temp = tt.Split('\r');
            }

            if (tt.EndsWith("ERROR\r"))
            {
                return result;
            }


            PDUEncoding pe = new PDUEncoding();
            // 计数
            int i = 0;
            foreach (string str in temp)
            {
                if (str != null && str.Length != 0 && str.Substring(0, 2).Trim() != "+C" && str.Substring(0, 2) != "OK" && str.Substring(0, 2) != "AT")
                {
                    result.Add ( pe.PDUDecoder(str));
                    i++;
                }
            }
            return result;
        }






        /// <summary>
        /// 发送短信       
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <param name="msg">短信内容</param>
        public bool SendMsg(string phone, string msg)
        {
            string temp = "0011000D91" + this.reverserNumber(phone) + "000801" + this.contentEncoding(msg) + Convert.ToChar(26).ToString();
            string len = this.getLenght(msg);//计算长度

            try
            {
                this.sp.DataReceived -= sp_DataReceived;
                this.sp.Write("AT+CMGS=" + len + "\r");
                this.sp.ReadTo(">");
                this.sp.DiscardInBuffer();
                //事件重新绑定 正常监视串口数据
                this.sp.DataReceived += sp_DataReceived;
                temp = this.SendAT(temp);
                if (temp.Substring(temp.Length - 4, 3).Trim() != "OK")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch { return false; }
        }




        /// <summary>
        /// 发送短信 （重载）
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <param name="msg">短信内容</param>
        /// <param name="msgType">短信类型</param>
        public void SendMsg(string phone, string msg, MsgType msgType)
        {
            if (msgType == MsgType.AUSC2)
            {
                SendMsg(phone, msg);
            }
            else
            {

                PDUEncoding pe = new PDUEncoding();

                //短信中心号码 服务中心地址
                pe.ServiceCenterAddress = msgCenter;                    


                string temp = pe.PDU7BitEncoder(phone, msg);


                //计算长度
                int len = (temp.Length - Convert.ToInt32(temp.Substring(0, 2), 16) * 2 - 2) / 2;  

                try
                {
                    //26 Ctrl+Z ascii码
                    temp = SendAT("AT+CMGS=" + len.ToString() + "\r" + temp + (char)(26));  
                }
                catch (Exception)
                {
                    throw new Exception("短信发送失败");
                }

                if (temp.Substring(temp.Length - 4, 3).Trim() == "OK")
                {
                    return;
                }

                throw new Exception("短信发送失败");
            }
        }




        #endregion






        #region  自定义方法

        //获取短信内容的字节数
        private string getLenght(string txt)
        {
            int i = 0;
            string s = "";
            i = txt.Length * 2;
            i += 15;
            s = i.ToString();
            return s;
        }

        //将手机号码转换为内存编码
        private string reverserNumber(string phone)
        {
            string str = "";
            //检查手机号码是否按照标准格式写，如果不是则补上
            if (phone.Substring(0, 2) != "86")
            {
                phone = string.Format("86{0}", phone);
            }
            char[] c = this.getChar(phone);
            for (int i = 0; i <= c.Length - 2; i += 2)
            {
                str += c[i + 1].ToString() + c[i].ToString();
            }
            return str;
        }

        //汉字解码为16进制
        private string contentEncoding(string content)
        {
            Encoding encodingUTF = System.Text.Encoding.BigEndianUnicode;
            string s = "";
            byte[] encodeByte = encodingUTF.GetBytes(content);
            for (int i = 0; i <= encodeByte.Length - 1; i++)
            {
                s += BitConverter.ToString(encodeByte, i, 1);
            }
            s = string.Format("{0:X2}{1}", s.Length / 2, s);
            return s;
        }

        private char[] getChar(string phone)
        {
            if (phone.Length % 2 == 0)
            {
                return Convert.ToString(phone).ToCharArray();
            }
            else
            {
                return Convert.ToString(phone + "F").ToCharArray();
            }
        }


        #endregion
        


    }


}
