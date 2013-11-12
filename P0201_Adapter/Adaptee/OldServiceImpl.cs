using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0201_Adapter.Adaptee
{

    /// <summary>
    /// 这个类是 “适配器”模式中的 源（Adaptee）
    /// 
    /// 也就是 需要适配的类。
    /// </summary>
    public class OldServiceImpl
    {
        public void SayHelloworld()
        {
            Console.WriteLine("旧系统/或者其他系统 中的实现！ Hello World！");
        }
    }
}
