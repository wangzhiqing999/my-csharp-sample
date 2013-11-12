using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0005_Reflection.Sample
{
	/// <summary>
	/// 用于测试 反射 的对象类
	/// </summary>
	public class ObjectClass
	{

		/// <summary>
		/// 用于测试的属性.
		/// </summary>
		public String TestProp { set; get; }


		/// <summary>
		/// 用于测试 不带返回值的方法.
		/// </summary>
		public void HelloWorld()
		{
			Console.WriteLine("Hello World.");
		}

		/// <summary>
		/// 用于测试 带返回值的方法.
		/// </summary>
		/// <returns></returns>
		public String GetHelloWorld()
		{
			return "Hello World";
		}


		/// <summary>
		/// 用于测试 带参数 带返回值的 方法.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public String GetHelloWorld(String name)
		{
			return "Hello World " + name;
		}

	}



}
