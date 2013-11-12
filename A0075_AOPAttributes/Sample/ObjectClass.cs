using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0075_AOPAttributes.Sample
{
	public class ObjectClass
	{
		public void Test1()
		{
			Console.WriteLine("Test");
		}
		public void Test2(string para)
		{
			Console.WriteLine("Test:" + para);
		}
		public void Test3(int para)
		{
			Console.WriteLine("Test:" + para);
		}
	}
}
