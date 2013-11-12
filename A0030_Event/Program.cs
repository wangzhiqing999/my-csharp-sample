using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0030_Event.Sample;

namespace A0030_Event
{
	class Program
	{

		/// <summary>
		/// 事件的操作代码.
		/// </summary>
		/// <param name="age"></param>
		/// <param name="obj"></param>
		/// <param name="cancel"></param>
		private static void MyAgeChangeHandler(int age, object obj, ref bool cancel)
		{
			Console.WriteLine("事件被触发！");

			if (age < 0)
			{
				Console.WriteLine("年龄小于0，不允许修改！");
				cancel = true;
			}
		}

		static void Main(string[] args)
		{

			Console.WriteLine("=====注册了事件处理的=====");
			// 构造类.
			Person p1 = new Person();
			// 注册事件.
			p1.AgeChange += new AgeChangeHandler(MyAgeChangeHandler);
			Console.WriteLine("准备调用 Age = 50");
			p1.Age = 50;
			Console.WriteLine("调用后Age = {0}", p1.Age);

			Console.WriteLine("准备调用 Age = -1");
			p1.Age = -1;
			Console.WriteLine("调用后Age = {0}", p1.Age);


			Console.WriteLine("=====没有注册事件处理的=====");
			// 构造类.
			Person p2 = new Person();
			Console.WriteLine("准备调用 Age = 50");
			p2.Age = 50;
			Console.WriteLine("调用后Age = {0}", p2.Age);

			Console.WriteLine("准备调用 Age = -1");
			p2.Age = -1;
			Console.WriteLine("调用后Age = {0}", p2.Age);

			Console.ReadLine();

		}
	}
}
