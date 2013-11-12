using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0550_PLINQ_Base1.Sample
{
	///	<summary>
	///	并行 LINQ	测试.
	///
	///	本测试主要用于演示
	///	  PLINQ	如何简单的使用	.AsParallel() 来实现 并行LINQ的处理。
	///	</summary>
	public class Test
	{
		///	<summary>
		///	用于模拟一个长时间计算的方法.
		///	</summary>
		///	<param name="param"></param>
		///	<returns></returns>
		private	int	Compute(int	param)
		{
			Thread.Sleep(10);
			return param % 2;
		}

		///	<summary>
		///	测试普通的处理.
		///	</summary>
		public void	TestNormal()
		{
			Console.WriteLine("普通LINQ处理开始："	+ DateTime.Now.ToString());
			// 临时结果存储.
			List<int> result;
			// 一个1开始， 长度为 1000 的序列.
			var	source = Enumerable.Range(1, 1000);
			// 普通 LINQ。
			var	query =	from num in	source
						   where Compute(num) >	0
						   select num;
			// 取得列表.
			result = query.ToList();
			Console.WriteLine("普通LINQ处理结束："	+ DateTime.Now.ToString());
		}


		///	<summary>
		///	测试并行.
		///	</summary>
		public void	TestParallel()
		{
			Console.WriteLine("并行LINQ处理开始："	+ DateTime.Now.ToString());
			// 临时结果存储.
			List<int> result;
			// 一个1开始， 长度为 1000 的序列.
			var	source = Enumerable.Range(1, 1000);
			// 并行 LINQ。
			var	query =	from num in	source.AsParallel()
						where Compute(num) > 0
						select num;
			// 取得列表.
			result = query.ToList();
			Console.WriteLine("并行LINQ处理结束："	+ DateTime.Now.ToString());
		}
	}
}
