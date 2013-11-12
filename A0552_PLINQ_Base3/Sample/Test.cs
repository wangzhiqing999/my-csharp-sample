using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0552_PLINQ_Base3.Sample
{
	///	<summary>
	///	并行 LINQ	测试.
	///
	///	本测试主要用于演示
	///	  PLINQ	的 ParallelEnumerable.Max/Min/Average/Sum/Count 操作
	///	  与 LINQ 的 Max/Min/Average/Sum/Count 操作之间的对比.
	///	</summary>
	public class Test
	{

		///	<summary>
		///	用于模拟一个长时间计算的方法.
		///	</summary>
		///	<param name="param"></param>
		///	<returns></returns>
		private	static int LongTimeCompute(int param)
		{
			//Console.WriteLine(param);
			Thread.Sleep(100);
			return param * 10;
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
						select LongTimeCompute(num);
			Console.WriteLine(
				String.Format("最大值：{0};最小值：{1};平均值{2};合计值{3};行数{4}",
					query.Max(), query.Min(), query.Average(),query.Sum(),query.Count()
					));
			Console.WriteLine("普通LINQ处理结束："	+ DateTime.Now.ToString());
			Console.WriteLine();
		}


		///	<summary>
		///	测试并行1.
		///	</summary>
		public void	TestParallel()
		{
			Console.WriteLine("并行LINQ处理开始："	+ DateTime.Now.ToString());
			// 一个1开始， 长度为 10 的序列.
			var	source = Enumerable.Range(1, 10);
			// 并行 LINQ。
			var	query =	from num in	source.AsParallel()
						select LongTimeCompute(num);
			Console.WriteLine(
				String.Format("最大值：{0};最小值：{1};平均值{2};合计值{3};行数{4}",
					query.Max(), query.Min(), query.Average(), query.Sum(),	query.Count()
					));
			Console.WriteLine("并行LINQ处理结束："	+ DateTime.Now.ToString());
			Console.WriteLine();
		}


		///	<summary>
		///	测试并行2.
		///	</summary>
		public void	TestParallel2()
		{
			Console.WriteLine("并行LINQ处理开始："	+ DateTime.Now.ToString());
			// 一个1开始， 长度为 10 的序列.
			var	source = Enumerable.Range(1, 10);
			// 并行 LINQ。
			var	query =	from num in	source.AsParallel()
						select num;
			// 定义一个	Func<PLinq中的对象,	返回值> 委托
			Func<int, int> convertMethod = LongTimeCompute;
			Console.WriteLine(
				String.Format("最大值：{0};最小值：{1};平均值{2}合计值{3};行数{4}",
					ParallelEnumerable.Max(query, convertMethod),
					ParallelEnumerable.Min(query, convertMethod),
					ParallelEnumerable.Average(query, convertMethod),
					ParallelEnumerable.Sum(query, convertMethod),
					ParallelEnumerable.Count(query)
					));
			Console.WriteLine("并行LINQ处理结束："	+ DateTime.Now.ToString());
			Console.WriteLine();
		}

	}
}
