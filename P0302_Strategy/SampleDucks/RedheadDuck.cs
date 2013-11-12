using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy.Ducks
{
    public class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
            base.SetQuackBehavior(new Quack2());
            base.SetFlyBehavoir(new FlyWithWings());
        }

        public override object Display()
        {
            return "我是一只红头鸭！";

        }
    }
}
