using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0551_PLINQ_Base2.Sample
{

	///	<summary>
	///	并行 LINQ 测试.
	///
	///	本测试主要用于演示
	///	  PLINQ	的 ForAll 操作 与 LINQ 的 foreach 操作之间的对比.
	///	</summary>
	public class Test
	{
		///	<summary>
		///	用于模拟一个长时间计算的方法.
		///	</summary>
		///	<param name="param"></param>
		///	<returns></returns>
		private	void LongTimeCompute(int param)
		{
			Console.WriteLine(param);
			Thread.Sleep(1000);
		}

		///	<summary>
		///	测试普通的处理.
		///	</summary>
		public void	TestNormal()
		{
			Console.WriteLine("普通LINQ处理开始："	+ DateTime.Now.ToString());
			// 一个1开始， 长度为 10 的序列.
			var	source = Enumerable.Range(1, 10);
			// 普通 LINQ。
			var	query =	from num in	source
						select num;
			foreach	(int val in	query)
			{
				// 模拟长时间操作.
				LongTimeCompute(val);
			}
			Console.WriteLine("普通LINQ处理结束："	+ DateTime.Now.ToString());
		}

		///	<summary>
		///	测试并行.
		///	</summary>
		public void	TestParallel()
		{
			Console.WriteLine("并行LINQ处理开始："	+ DateTime.Now.ToString());
			// 一个1开始， 长度为 10 的序列.
			var	source = Enumerable.Range(1, 10);
			// 并行 LINQ。
			var	query =	from num in	source.AsParallel()
						select num;
			// 遍历结果列表，模拟长时间操作.
			query.ForAll((e) =>	LongTimeCompute(e));
			Console.WriteLine("并行LINQ处理结束："	+ DateTime.Now.ToString());
		}
	}
}
