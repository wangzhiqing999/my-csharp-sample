using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W1302_RoomManager
{
    public partial class Default : System.Web.UI.Page
    {


        
        protected void Page_Load(object sender, EventArgs e)
        {


            // 本项目是在 W1300_SignalR 项目的基础上。
            // 测试 一个网站， 同时支持多个 聊天室的 情况.
            // 每个 聊天室有一个 roomid 来做区分.

            // 目前的逻辑， 是 客户端调用的时候， 判断， roomid 是不是自己的。
            // 此算法有一定的缺陷。
            // 因为服务端没有做判断
            // 例如有 1，2，3  三个聊天室。
            // 1聊天室发出的消息。    2，3 聊天室 也收到消息了， 只是没有做显示处理。


            // 测试方式：开4个浏览器页面
            // 其中2个打开.
            //  http://localhost:1867/Default.aspx

            // 另外2个打开.
            //  http://localhost:1867/Default.aspx?id=test

            // 观察 默认聊天室的消息， 与 test 聊天室的消息，是否存在冲突.

            string roomId = Request["id"];

            if (String.IsNullOrEmpty(roomId))
            {
                roomId = "Default";
            }

            this.roomId.Value = roomId;

        }
    }
}