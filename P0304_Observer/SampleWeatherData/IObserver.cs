using System;

namespace DesignPatterns.Observer.WeatherData
{


    /// <summary>
    /// 观察者模式中的 抽象观察者（Observer）角色
    /// 
    /// 为所有的具体观察者定义一个接口，在得到通知时更新自己； 
    ///    抽象观察者角色，可以用一个抽象类或者一个接口实现；在具体的情况下也不排除使用具体类实现。  
    /// </summary>
    public interface IObserver
    {

        /// <summary>
        /// 更新方法。
        /// </summary>
        /// <param name="temperature">温度</param>
        /// <param name="humidity">湿度</param>
        /// <param name="pressure">大气压力</param>
        void Update(float temperature, float humidity, float pressure);

    }
}
