using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.SampleChatroom
{

    /// <summary>
    /// 抽象同事.
    /// </summary>
    class Participant
    {
        /// <summary>
        /// 聊天室  （中介者）  的引用.
        /// </summary>
        private Chatroom _chatroom;


        private string _name;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        public Participant(string name)
        {
            this._name = name;
        }

        // Gets participant name
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// 聊天室  （中介者）  属性.
        /// </summary>
        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }


        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="message"></param>
        public void Send(string to, string message)
        {
            // 发送消息时， 是通过 中介者 发送.
            _chatroom.Send(_name, to, message);
        }

        
        /// <summary>
        /// 接收消息.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="message"></param>
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }

    }


    /// <summary>
    /// 具体同事.
    /// 
    /// A 'ConcreteColleague' class
    /// </summary>
    class Admin : Participant
    {

        // Constructor
        public Admin(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("Admin 接收到一个消息...");
            base.Receive(from, message);
        }

    }


    /// <summary>
    /// 具体同事.
    /// 
    /// A 'ConcreteColleague' class
    /// </summary>
    class NonAdmin : Participant
    {
        // Constructor
        public NonAdmin(string name)
            : base(name)
        {
        }

        /// <summary>
        /// 接收消息.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="message"></param>
        public override void Receive(string from, string message)
        {
            Console.Write("non-Admin 接收到一个消息...");
            base.Receive(from, message);
        }
    }
}
