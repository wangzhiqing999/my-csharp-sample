using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0012_OO_AutoProp.Sample
{


    /// <summary>
    /// 这个类  用于  创建/使用  Apple 类
    /// </summary>
    class UseApple
    {

        public void DemoAppleUse()
        {
            Console.WriteLine("对于 自动实现的属性 的使用，有下面2种方式：");

            Apple apple1 = new Apple();
            apple1.Country = "中国";
            apple1.Color = "红";
            Console.WriteLine(apple1.ToString());



            Apple apple2 = new Apple { Country = "中国", Color = "青" };
            Console.WriteLine(apple2.ToString());

        }
    }



}
