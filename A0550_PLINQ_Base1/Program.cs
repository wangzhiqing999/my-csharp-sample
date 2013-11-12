using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0550_PLINQ_Base1.Sample;

namespace A0550_PLINQ_Base1
{
	class Program
	{
		static void	Main(string[] args)
		{
			Test t = new Test();
			t.TestNormal();
			t.TestParallel();
			Console.ReadLine();
		}
	}
}
