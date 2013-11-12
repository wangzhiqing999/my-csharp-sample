using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace A0013_OO_Constructor.Sample
{
    
    /// <summary>
    /// 
    /// 这个类用于 演示 构造函数 与 析构函数 的例子
    /// 
    /// 构造函数 在 类构造的时候， 从 XML 文件加载数据 （如果文件存在的话，就加载）
    /// 
    /// 析构函数 在 类释放的时候，将数据写入 XML 文件。
    /// 
    /// </summary>
    public class Test
    {

        /// <summary>
        /// 保存数据的 XML 文件.
        /// </summary>
        private const string XML_FILE_NAME = "Test.xml";


        /// <summary>
        /// 测试保存的数据.
        /// </summary>
        public Int32 TestValue { set; get; }



        /// <summary>
        /// 构造函数.
        /// </summary>
        public Test()
        {

            if (File.Exists(XML_FILE_NAME))
            {
                // 文件存在.
                // 加载.
                XmlSerializer xs = new XmlSerializer(typeof(Int32));
                StreamReader sr = new StreamReader(XML_FILE_NAME);
                TestValue = (Int32) xs.Deserialize(sr);
                sr.Close();
            }

        }



        /// <summary>
        /// 析构函数
        /// </summary>
        ~Test()
        {
            // 将 数据写入 XML 文件.
            XmlSerializer xs = new XmlSerializer(typeof(Int32));
            StreamWriter sw = new StreamWriter(XML_FILE_NAME);
            xs.Serialize(sw, TestValue);
            sw.Close();

        }



    }


}
