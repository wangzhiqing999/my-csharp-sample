using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace W1302_RoomManager
{
    public class RoomHub : Hub
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
        public void Send(string roomId, string name, string message)
        {
            // 下面的方法， 是将要调用 所有的客户的 broadcastMessage 方法。
            // 这要求， 客户端那里， 定义有 broadcastMessage 方法， 能够被调用。


            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(roomId, name, message);
        }

    }
}