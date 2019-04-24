using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data;
using System.Data.OleDb;


namespace A0151_Excel.Sample
{

	/// <summary>
	/// 创建 并 写入 Excel
	/// </summary>
	public class CreateWriteExcel
	{


		/// <summary>
		/// 建表语句.
		/// </summary>
		private const string CREATE_TABLE_SQL =
			@"CREATE TABLE [测试表格1] (
[编号] INT,
[名称] VARCHAR,
[成绩] INT
)
";


		/// <summary>
		/// 插入语句.
		/// </summary>
		private const string INSERT_SQL =
			@"INSERT INTO  [测试表格1] (
[编号] , [名称] , [成绩]
) VALUES (
?, ?, ?
)
";


		/// <summary>
		/// 更新语句.
		/// </summary>
		private const string UPDATE_SQL =
			@"UPDATE [测试表格1]
SET
  [名称] = ?,
  [成绩] = ?
WHERE
  [编号] = ?
";


		/// <summary>
		/// 删除语句.
		/// </summary>
		private const string DELETE_SQL =
			@"DELETE FROM [测试表格1]
WHERE
  [编号] = ?
";




		/// <summary>
		/// 测试写入 Excel 文件.
		/// </summary>
		/// <param name="fileName"> 文件名 </param>
		public void TestWriteExcel(string fileName)
		{

			// 如果文件已存在，那么删除.
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}


			// 取得连接字符串.
			string connString = Common.GetOleDbConnectionString(fileName);

			// 定义 Oledb 的数据库联接.
			OleDbConnection cn = new OleDbConnection(connString);

			try
			{
				// 打开连接.
				cn.Open();

				// 创建 Excel Sheet的 命令.
				OleDbCommand cmdCreate = new OleDbCommand(CREATE_TABLE_SQL, cn);
				// 创建Sheet.
				cmdCreate.ExecuteNonQuery();

				// 插入数据的 命令.
				OleDbCommand cmdInsert = new OleDbCommand(INSERT_SQL, cn);
				for (int i = 0; i < 10; i++)
				{
					// 清空参数.
					cmdInsert.Parameters.Clear();
					// 参数只能按照 SQL语句 中 ? 的顺序，进行添加.
					cmdInsert.Parameters.Add(new OleDbParameter("?", i));
					cmdInsert.Parameters.Add(new OleDbParameter("?", "名称" + i));
					cmdInsert.Parameters.Add(new OleDbParameter("?", i*10 ));
					// 插入数据.
					cmdInsert.ExecuteNonQuery();
				}




				// 尝试修改一行.
				OleDbCommand cmdUpdate = new OleDbCommand(UPDATE_SQL, cn);
				// 参数只能按照 SQL语句 中 ? 的顺序，进行添加.
				cmdUpdate.Parameters.Add(new OleDbParameter("?", "名称X1X"));
				cmdUpdate.Parameters.Add(new OleDbParameter("?", 100));
				cmdUpdate.Parameters.Add(new OleDbParameter("?", 1));
				// 修改数据.
				cmdUpdate.ExecuteNonQuery();




				// 注: 删除一行的操作，将抛出异常.

                /*
				// 尝试删除一行.
				OleDbCommand cmdDelete = new OleDbCommand(DELETE_SQL, cn);
				// 参数只能按照 SQL语句 中 ? 的顺序，进行添加.
				cmdDelete.Parameters.Add(new OleDbParameter("?", 2));
				// 修改数据.
				cmdDelete.ExecuteNonQuery();
                */




			}
			catch (Exception ex)
			{
				Console.WriteLine("数据库读写操作发生了错误！");
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
		}



	}


}
