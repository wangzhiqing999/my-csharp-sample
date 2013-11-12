using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.SampleChatroom
{

    /// <summary>
    /// 具体中介者
    /// </summary>
    class Chatroom : AbstractChatroom
    {

        /// <summary>
        /// 已注册的 同事 Dictionary.
        /// </summary>
        private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();


        /// <summary>
        /// 注册一个 “同事类”
        /// </summary>
        /// <param name="participant"></param>
        public override void Register(Participant participant)
        {
            // 将 同事类  加入 同事 Dictionary.
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            // 设置 同事类的  中介者 为 自己.
            participant.Chatroom = this;
        }



        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        public override void Send(string from, string to, string message)
        {
            // 获取 接收同事.
            Participant participant = _participants[to];

            if (participant != null)
            {
                // 调用 接收同事 的  接收方法.
                participant.Receive(from, message);
            }
        }
    }
}
