using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Web.Security;

using Microsoft.AspNet.SignalR.Client;


namespace W1310_SignalRClient.Sample
{
    class TestSignalRClient
    {

        /// <summary>
        /// 服务器的连接.
        /// </summary>
        private HubConnection hubConnection;

        
        
        /// <summary>
        /// Hub 代理.
        /// </summary>
        private IHubProxy chatHubProxy;







        public void DoTest()
        {
            // 服务器的连接.
            hubConnection = new HubConnection("http://localhost:15858/");


            // 下面的代码， 是 登录的处理逻辑。
            // 也就是必须要先登陆成功了， 才能调用 SignalR 的 Hub 那里， 定义为 [Authorize] 的方法。
            Cookie returnedCookie;
            var authResult = AuthenticateUser("AdminClient", "", out returnedCookie);

            if (authResult)
            {
                hubConnection.CookieContainer = new CookieContainer();
                hubConnection.CookieContainer.Add(returnedCookie);
                Console.WriteLine("Login Success!");
            }
            else
            {
                Console.WriteLine("Login failed!");
            }




            // 关联 Hub.
            chatHubProxy = hubConnection.CreateHubProxy("ChatHub");

            // Hub 中， 需要客户端实现的方法.
            chatHubProxy.On<MessageData>("broadcastMessage", messageData =>
                Console.WriteLine("{0} : {1}", messageData.Name, messageData.Message));

            hubConnection.Start();
        }




        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {

            // 这里是 客户端，调用服务器的方法.
            chatHubProxy.Invoke("Send", "Admin", message);


            // 这里是 客户端，调用服务器的 需要身份认证的方法.
            chatHubProxy.Invoke("AdminSend", "Admin", message);
        }






        private static bool AuthenticateUser(string user, string password, out Cookie authCookie)
        {
            var request = WebRequest.Create("http://localhost:15858/RemoteLogin.ashx") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();

            var authCredentials = "UserName=" + user + "&Password=" + password;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(authCredentials);
            request.ContentLength = bytes.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                authCookie = response.Cookies[FormsAuthentication.FormsCookieName];
            }

            if (authCookie != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }


    /// <summary>
    /// 消息数据.
    /// </summary>
    public class MessageData
    {
        public String Name { set; get; }

        public String Message { set; get; }
    }


}
