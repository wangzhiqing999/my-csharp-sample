using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0304_Observer.SampleHappyBar
{
    public class Demo
    {
        public static void ShowDemo()
        {
            Console.WriteLine("春游活动的 观察者模式 演示");


            //春游活动组织发起者
            HappyBar bar = new HappyBar();

            IObserver memberZhang = new QQMember() { Name = "张智", happyBar = bar };
            IObserver memberDing = new QQMember() { Name = "丁朝阳", happyBar = bar };
            IObserver memberZheng = new QQMember() { Name = "郑亚敏", happyBar = bar };

            bar.Attach(memberZhang); //张智参加活动
            bar.Attach(memberDing);  //丁朝阳参加活动
            bar.Attach(memberZheng); //郑亚敏参加互动

            bar.Detach(memberZhang); //张智临时有事，取消活动

            //设置活动信息
            bar.PublishInfo = " 怀柔水长城 时间：2012年4月XX日";

            //发起活动及通知
            bar.Notify();
        }
    }
}
