using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Observer.WeatherData
{

    public class Demo
    {
        public static void ShowDemo()
        {
            Console.WriteLine("天气信息的 观察者模式 演示");

            // 首先创建一个 主题对象.
            WeatherData wd = new WeatherData();


            // 创建2个不同类型的  观察者.
            StatisticsDisplay o1 = new StatisticsDisplay(wd);
            ForcastDisplay o2 = new ForcastDisplay(wd);


            // 数据未变化前， 先显示一次.
            Console.WriteLine(o1.Display());
            Console.WriteLine(o2.Display());

            // 主题对象数据开始变化.
            wd.SetMeasurements(50, 60, 70);

            // 数据变化， 显示一次.  核对数据变化是否成功通知观察者了.
            Console.WriteLine(o1.Display());
            Console.WriteLine(o2.Display());

            // 主题对象数据再次变化.
            wd.SetMeasurements(60, 70, 80);

            // 数据变化， 显示一次.  核对数据变化是否成功通知观察者了.
            Console.WriteLine(o1.Display());
            Console.WriteLine(o2.Display());


            // 主题对象数据再次变化.
            wd.SetMeasurements(40, 50, 60);

            // 数据变化， 显示一次.  核对数据变化是否成功通知观察者了.
            Console.WriteLine(o1.Display());
            Console.WriteLine(o2.Display());

        }
    }
}
