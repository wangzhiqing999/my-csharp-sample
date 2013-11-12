using System;

namespace DesignPatterns.Strategy.Ducks
{

    /// <summary>
    /// 策略模式 中的 抽象策略对象(Strategy)
    /// 
    /// 飞行.
    /// </summary>
	public interface IFlyBehavior
	{
		object Fly();
	}


}
