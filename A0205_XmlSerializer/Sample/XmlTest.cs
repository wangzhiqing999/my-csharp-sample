using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace A0205_XmlSerializer.Sample
{
	/// <summary>
	/// 这里测试一个 使用 XmlSerializer 读写 XML 文件的例子.
	/// </summary>
	public class XmlTest
	{

		private const string FILE_NAME = "OrangeStorage.xml";

        private const string FILE_NAME_GB2312 = "OrangeStorage_GB2312.xml";

		/// <summary>
		/// 测试写入数据.
		/// </summary>
		public void TestWrite()
		{
			OrangeStorage storage = new OrangeStorage();
			storage.StorageName = "Test";



			Orange o1 = new Orange(1, "中国", "红", "甜");
			Orange o2 = new Orange(2, "美国", "黄", "酸");


			storage.OrangeArray = new Orange[2];

			storage.OneOrange = o1;

			storage.OrangeArray[0] = o1;
			storage.OrangeArray[1] = o2;


			storage.OrangeList = new List<Orange>();

			storage.OrangeList.Add(o1);
			storage.OrangeList.Add(o2);



            // 输出 UTF-8 的 XML 文件.
			XmlSerializer xs = new XmlSerializer(typeof(OrangeStorage));
			StreamWriter sw = new StreamWriter(FILE_NAME);
			xs.Serialize(sw, storage);
			sw.Close();



            // 输出 GB2312 的 XML 文件.
            string xml = XmlUtility.XmlSerialize<OrangeStorage>(storage);
            File.WriteAllText(FILE_NAME_GB2312, xml, Encoding.GetEncoding("GB2312"));

		}


		/// <summary>
		/// 测试读取.
		/// </summary>
		public void TestRead()
		{

            Console.WriteLine("读取 UTF-8 格式 XML 文件.");
			XmlSerializer xs = new XmlSerializer(typeof(OrangeStorage));
			StreamReader sr = new StreamReader(FILE_NAME);
			OrangeStorage storage = xs.Deserialize(sr) as OrangeStorage;
			sr.Close();


			Console.WriteLine(storage.StorageName);
			Console.WriteLine(storage.OneOrange);

			foreach (Orange o in storage.OrangeArray)
			{
				Console.WriteLine(o.ToString());
			}

			foreach (Orange o in storage.OrangeList)
			{
				Console.WriteLine(o.ToString());
			}



            Console.WriteLine("读取 GB2312 格式 XML 文件.");
            string xml = File.ReadAllText(FILE_NAME_GB2312, Encoding.GetEncoding("GB2312"));
            storage = XmlUtility.XmlDeserialize<OrangeStorage>(xml);


            Console.WriteLine(storage.StorageName);
            Console.WriteLine(storage.OneOrange);

            foreach (Orange o in storage.OrangeArray)
            {
                Console.WriteLine(o.ToString());
            }

            foreach (Orange o in storage.OrangeList)
            {
                Console.WriteLine(o.ToString());
            }
		}

	}



	/// <summary>
	/// 用于 保存数据 的类.
	/// </summary>
	public class OrangeStorage
	{


		/// <summary>
		/// 商店名.
		/// </summary>
		public string StorageName { set; get; }


		/// <summary>
		/// 一个桔子.
		/// </summary>
		public Orange OneOrange { set; get; }


		/// <summary>
		/// 桔子数组.
		/// </summary>
		[XmlElement("Oranges")]
		public Orange [] OrangeArray { set; get; }


		/// <summary>
		/// 桔子列表.
		/// </summary>
		public List<Orange> OrangeList { set; get; }
	}



	/// <summary>
	/// 用于 保存数据 的类.
	/// </summary>
	public class Orange
	{

		/// <summary>
		/// 默认的无参数的的构造函数必须要有.
		/// </summary>
		public Orange()
		{
		}


		public Orange(int id, string country, String color, String sapor)
		{
			this.Number = id;
			this.Country = country;
			this.Color = color;
			this.Sapor = sapor;
		}

		/// <summary>
		/// 编号
		/// 请注意这里使用了 XmlAttribute
		/// 所产生的 XML 文件中，与其他属性的不同.
		/// </summary>
		[XmlAttribute("Number")]
		public int Number { set; get; }


		/// <summary>
		/// 国家
		/// </summary>
		public String Country
		{
			get;
			set;
		}

		/// <summary>
		/// 颜色.
		/// </summary>
		public String Color
		{
			get;
			set;
		}

		/// <summary>
		/// 味道
		/// 请注意这里使用了 XmlIgnoreAttribute
		/// 因此这个字段将被忽略，不写入 XML 文件中.
		/// </summary>
		[XmlIgnoreAttribute()]
		public String Sapor
		{
			get;
			set;
		}


		public override string ToString()
		{
			return Country + "产" + Color + "色" + Sapor + "桔子";
		}

	}

}
