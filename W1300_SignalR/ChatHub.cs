using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace W1300_SignalR
{


    /// <summary>
    /// 这个 Hub , 是同时支持  Web 调用，  与  C# 控制台程序调用的。
    /// </summary>
    public class ChatHub : Hub
    {

        //public void Hello()
        //{
        //    Clients.All.hello();
        //}



        /// <summary>
        /// Hub 这里定义的 Send 方法， 将被 客户端调用。
        /// 也就是  客户端那里， 将调用 Send 方法.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void Send(string name, string message)
        {
            // 下面的方法， 是将要调用 所有的客户的 broadcastMessage 方法。
            // 这要求， 客户端那里， 定义有 broadcastMessage 方法， 能够被调用。


            string systemUser;

            var user = Context.User;

            if (user.Identity.IsAuthenticated)
            {
                systemUser = user.Identity.Name;
            }
            else
            {
                systemUser = "匿名用户";
            }




            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(new { Name = String.Format("{0}[{1}]", systemUser ,name), Message = message });
        }





        /// <summary>
        /// 这了定义， 必须要通过身份认证了， 才能调用的方法。
        /// 
        /// 参考页面：
        /// http://www.asp.net/signalr/overview/security/hub-authorization
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        [Authorize]
        public void AdminSend(string name, string message)
        {

            var user = Context.User;


            Clients.All.broadcastMessage(new { Name = String.Format("{0}[{1}]", user.Identity.Name, name), Message = "管理员消息:" + message });
        }


    }
}