using System;

namespace DesignPatterns.Strategy.Ducks
{

    /// <summary>
    /// 策略模式 中的 抽象策略对象(Strategy)
    /// 
    /// 叫.
    /// </summary>
	public interface IQuackBehavior
	{
		string Quack();
	}
}
