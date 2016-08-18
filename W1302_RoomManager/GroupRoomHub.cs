using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

using System.Threading;
using System.Threading.Tasks;



namespace W1302_RoomManager
{


    public class GroupRoomHub : Hub
    {


        /// <summary>
        /// 初始化分组.
        /// </summary>
        /// <param name="groupName"></param>
        public void InitGroup(string group)
        {
            //注册到全局  
            GlobalHost.ConnectionManager.GetHubContext<GroupRoomHub>().Groups.Add(Context.ConnectionId, group);
        }







        /// <summary>
        /// Hub 这里定义的 Send 方法， 将被 客户端调用。
        /// 也就是  客户端那里， 将调用 Send 方法.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void Send(string group, string name, string message)
        {
            // 下面的方法， 是将要调用 所有的客户的 broadcastMessage 方法。
            // 这要求， 客户端那里， 定义有 broadcastMessage 方法， 能够被调用。

            // Call the broadcastMessage method to update clients.
            Clients.Group(group).broadcastMessage(name, message);
        }

    }





}