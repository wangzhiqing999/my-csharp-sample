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
	public class StatisticsDisplay : IObserver, IDisplayElement
	{
		#region Members

		private float maxTemp = 0.0f;
		private float minTemp = 200;//set intial high so that minimum 
									//is set first invokation
		private float temperatureSum = 0.0f;
		private int numReadings = 0;
		
        /// <summary>
        /// 主题对象
        /// </summary>
        private ISubject weatherData;


		#endregion//Members

		#region NumberOfReadings Property

		public int NumberOfReadings
		{
			get
			{
				return numReadings;
			}
		}

		#endregion//NumberOfReadings Property

		


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="weatherData"></param>
		public StatisticsDisplay(ISubject weatherData)
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
			temperatureSum += temperature;
			numReadings++;

			if (temperature > maxTemp) 
			{
				maxTemp = temperature;
			}
 
			if (temperature < minTemp) 
			{
				minTemp = temperature;
			}
		}

		#endregion



		#region IDisplayElement Members


		public object Display()
		{
			return String.Format(
                    "平均/最高/最低 温度 = {0}F/ {1}F/ {2}F", 
                    RoundFloatToString(temperatureSum / numReadings) ,
				    maxTemp,
                    minTemp);
		}

		#endregion



		#region RoundFloatToString

		public static string RoundFloatToString(float floatToRound)
		{
			System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
			cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;
			cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
			return floatToRound.ToString("F",cultureInfo);
		}
		#endregion//RoundFloatToString

	}
}
