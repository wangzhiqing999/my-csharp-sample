using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0070_CustomAttributes.Sample;

namespace A0070_CustomAttributes
{
	class Program
	{
		public static void PrintAttributeInfo(Type classType)
		{
			Console.WriteLine("{0}这个类的属性如下：", classType);
			object[] attr = classType.GetCustomAttributes(true);
			foreach (object o in attr)
			{
				Console.WriteLine("Attribute {0}", o);
				// 假如对象是 Creator 的实例，那么再调用 具体的方法.
				if (o is Creator)
				{
					((Creator)o).ShowInfo();
				}
			}
		}

		static void Main(string[] args)
		{
			PrintAttributeInfo(typeof(Test1));
			PrintAttributeInfo(typeof(Test2));
			PrintAttributeInfo(typeof(Test3));

			Console.ReadLine();
		}
	}
}
