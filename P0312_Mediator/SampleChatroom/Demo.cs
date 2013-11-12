using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.SampleChatroom
{
    public class Demo
    {


        public static void ShowDemo()
        {
            Console.WriteLine("##### 一个聊天室的 中介. #####");

            // Create chatroom
            Chatroom chatroom = new Chatroom();


            // Create participants and register them
            Participant George = new NonAdmin("张三");
            Participant Paul = new NonAdmin("李四");
            Participant Ringo = new NonAdmin("王五");
            Participant John = new NonAdmin("赵六");
            Participant Yoko = new Admin("田七");



            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);



            // Chatting participants

            Yoko.Send("赵六", "你好， 赵六!");
            Paul.Send("王五", "服务器有点卡。");
            Ringo.Send("张三", "测试测试...");
            Paul.Send("赵六", "你那里网络卡不卡？");
            John.Send("田七", "服务器是不是挂了？ 管理员。");


        }


    }
}
