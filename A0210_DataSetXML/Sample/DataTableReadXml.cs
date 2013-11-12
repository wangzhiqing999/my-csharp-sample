using	System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace A0210_DataSetXML.Sample
{
	public class DataTableReadXml
	{
		///	<summary>
		///	配置文件名
		///	</summary>
		private	const string XML_FILE =	"Config.xml";

		///	<summary>
		///	DataTable。
		///	</summary>
		private	DataTable dataDt;

		///	<summary>
		///	构造函数
		///	</summary>
		public DataTableReadXml()
		{
			// 初始化表结构.s
			dataDt = new DataTable("MyTable");
			// 为表增加列的定义，共4列，1个Main 3个Sub [1-3]
			dataDt.Columns.Add("Main");
			for	(int i = 1;	i <= 3;	i++)
			{
				// 参数1.
				dataDt.Columns.Add("Sub" + i);
			}
		}

		///	<summary>
		///	暴露 DataTable 属性.
		///	</summary>
		public DataTable DataDt
		{
			get
			{
				return dataDt;
			}
		}

		///	<summary>
		///	读取配置信息.
		///	</summary>
		///	<returns></returns>
		public void	ReadConfig()
		{
			dataDt.ReadXml(XML_FILE);
		}

		///	<summary>
		///	写入配置信息
		///	</summary>
		public void	WriteConfig()
		{
			dataDt.WriteXml(XML_FILE);
		}
	}
}
