using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0304_Observer.SampleWithDelegate
{
    public class Demo
    {
        public static void ShowDemo()
        {
            Console.WriteLine("春游活动的 观察者模式 演示 (使用 C# 的 delegate 机制) ");

            HappyBar hb = new HappyBar();

            QQMember member1 = new QQMember() { Name = "张三", happyBar = hb };
            QQMember member2 = new QQMember() { Name = "李四", happyBar = hb };

            hb.PublishInfo = " 怀柔水长城 时间：2012年4月XX日";
            hb.GoUpdate += new HappyBar.EventHandler(member1.GoToUpdate);
            hb.GoUpdate += new HappyBar.EventHandler(member2.GoToUpdate);

            hb.Notify();

        }
    }
}
