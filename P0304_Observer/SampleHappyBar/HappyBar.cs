using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0304_Observer.SampleHappyBar
{
    /// <summary>
    /// 嗨皮吧 春游计划
    /// </summary>
    public class HappyBar : ISubject
    {
        //维护QQ群报名参与活动的成员
        List<IObserver> memberList = new List<IObserver>();

        /// <summary>
        /// 增加参与活动的成员
        /// </summary>
        /// <param name="member">参与活动的成员</param>
        public void Attach(IObserver member)
        {
            memberList.Add(member);
        }

        /// <summary>
        /// 移除活动的成员
        /// </summary>
        /// <param name="member"></param>
        public void Detach(IObserver member)
        {
            memberList.Remove(member);
        }

        /// <summary>
        /// 发布活动的通知
        /// </summary>
        public void Notify()
        {
            memberList.ForEach(p => p.GoUpdate());
        }

        /// <summary>
        /// 活动发布的信息
        /// </summary>
        public string PublishInfo
        {
            get;
            set;
        }
    }
}
