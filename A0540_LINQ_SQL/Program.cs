using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Linq.Mapping;

using A0540_LINQ_SQL.Sample;

namespace A0540_LINQ_SQL
{
	class Program
	{

		/// <summary>
		/// SQL Server 的数据库连接字符串.
		/// </summary>
		private const String connString =
			@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";

		static void Main(string[] args)
		{
			XmlMappingSource xms = XmlMappingSource.FromXml(File.ReadAllText("Test.map"));

			Test context = new Test(connString, xms);

			// 单表查询
			var query =
				from testMain in context.Test_main
				select testMain;
			foreach (Test_main main in query)
			{
				Console.WriteLine("Main[{0}, {1}]", main.Id, main.Value);
			}

			// 关联查询
			var query2 =
				from testSub in context.Test_sub
				where testSub.Test_main.Value == "ONE"
				select testSub;
			foreach (Test_sub sub in query2)
			{
				Console.WriteLine("Sub[{0}, {1}]", sub.Id, sub.Value);
			}

			// 插入.
			Test_main main3 = new Test_main();
			main3.Id = 3;
			main3.Value = "Three";
			context.Test_main.InsertOnSubmit(main3);
			context.SubmitChanges();

			Console.WriteLine("INSERT FINISH!");
			Console.ReadLine();

			// 更新.
			var newTestMain =
				(from testMain in context.Test_main
				 where testMain.Id == 3
				 select testMain).First();
			newTestMain.Value = "Three3";
			context.SubmitChanges();

			Console.WriteLine("UPDATE FINISH!");
			Console.ReadLine();


			// 单表查询 TOP 2
			var queryTop2 =
				(from testMain in context.Test_main
				 orderby testMain.Id descending
				 select testMain).Take(2);

			foreach (Test_main main in queryTop2)
			{
				Console.WriteLine("Main[{0}, {1}]", main.Id, main.Value);
			}

			// 删除.
			context.Test_main.DeleteOnSubmit(newTestMain);
			context.SubmitChanges();

			Console.WriteLine("DELETE FINISH!");
			Console.ReadLine();

		}
	}
}
