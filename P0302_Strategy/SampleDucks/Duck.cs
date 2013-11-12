using System;

namespace DesignPatterns.Strategy.Ducks
{
    public abstract class Duck
    {



        protected IFlyBehavior flyBehavior;
        protected IQuackBehavior quackBehavior;


        public object PerformFly()
        {
            return flyBehavior.Fly();
        }

        public object PerformQuack()
        {
            return quackBehavior.Quack();
        }


        public void SetQuackBehavior(IQuackBehavior qck)
        {
            this.quackBehavior = qck;
        }

        public void SetFlyBehavoir(IFlyBehavior fly)
        {
            this.flyBehavior = fly;
        }




        // Identify the aspects of your application that vary and separate them from what stays the same.
        // 找到系统中变化的部分，将变化的部分同其它稳定的部分隔开。

        // 上面的 叫 与 飞行 是可变的。
        // 需要单独使用不同的策略进行处理。


        public string Swim()
        {
            return "所有的鸭子都可以游泳！";
        }





        public abstract object Display();     
    }
}
