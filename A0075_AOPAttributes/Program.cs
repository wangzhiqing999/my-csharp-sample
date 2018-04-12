using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0075_AOPAttributes.Sample;

namespace A0075_AOPAttributes
{
	class Program
	{
		static void Main(string[] args)
		{

			ObjectClass obj = new ObjectClass();
			obj.Test1();
			obj.Test2("Test");
			obj.Test3(1024);
            Console.WriteLine("GetTest = {0}" , obj.GetTest());

			ObjectClassAOP objAop = new ObjectClassAOP();
			objAop.Test1();
			objAop.Test2("Test");
			objAop.Test3(1024);
            Console.WriteLine("GetTest = {0}", objAop.GetTest());

            Console.ReadLine();
		}
	}
}
