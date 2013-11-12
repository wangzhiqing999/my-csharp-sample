using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.Serialization;


namespace A0101_Serializable.Model
{
    

    /// <summary>
    /// 用于存储数据的类.
    /// </summary>
    [Serializable]
    [DataContract] 
    public class DataObject
    {

        /// <summary>
        /// 测试保存数据的属性.
        /// 用户名.
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)] 
        public string UserName { set; get; }


        /// <summary>
        /// 测试保存数据的属性.
        /// 好友名列表.
        /// </summary>
        [DataMember(Order = 1)] 
        public List<string> FirendList { set; get; }


        /// <summary>
        /// 密码列不参与 序列化处理.
        /// </summary>
        [NonSerialized]
        private string password;


        /// <summary>
        /// 加入 XmlIgnoreAttribute 标志， 意味着 xml 序列化的时候，忽略该列.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public string Password {
            set { password = value; }
            get { return password; }
        }



        /// <summary>
        /// 调试用。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("UserName = {0} ", UserName);
            buff.AppendFormat("Password = {0} ", Password);

            if (FirendList != null)
            {
                buff.AppendLine();
                buff.Append("FirendList = [ ");

                foreach (string f in FirendList)
                {
                    buff.Append(f);
                    buff.Append(' ');
                }

                buff.Append("]");
            }

            buff.AppendLine();

            return buff.ToString();
        }


    }



}
