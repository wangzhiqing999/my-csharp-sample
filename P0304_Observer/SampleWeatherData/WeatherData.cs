using System;
using System.Collections.Generic;

namespace DesignPatterns.Observer.WeatherData
{


    /// <summary>
    /// 观察者模式中的  具体主题（ConcreteSubject）角色
    /// 
    ///   保存对具体观察者对象有用的内部状态；在这种内部状态改变时给其观察者发出一个通知；
    ///   具体主题角色又叫作具体被观察者角色；
    ///   具体主题角色，通常用一个具体子类实现。  
    /// </summary>
	public class WeatherData : ISubject
	{
        /// <summary>
        /// 观察者列表.
        /// </summary>
        private List<IObserver> observers;


        #region 内部数据的部分.

        /// <summary>
        /// 温度
        /// </summary>
		private float temperature;

        /// <summary>
        /// 湿度
        /// </summary>
		private float humidity;

        /// <summary>
        /// 大气压力
        /// </summary>
		private float pressure;


        #endregion



        /// <summary>
        /// 构造函数。
        /// </summary>
        public WeatherData()
		{
            // 初始化  观察者列表
            observers = new List<IObserver>();
		}




        #region ISubject Members  实现抽象主题（Subject）角色的 方法.


        /// <summary>
        /// 增加一个 观察者
        /// </summary>
        /// <param name="o"></param>
        public void RegisterObserver(IObserver o)
		{
			observers.Add(o);
		}


        /// <summary>
        /// 移除一个 观察者.
        /// </summary>
        /// <param name="o"></param>
		public void RemoveObserver(IObserver o)
		{
			int i = observers.IndexOf(o);
			if(i >= 0)
			{
				observers.Remove(o);
			}
		}


        /// <summary>
        /// 通知观察者。
        /// </summary>
		public void NotifyObserver()
		{
			foreach(IObserver observer in observers)
			{
				observer.Update(temperature,humidity,pressure);
			}
		}


		#endregion

		
        
        



        public void MeasurementsChanged()
		{
			NotifyObserver();
		}

        /// <summary>
        /// 修改数据的方法
        /// 
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="humidity"></param>
        /// <param name="pressure"></param>
		public void SetMeasurements(float temperature, float humidity,
			float pressure)
		{
			this.temperature = temperature;
			this.humidity = humidity;
			this.pressure = pressure;

            // 数据修改完毕后， 通知观察者
			MeasurementsChanged();
		}
	}
}
