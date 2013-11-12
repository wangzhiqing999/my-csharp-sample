using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0070_CustomAttributes.Sample
{
	/// <summary>
	/// 这个类为其他类定义 附加属性
	/// </summary>
	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct)]
	class Creator : System.Attribute
	{        
		String name;
		String date;
		String version;

		/// <summary>
		/// 构造函数.
		/// </summary>
		/// <param name="name"> 用户名 </param>
		/// <param name="date"> 日期 </param>
		/// <param name="version"> 版本 </param>
		public Creator(String name, String date, String version)
		{
			this.name = name;
			this.date = date;
			this.version = version;
		}

		/// <summary>
		/// 显示细节信息.
		/// </summary>
		public void ShowInfo()
		{
			Console.WriteLine("name : {0}", name);
			Console.WriteLine("date : {0}", date);
			Console.WriteLine("version : {0}", version);
		}
	}
}
