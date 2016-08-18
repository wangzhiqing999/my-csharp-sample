using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.SignalR;


namespace W1302_RoomManager.Test
{
    public class UserContext
    {
        public UserContext()
        {
            Users = new List<User>();
            Connections = new List<Connection>();
            Rooms = new List<ConversationRoom>();
        }
        //用户集合
        public List<User> Users { get; set; }
        //连接集合
        public List<Connection> Connections { get; set; }
        //房间集合
        public List<ConversationRoom> Rooms { get; set; }
    }

    public class User
    {
        [Key]
        //用户名
        public string UserName { get; set; }
        //用户的连接
        public List<Connection> Connections { get; set; }
        //用户房间集合
        public virtual List<ConversationRoom> Rooms { get; set; }

        public User()
        {
            Connections = new List<Connection>();
            Rooms = new List<ConversationRoom>();
        }
    }

    public class Connection
    {
        //连接ID
        public string ConnectionID { get; set; }

        //用户代理
        public string UserAgent { get; set; }
        //是否连接
        public bool Connected { get; set; }
    }

    /// <summary>
    /// 房间类
    /// </summary>
    public class ConversationRoom
    {
        //房间名称
        [Key]
        public string RoomName { get; set; }
        //用户集合
        public virtual List<User> Users { get; set; }


        public ConversationRoom()
        {
            Users = new List<User>();
        }
    }
}