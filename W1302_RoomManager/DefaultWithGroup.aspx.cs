using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W1302_RoomManager
{
    public partial class DefaultWithGroup : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            // 本项目是在 W1300_SignalR 项目的基础上。
            // 测试 一个网站， 同时支持多个 聊天室的 情况.
            // 每个 聊天室有一个 roomid 来做区分.

            // 目前的逻辑， 是 客户端调用的时候， 先 init 自己的 Group.
            // 然后， 发送消息的时候， 带上自己的 Group.


            // 测试方式：开4个浏览器页面
            // 其中2个打开.
            //  http://localhost:1867/DefaultWithGroup.aspx

            // 另外2个打开.
            //  http://localhost:1867/DefaultWithGroup.aspx?id=test

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