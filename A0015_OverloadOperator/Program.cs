using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0015_OverloadOperator.Sample;

namespace A0015_OverloadOperator
{
	class Program
	{

		static void Main(string[] args)
		{
			// 构造初始的序列号. 001
			MySequence sequence = new MySequence();
			Console.WriteLine(sequence);

			// 序列号: N99
			MySequence n99 = new MySequence("N99");
			// 序列号: P00
			MySequence p00 = new MySequence("P00");

			// 序列号 递增
			n99++;
			if (n99 == p00)
			{
				Console.WriteLine(n99);
			}


			// 序列号 递减
			p00--;
			if (n99 != p00)
			{
				Console.WriteLine(p00);
			}


			// 执行 n99 = n99 + 111.
			n99 += 111;
			Console.WriteLine(n99);


			Console.ReadLine();
		}
	}
}
