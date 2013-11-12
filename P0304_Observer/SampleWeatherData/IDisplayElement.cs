using System;

namespace DesignPatterns.Observer.WeatherData
{

    /// <summary>
    /// 用于显示数据的接口.
    /// </summary>
	public interface IDisplayElement
	{
		object Display();
	}
}
