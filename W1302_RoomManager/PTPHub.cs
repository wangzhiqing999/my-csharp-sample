using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;


using W1302_RoomManager.Test;


namespace W1302_RoomManager
{


    /// <summary>
    /// 测试  点对点 的 Hub.
    /// 
    /// 参考网页：http://www.tuicool.com/articles/IFBRFnN
    /// </summary>
    [HubName("ptopHub")]
    public class PTPHub : Hub
    {
        public static List<UserInfo> UserList = new List<UserInfo>();
        //public static List<RoomInfo> RoomList = new List<RoomInfo>();
        /// <summary>
        /// 重写链接事件
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            // 查询用户。
            var user = UserList.SingleOrDefault(u => u.ContextID == Context.ConnectionId);
            //判断用户是否存在,否则添加进集合
            if (user == null)
            {
                user = new UserInfo()
                {
                    Name = "",
                    ContextID = Context.ConnectionId
                };
                UserList.Add(user);
            }
            return base.OnConnected();
        }
        /// <summary>
        /// 获取用户名和自己的唯一编码
        /// </summary>
        /// <param name="name"></param>
        public void GetName(string name)
        {
            // 查询用户。
            var user = UserList.SingleOrDefault(u => u.ContextID == Context.ConnectionId);
            if (user != null)
            {
                user.Name = name;
                Clients.Client(Context.ConnectionId).showID(Context.ConnectionId);
            }
            GetUserList();
        }

        /// <summary>
        /// 重写断开的事件
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            var user = UserList.Where(u => u.ContextID == Context.ConnectionId).FirstOrDefault();
            //判断用户是否存在,存在则删除
            if (user != null)
            {
                //删除用户
                UserList.Remove(user);
            }
            //更新所有用户的列表
            GetUserList();
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 更新所有用户的在线列表
        /// </summary>
        private void GetUserList()
        {
            var itme = from a in UserList
                       select new { a.Name, a.ContextID };
            string jsondata = JsonConvert.SerializeObject(itme.ToList());
            Clients.All.getUserlist(jsondata);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="contextID"></param>
        /// <param name="Message"></param>
        public void SendMessage(string contextID, string Message)
        {
            var user = UserList.Where(u => u.ContextID == contextID).FirstOrDefault();
            //判断用户是否存在,存在则发送
            if (user != null)
            {
                //给指定用户发送,把自己的ID传过去
                Clients.Client(contextID).addMessage(Message + " " + DateTime.Now, Context.ConnectionId);
                //给自己发送,把用户的ID传给自己
                Clients.Client(Context.ConnectionId).addMessage(Message + " " + DateTime.Now, contextID);
            }
            else
            {
                Clients.Client(Context.ConnectionId).showMessage("该用户已离线");
            }
        }



    }
}