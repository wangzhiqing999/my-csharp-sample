using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.Serialization;


namespace A0101_Serializable.Model
{



    /// <summary>
    /// 用户类型枚举.
    /// </summary>
    [DataContract(Namespace = "")]
    public enum DataObjectType
    {

        /// <summary>
        /// 测试用户.
        /// </summary>
        TestUser,

        /// <summary>
        /// 普通用户.
        /// </summary>
        NormalUser,


        /// <summary>
        /// 管理员用户.
        /// </summary>
        AdminUser

    }


    /// <summary>
    /// 用于存储数据的类.
    /// </summary>
    [Serializable]
    [DataContract]
    [ProtoBuf.ProtoContract]
    public class DataObject
    {

        /// <summary>
        /// 测试保存数据的属性.
        /// 用户名.
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        [ProtoBuf.ProtoMember(1)]
        public string UserName { set; get; }



        /// <summary>
        /// 测试保存数据的属性.
        /// 好友名列表.
        /// </summary>
        [DataMember(Order = 1)]
        [ProtoBuf.ProtoMember(2)]
        public List<string> FirendList { set; get; }


        /// <summary>
        /// 密码列不参与 序列化处理.
        /// </summary>
        [NonSerialized]
        [ProtoBuf.ProtoIgnore]
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
        /// 用户类型.
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        [ProtoBuf.ProtoMember(3)]
        public DataObjectType UserType { set; get; }



        /// <summary>
        /// 调试用。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("UserName = {0} ", UserName);
            buff.AppendFormat("Password = {0} ", Password);
            buff.AppendFormat("UserType = {0} ", UserType);

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
