using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0206_Flyweight.Simple
{
    /// <summary>
    /// 客户端(Client)角色：
    /// 需要维护一个对所有享元对象的引用;需要自行存储所有享元对象外蕴状态。
    /// </summary>
    public class Client
    {
        public void Test()
        {
            Console.WriteLine("单纯享元模式");


            // 初始化 享元工厂
            FlyweightFactory factory = new FlyweightFactory();

            // 通过享元工厂类来创建享元类
            IFlyweight fly=factory.Factory('a');
            fly.Operation("罗马字符"); 

            fly = factory.Factory('b');  
            fly.Operation("阿拉伯字符");

            fly = factory.Factory('a');
            fly.Operation("阿拉伯字符");

            fly = factory.Factory('b');
            fly.Operation("罗马字符");
        }
    }
}
