using	System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0210_DataSetXML.Sample;


namespace A0210_DataSetXML
{
	class Program
	{



		static void	Main(string[] args)
		{
			DataTableReadXml config	= new DataTableReadXml();

			// 新建一行
			DataRow	row	= config.DataDt.NewRow();

			row["Main"]	= "测试机型";

			for	(int i = 1;	i <= 3;	i++)
			{
				// 参数1.
				row["Sub" +	i] = "==参数==" +	i;
			}


			// 行 加入	表
			config.DataDt.Rows.Add(row);

			// 保存.
			config.WriteConfig();

			// 等待用户输入回车
			// 这个时候去检查 文件输出了没有
			Console.ReadLine();


			// 测试 配置文件读取.
			DataTableReadXml config2 = new DataTableReadXml();

			config2.ReadConfig();

			foreach	(DataRow row2 in config2.DataDt.Rows)
			{
				Console.WriteLine(row2["Main"]);
				for	(int i = 1;	i <= 3;	i++)
				{
					// 参数1.
					Console.WriteLine(row2["Sub" + i]);
				}
			}

			// 等待用户输入回车
			Console.ReadLine();
		}





		//static void Main(string[]	args)
		//{

		//	  DataSetReadXml sample	= new DataSetReadXml();

		//	  DataSet ds = sample.ReadConfig("AutoMail.xml");




		//	  foreach (DataTable dt	in ds.Tables)
		//	  {
		//		  Console.WriteLine("表：{0}", dt.TableName);

		//		  Console.WriteLine("==========标题==========");
		//		  foreach (DataColumn dc in	dt.Columns)
		//		  {
		//			  Console.WriteLine(dc.ColumnName);
		//		  }


		//		  Console.WriteLine("==========数据==========");
		//		  foreach (DataRow dr in dt.Rows)
		//		  {
		//			  foreach (DataColumn dc in	dt.Columns)
		//			  {
		//				  Console.WriteLine(dr[dc]);
		//			  }
		//		  }
		//	  }


		//	  Console.ReadLine();
		//}



	}
}
