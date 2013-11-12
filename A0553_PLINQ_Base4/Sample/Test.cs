using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0553_PLINQ_Base4.Sample
{
	///	<summary>
	///	并行 LINQ 测试.
	///
	///	本测试主要用于演示
	///	  PLINQ	的 并行操作，是否影响排列顺序的问题。
	///	</summary>
	public class Test
	{

		///	<summary>
		///	用于模拟一个长时间计算的方法.
		///	</summary>
		///	<param name="param"></param>
		///	<returns></returns>
		private	int	LongTimeCompute(int	param)
		{
			// 当参数为	偶数的时候，少休眠一定时间。
			// 目的为了测试，当并行处理的时候，如果不加选项，将导致 打乱原有的排序。
			if (param %	2 == 1)
			{
				Thread.Sleep(100);
			}
			else
			{
				Thread.Sleep(50);
			}

			return param;
		}


		///	<summary>
		///	测试普通的处理.
		///	</summary>
		public void	TestNormal()
		{
			Console.WriteLine("普通LINQ处理开始："	+ DateTime.Now.ToString());
			// 一个1开始， 长度为 1000 的序列.
			var	source = Enumerable.Range(1, 1000);
			// 普通 LINQ。
			var	query =	from num in	source
						select LongTimeCompute(num);

			foreach	(int v in query.Take(100))
			{
				Console.Write("{0} ", v);
			}
			Console.WriteLine();
			Console.WriteLine("普通LINQ处理结束："	+ DateTime.Now.ToString());
			Console.WriteLine();
		}

		///	<summary>
		///	测试并行1.
		///	</summary>
		public void	TestParallel()
		{
			Console.WriteLine("并行LINQ处理开始："	+ DateTime.Now.ToString());

			// 一个1开始， 长度为 1000 的序列.
			var	source = Enumerable.Range(1, 1000);
			// 并行 LINQ。
			// 注：这里加了 .WithExecutionMode(ParallelExecutionMode.ForceParallelism) 要求	强制进行 并行处理.
			var	query =	from num in	source.AsParallel()
							.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
						select LongTimeCompute(num);

			// 由于没有加 .AsOrdered()，排列顺序可能不按预期方式排列.

			// 包含 Take、TakeWhile、Skip、SkipWhile 运算符并且源序列中的索引未采用原始顺序的查询。
			// 因此如果前面的地方，不加	.WithExecutionMode(ParallelExecutionMode.ForceParallelism) 的话
			// 将按照非	普通方式处理。
			foreach	(int v in query.Take(100))
			{
				Console.Write("{0} ", v);
			}

			Console.WriteLine();
			Console.WriteLine("并行LINQ处理结束："	+ DateTime.Now.ToString());
			Console.WriteLine();
		}

		///	<summary>
		///	测试并行2.
		///	</summary>
		public void	TestParalle2()
		{
			Console.WriteLine("并行LINQ处理开始："	+ DateTime.Now.ToString());

			// 一个1开始， 长度为 1000 的序列.
			var	source = Enumerable.Range(1, 1000);
			// 并行 LINQ。
			// 注：这里加了 .AsOrdered() 要求严格按照原有数据的排列顺序。
			// 注：这里加了 .WithExecutionMode(ParallelExecutionMode.ForceParallelism) 要求	强制进行 并行处理.
			var	query =	from num in	source.AsParallel().AsOrdered()
							.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
							//.WithMergeOptions(ParallelMergeOptions.NotBuffered)
						select LongTimeCompute(num);

			// 包含 Take、TakeWhile、Skip、SkipWhile	运算符并且源序列中的索引未采用原始顺序的查询。
			// 因此如果前面的地方，不加	.WithExecutionMode(ParallelExecutionMode.ForceParallelism) 的话
			// 将按照非	普通方式处理。
			foreach	(int v in query.Take(100))
			{
				Console.Write("{0} ", v);
			}
			Console.WriteLine();
			Console.WriteLine("并行LINQ处理结束："	+ DateTime.Now.ToString());
			Console.WriteLine();
		}
	}
}
