using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0304_Observer.SampleWithDelegate
{
    /// <summary>
    /// 嗨皮吧QQ群成员类
    /// </summary>
    public class QQMember
    {
        /// <summary>
        /// 参与人姓名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 该参与人需要关注的通知来源
        /// </summary>
        public HappyBar happyBar { get; set; }


        /// <summary>
        /// 实际行动，根据活动信息前往目的地
        /// </summary>
        public void GoToUpdate()
        {
            Console.WriteLine("{0} 正在前往 {1}..", Name, happyBar.PublishInfo);
        }
    }
}
