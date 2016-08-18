using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;



namespace W0300_WCF_Ajax
{


    /// <summary>
    /// Ajax  POST   处理.
    /// </summary>
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfTestPostService
    {




        #region  简单 字符串参数 / 结果的.


        /// <summary>
        /// 简单调用服务端方法
        /// 
        /// 
        /// 这个方法 与 WcfTestService 中方法的代码是一致的
        /// 区别在于 标签的不同。
        /// 
        /// WcfTestService 中 定义的标签是 [WebGet()]
        /// 
        /// 本服务中，定义的标签是 
        /// [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string DoWork()
        {
            return string.Format("Today is {0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff"));
        }



        /// <summary>
        /// 简单调用服务端方法
        /// 
        /// 用于测试， 传入一个参数.
        /// 
        /// 
        /// 这个方法 与 WcfTestService 中方法的代码是一致的
        /// 区别在于 标签的不同。
        /// 
        /// WcfTestService 中 定义的标签是 [WebGet()]
        /// 
        /// 本服务中，定义的标签是 
        /// [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string DoWork2(String hello)
        {
            return string.Format("{0}, Today is {1}", hello, DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff"));
        }


        /// <summary>
        /// 简单调用服务端方法
        /// 
        /// 用于测试， 传入两个参数.
        /// 
        /// 
        /// WcfTestService 中 定义的标签是 [WebGet()]
        /// 
        /// 本服务中，定义的标签是 
        /// [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string DoWork3(String hello, string world)
        {
            return string.Format("{0}, {1}, Today is {2}", hello, world, DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff"));
        }


        #endregion








        #region  参数 是 对象.


        /// <summary>
        /// 由客户端传入一个 Json 对象.
        /// 
        /// 
        /// WcfTestService 中 定义的标签是 [WebGet()]
        /// 
        /// 本服务中，定义的标签是 
        /// [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        /// 
        /// 
        /// 
        /// WcfTestService 中，定义的参数是 string 类型， 然后 手动通过   Newtonsoft.Json.JsonConvert 的 DeserializeObject 方法进行 json --> C# 类的转换.
        /// 
        /// 本服务中， 方法参数，直接定义为 UserInfo 类， 不需要手动做 类型转换的处理了。 （ html 那里， jquery 的 ajax 参数需要额外传递参数做设置 ）
        /// 
        /// </summary>
        /// <param name="userInfo">Json格式的UserInfo数据</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string SayHello(UserInfo userInfo)
        {
            return string.Format("Hello {0}, Your password is {1} !  ", userInfo.LoginName, userInfo.Password);
        }




        /// <summary>
        /// 由客户端传入一个 Json 对象. (列表方式，  js 中的数据类型为 数组)
        /// 
        /// 
        /// WcfTestService 中 定义的标签是 [WebGet()]
        /// 
        /// 本服务中，定义的标签是 
        /// [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        /// 
        /// 
        /// 
        /// WcfTestService 中，定义的参数是 string 类型， 然后 手动通过   Newtonsoft.Json.JsonConvert 的 DeserializeObject 方法进行 json --> C# 类的转换.
        /// 
        /// 本服务中， 方法参数，直接定义为 UserInfo 类， 不需要手动做 类型转换的处理了。 （ html 那里， jquery 的 ajax 参数需要额外传递参数做设置 ）
        /// </summary>
        /// <param name="userInfo">Json格式的UserInfo数据</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string SayHelloAll(List<UserInfo> userInfo)
        {
            StringBuilder buff = new StringBuilder();
            foreach (UserInfo user in userInfo)
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
        /// 
        /// WcfTestService 中 定义的标签是 [WebGet()]
        /// 
        /// 本服务中，定义的标签是 
        /// [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        /// 
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public UserInfo GetUser(string userName)
        {
            return testUserList.FirstOrDefault(p => p.LoginName == userName);
        }



        /// <summary>
        /// 返回一个列表.
        /// 
        /// WcfTestService 中 定义的标签是 [WebGet()]
        /// 
        /// 本服务中，定义的标签是 
        /// [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<UserInfo> GetAllUser()
        {
            return testUserList;
        }


        #endregion




        #region  返回值 是 Dictionary 对象.


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
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
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
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
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
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
