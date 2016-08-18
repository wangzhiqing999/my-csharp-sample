using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Text;



namespace W0300_WCF_Ajax
{

    /// <summary>
    /// TestWebService 提供几个基本的 Web 服务的例子
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {


        #region  简单 字符串参数 / 结果的.


        /// <summary>
        /// 简单调用服务端方法
        /// </summary>
        /// <returns></returns>
        [WebMethod]
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
        [WebMethod]
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
        [WebMethod]
        public string DoWork3(String hello, string world)
        {
            return string.Format("{0}, {1}, Today is {2}", hello, world, DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff"));
        }


        #endregion







        #region  参数 是 对象.


        /// <summary>
        /// 客户端传入一个对象.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [WebMethod]
        public string SayHello(UserInfo model)
        {
            return string.Format("Hello {0}, Your password is {1} !  ", model.LoginName, model.Password);
        }



        /// <summary>
        /// 客户端传入一个对象列表.
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
        [WebMethod]
        public string SayHelloAll(UserInfo[] userList)
        {
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
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod]
        public UserInfo GetUser(string userName)
        {
            return testUserList.FirstOrDefault(p => p.LoginName == userName);
        }



        /// <summary>
        /// 返回一个列表.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<UserInfo> GetAllUser()
        {
            return testUserList;
        }


        #endregion





    }






}
