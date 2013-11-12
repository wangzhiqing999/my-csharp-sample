using System;

namespace DesignPatterns.Strategy.Ducks
{
	public class RubberDuck : Duck
	{
		public RubberDuck()
		{
            base.SetQuackBehavior(new Quack3());
            base.SetFlyBehavoir(new FlyNoWay());
		}

		public override object Display()
		{
			return "我是一个橡皮鸭子！";
		}
	}
}
