using System;

namespace DesignPatterns.Strategy.Ducks
{

    /// <summary>
    /// 策略模式 中的 具体策略对象(ConcreteStrategy)
    /// 它封装了实现同不功能的不同算法。 
    /// 
    /// </summary>
	public class FlyWithWings : IFlyBehavior
	{
		public FlyWithWings()
		{}

		#region IFlyBehavior Members

		public object Fly()
		{
			return "我飞啦！";
		}

		#endregion
	}
}
