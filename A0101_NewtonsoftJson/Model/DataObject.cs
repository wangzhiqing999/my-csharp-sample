using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

using Newtonsoft.Json;


namespace A0101_NewtonsoftJson.Model
{



    /// <summary>
    /// 用户类型枚举.
    /// </summary>
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
    [JsonObject(MemberSerialization.OptIn)]
    public class DataObject
    {

        /// <summary>
        /// 测试保存数据的属性.
        /// 用户名.
        /// </summary>
        [JsonProperty]
        public string UserName { set; get; }



        /// <summary>
        /// 测试保存数据的属性.
        /// 好友名列表.
        /// </summary>
        [JsonProperty]
        public List<string> FirendList { set; get; }


        /// <summary>
        /// 密码列不参与 序列化处理.
        /// </summary>
        private string password;


        /// <summary>
        /// 密码
        /// 
        /// 注意： 
        /// 因为这个类的顶部， 定义了 JsonObject(MemberSerialization.OptIn)
        /// 
        /// 因此， 只有那些属性前面， 加有 JsonProperty 标志的， 才会生成到 Json 字符串中。
        /// 
        /// 没有加  JsonProperty 标志的， 将被忽略.
        /// 
        /// </summary>
        public string Password {
            set { password = value; }
            get { return password; }
        }


        /// <summary>
        /// 用户类型.
        /// </summary>
        [JsonProperty]
        public DataObjectType UserType { set; get; }



        /// <summary>
        /// 测试 时间 对象.
        /// </summary>
        [JsonProperty]
        public DateTime TestDateTime { set; get; }



        /// <summary>
        /// 测试一个 空值.
        /// </summary>
        [JsonProperty]
        public String TestNullValue { set; get; }




        /// <summary>
        /// 调试用。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("UserName = {0} \n", UserName);
            buff.AppendFormat("Password = {0} \n", Password);
            buff.AppendFormat("UserType = {0} \n", UserType);
            buff.AppendFormat("CreateTime = {0:yyyy-MM-dd HH:mm:ss} \n", TestDateTime);
            buff.AppendFormat("TestNullValue = {0} \n", TestNullValue);


            if (FirendList != null)
            {
                buff.Append("FirendList = [ ");

                foreach (string f in FirendList)
                {
                    buff.Append(f);
                    buff.Append(';');
                }

                buff.Append("]");
            }

            buff.AppendLine();

            return buff.ToString();
        }





        public static DataObject GetDefaultTestData()
        {
            DataObject testData = new DataObject();
            testData.UserName = "测试 序列化 / 反序列化";
            testData.Password = "123456";
            testData.UserType = DataObjectType.TestUser;
            testData.TestDateTime = DateTime.Now;

            testData.FirendList = new List<string>();
            testData.FirendList.Add("Newtonsoft.Json Test1");
            testData.FirendList.Add("Newtonsoft.Json Test2");

            return testData;
        }


    }






    #region 测试序列化的时候， 可能会遇到的问题.


    /// <summary>
    /// 测试类1. 未加任何序列化标志.
    /// </summary>
    public class Test1
    {
        public int A { set; get; }

        public long B { set; get; }

        public decimal C { set; get; }
    }


    /// <summary>
    /// 测试类2. 使用 [Serializable] 序列化标志.
    /// </summary>
    [Serializable]
    public class Test2
    {
        public int A { set; get; }

        public long B { set; get; }

        public decimal C { set; get; }
    }

    /// <summary>
    /// 测试类3. 使用 [DataContract] 序列化标志.
    /// </summary>
    [DataContract]
    public class Test3
    {
        [DataMember]
        public int A { set; get; }

        [DataMember]
        public long B { set; get; }

        [DataMember]
        public decimal C { set; get; }
    }

    #endregion

}
