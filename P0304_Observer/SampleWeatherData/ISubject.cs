using System;

namespace DesignPatterns.Observer.WeatherData
{

    /// <summary>
    /// 观察者模式中的  抽象主题（Subject）角色
    /// 
    /// 主题角色把所有的观察者对象的引用保存在一个列表里；
	/// 每个主题都可以有任何数量的观察者。
	/// 主题提供一个接口可以加上或撤销观察者对象；主题角色又叫做抽象被观察者(Observable)角色； 
    /// 抽象主题角色，有时又叫做抽象被观察者角色，可以用一个抽象类或者一个接口实现；在具体的情况下也不排除使用具体类实现。
    /// 
    /// </summary>
	public interface ISubject
	{
        /// <summary>
        /// 增加一个 观察者
        /// </summary>
        /// <param name="o"></param>
		void RegisterObserver(IObserver o);

        /// <summary>
        /// 移除一个 观察者.
        /// </summary>
        /// <param name="o"></param>
		void RemoveObserver(IObserver o);


        /// <summary>
        /// 通知观察者。
        /// </summary>
		void NotifyObserver();
	}
}
