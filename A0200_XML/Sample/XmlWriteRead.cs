using	System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0200_XML.Sample
{

	class XmlWriteRead
	{

		private	const String XML_FILE_NAME = "test.xml";


		///	<summary>
		///	写 XML
		///	</summary>
		public void	WriteXml()
		{
			// 构造写入类.
			// 第一个参数为 文件名
			// 第二个参数为编码方式.
			XmlTextWriter writer = new XmlTextWriter(XML_FILE_NAME,	Encoding.UTF8);

			//使用自动缩进便于阅读
			writer.Formatting =	Formatting.Indented;

			// 书写版本为“1.0”的 XML 声明
			writer.WriteStartDocument();


			// 写注释
			writer.WriteComment("XML文件写入的例子！");

			//写入根元素
			writer.WriteStartElement("items");

			// 加入属性： type="IT"
			writer.WriteStartAttribute("type");
			writer.WriteString("information");
			writer.WriteEndAttribute();

			writer.WriteStartAttribute("keyword");
			writer.WriteString("Database");
			writer.WriteEndAttribute();


			// 加入子元素： <title>SQL Server</title>	这种方式的。
			writer.WriteElementString("title", "SQL	Server");
			writer.WriteElementString("title", "Oracle");
			writer.WriteElementString("title", "MySQL");


			//关闭根元素，并书写结束标签
			writer.WriteEndElement();

			// 关闭任何打开的元素或属性
			writer.WriteEndDocument();

			//将XML写入文件并且关闭XmlTextWriter
			writer.Close();
		}



		///	<summary>
		///	读 XML
		///	</summary>
		public void	ReadXml()
		{
			// 构造读取器.
			XmlTextReader reader = new XmlTextReader(XML_FILE_NAME);


			// 依次读取.
			while (reader.Read())
			{
				// 根据读取到的 “当前节点的类型”	进行不同的处理.
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						Console.WriteLine("节点:{0} 开始", reader.Name);
						while (reader.MoveToNextAttribute())
						{
							Console.WriteLine("+--节点属性:{0} = {1}", reader.Name,	reader.Value);
						}

						break;

					case XmlNodeType.Text:
						Console.WriteLine("TEXT: {0}", reader.Value);
						break;

					case XmlNodeType.EndElement:
						Console.WriteLine("节点:{0} 结束", reader.Name);
						break;

					case XmlNodeType.Comment:
						Console.WriteLine("注释: {0}", reader.Value);
						break;

				}
			}


		}

	}

}
