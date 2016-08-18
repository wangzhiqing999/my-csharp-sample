using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;



using Newtonsoft.Json;




namespace W0300_WCF_Ajax
{



    /// <summary>
    /// 创建本类的方式：  是创建一个 “启用了 AJAX 的 WCF 服务”
    /// </summary>
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfTestService
    {


        #region  简单 字符串参数 / 结果的.


        /// <summary>
        /// 简单调用服务端方法
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet()]
        public string DoWork()
        {
            return string.Format("Today is {0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff"));
        }



        /// <summary>
        /// 简单调用服务端方法
        /// 
        /// 用于测试， 传入一个参数.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet()]
        public string DoWork2(String hello)
        {
            return string.Format("{0}, Today is {1}", hello, DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff"));
        }


        /// <summary>
        /// 简单调用服务端方法
        /// 
        /// 用于测试， 传入两个参数.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet()]
        public string DoWork3(String hello, string world)
        {
            return string.Format("{0}, {1}, Today is {2}", hello, world, DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff"));
        }


        #endregion





        #region  参数 是 对象.


        /// <summary>
        /// 由客户端传入一个 Json 对象.
        /// </summary>
        /// <param name="userInfo">Json格式的UserInfo数据</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string SayHello(string userInfo)
        {
            // Newtonsoft.Json 使用第三方类库将传入的Json字符串反序列化成实体类。
            UserInfo model = JsonConvert.DeserializeObject<UserInfo>(userInfo);

            return string.Format("Hello {0}, Your password is {1} !  ", model.LoginName, model.Password);
        }




        /// <summary>
        /// 由客户端传入一个 Json 对象. (列表方式，  js 中的数据类型为 数组)
        /// </summary>
        /// <param name="userInfo">Json格式的UserInfo数据</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string SayHelloAll(string userInfo)
        {
            // Newtonsoft.Json 使用第三方类库将传入的Json字符串反序列化成实体类。
            List<UserInfo> userList = JsonConvert.DeserializeObject<List<UserInfo>>(userInfo);


            StringBuilder buff = new StringBuilder();
            foreach (UserInfo user in userList)
            {
                buff.AppendFormat("Hello {0} ,  Your password is {1} !  ", user.LoginName, user.Password);
            }

            buff.Append(" !!! ");

            // 返回.
            return buff.ToString();
        }


        #endregion



        
        
        #region  返回值 是 对象.


        /// <summary>
        /// 用于测试返回的 用户列表.
        /// </summary>
        private static List<UserInfo> testUserList = new List<UserInfo>()
        {
            new UserInfo() { LoginName = "zhao", Password = "123", Phone ="13800000001" }, 
            new UserInfo() { LoginName = "qian", Password = "456", Phone ="13800000002" } ,
            new UserInfo() { LoginName = "sun", Password = "789", Phone ="13800000003" } ,
            new UserInfo() { LoginName = "li", Password = "abc", Phone ="13800000004" } ,
        };


        /// <summary>
        /// 返回一个对象.
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public UserInfo GetUser(string userName)
        {
            return testUserList.FirstOrDefault(p => p.LoginName == userName);
        }



        /// <summary>
        /// 返回一个列表.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<UserInfo> GetAllUser()
        {
            return testUserList;
        }


        #endregion




        #region  返回值 是 Dictionary 对象.


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public Dictionary<string, string> GetAllUserDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (UserInfo user in testUserList)
            {
                result.Add(user.LoginName, user.Phone);
            }
            return result;
        }

        #endregion






        #region 用于测试 jQuery 的 ajax  cache 参数的.



        /// <summary>
        /// 返回一个随机数.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public int GetRandomNextValue()
        {
            Random r = new Random();
            return r.Next();
        }



        #endregion






        #region 用于测试 jQuery 的 ajax  async 参数的.




        /// <summary>
        /// 用于测试 jQuery 的 ajax  async 参数
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet()]
        public string RunLongTime(int second)
        {
            DateTime startDT = DateTime.Now;

            Thread.Sleep(second * 1000);

            DateTime endDT = DateTime.Now;

            return string.Format("服务器运行了 {0} 秒而得到运行结果： 开始时间：{1} ; 结束时间：{2} ", second, startDT.ToString("HH:mm:ss"), endDT.ToString("HH:mm:ss"));
        }




        #endregion




    }

}









/// <summary>
/// 用于在  Ajax 过程中， 传递的中间对象.
/// </summary>
[DataContract]
public class UserInfo
{

    /// <summary>
    /// 用户名.
    /// </summary>
    [DataMember]
    public string LoginName { set; get; }



    /// <summary>
    /// 密码.
    /// 
    /// 注意： 下面的 ScriptIgnore， 意味着这个属性， 不参与 json 序列化的处理.
    /// 也就是 js 在传送 json 数据的时候， 客户端将获取不到这个属性的数值.
    /// 
    /// 
    /// 如果仅仅加了  ScriptIgnore， 会导致 json 看不到了， 但是 xml 方式依然可以看到.
    /// 通过  XmlIgnoreAttribute  标志， 使得 xml 上面， 也看不到数据.
    /// 
    /// </summary>
    [System.Web.Script.Serialization.ScriptIgnore]
    [System.Xml.Serialization.XmlIgnoreAttribute]
    public string Password { set; get; }



    /// <summary>
    /// 电话
    /// </summary>
    [DataMember]
    public string Phone { set; get; }

    
}