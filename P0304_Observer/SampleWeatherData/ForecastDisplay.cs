using System;
using System.Text;

namespace DesignPatterns.Observer.WeatherData
{

    /// <summary>
    /// 观察者模式中的 具体观察者（ConcreteObserver）角色
    /// 保存一个指向具体主题对象的引用；和一个与主题的状态相符的状态。
    /// 具体观察者角色实现抽象观察者角色所要求的更新自己的接口，以便使本身的状态与主题的状态自恰。 
    /// 具体观察者角色，通常用一个具体子类实现。
    /// </summary>
	public class ForcastDisplay : IObserver, IDisplayElement
    {
        #region Members

        private float currentPressure = 29.92f;  
		private float lastPressure;


        /// <summary>
        /// 主题对象
        /// </summary>
		private ISubject weatherData;


        #endregion


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="weatherData"></param>
        public ForcastDisplay(ISubject weatherData)
		{
            // 设置 主题对象
			this.weatherData = weatherData;

            // 向主题对象 注册观察者.
            // 也就是当 主题对象 对象发生变化了，通知当前这个类.
			weatherData.RegisterObserver(this);
		}




		#region IObserver Members


        /// <summary>
        /// 当主题对象数据变化后， 通知当前这个类时， 将调用本方法.
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="humidity"></param>
        /// <param name="pressure"></param>
		public void Update(float temperature, float humidity, float pressure)
		{
			lastPressure = currentPressure;
			currentPressure = pressure;
		}


		#endregion



		#region IDisplayElement Members

		public object Display()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("Forecast: ");
			
			if(currentPressure > lastPressure) 
			{
				sb.Append("Improving weather on the way!");
			}
			else if (currentPressure == lastPressure)
			{
				sb.Append("More of the same");
			} 
			else if (currentPressure < lastPressure)
			{
				sb.Append("Watch out for cooler, rainy weather");
			}
			return sb.ToString();
		}

		#endregion
	}
}
