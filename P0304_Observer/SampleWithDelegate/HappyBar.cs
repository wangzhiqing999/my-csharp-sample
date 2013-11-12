using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0304_Observer.SampleWithDelegate
{
    /// <summary>
    /// 嗨皮吧 春游计划
    /// </summary>
    public class HappyBar
    {

        /// <summary>
        /// 定义委托
        /// </summary>
        public delegate void EventHandler();


        /// <summary>
        /// 定义一个事件，当发布活动的时候触发
        /// </summary>
        public event EventHandler GoUpdate;


        /// <summary>
        /// 发布活动的通知
        /// </summary>
        public void Notify()
        {
            GoUpdate();
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
