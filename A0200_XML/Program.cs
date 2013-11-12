using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0200_XML.Sample;

namespace A0200_XML
{
	class Program
	{
		static void	Main(string[] args)
		{
			XmlWriteRead xml = new XmlWriteRead();
			Console.WriteLine("开始写入	XML	数据");
			xml.WriteXml();
			Console.WriteLine("XML 数据 写入完毕！	开始读取！");

			xml.ReadXml();
			Console.WriteLine("XML 数据 读取完毕！");
			Console.ReadLine();
		}
	}
}
