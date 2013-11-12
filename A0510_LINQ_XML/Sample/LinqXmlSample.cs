using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace A0510_LINQ_XML.Sample
{
    class LinqXmlSample
    {

        private const String xmlString = @"<水果>
  <桔子>
    <产地>中国</产地>
    <颜色>红</颜色>
    <味道>甜</味道>
    <品质>一般</品质>
  </桔子>
  <桔子>
    <产地>中国</产地>
    <颜色>黄</颜色>
    <味道>甜</味道>
    <品质>优良</品质>
  </桔子>
  <桔子>
    <产地>中国</产地>
    <颜色>青</颜色>
    <味道>甜</味道>
    <品质>一般</品质>
  </桔子>
  <桔子>
    <产地>美国</产地>
    <颜色>红</颜色>
    <味道>甜</味道>
    <品质>一般</品质>
  </桔子>
  <桔子>
    <产地>美国</产地>
    <颜色>黄</颜色>
    <味道>甜</味道>
    <品质>优良</品质>
  </桔子>
  <桔子>
    <产地>美国</产地>
    <颜色>青</颜色>
    <味道>甜</味道>
    <品质>一般</品质>
  </桔子>
  <桔子>
    <产地>日本</产地>
    <颜色>红</颜色>
    <味道>甜</味道>
    <品质>一般</品质>
  </桔子>
  <桔子>
    <产地>日本</产地>
    <颜色>黄</颜色>
    <味道>甜</味道>
    <品质>优良</品质>
  </桔子>
  <桔子>
    <产地>日本</产地>
    <颜色>青</颜色>
    <味道>甜</味道>
    <品质>一般</品质>
  </桔子>
</水果>";





        /// <summary>
        /// 测试简单从 String 中 分析 XML.
        /// </summary>
        public void TestParse()
        {
            Console.WriteLine("测试简单从 String 中 分析 XML.");
            XElement contacts = XElement.Parse(xmlString);
            Console.WriteLine(contacts);
        }


        /// <summary>
        /// 测试简单从 文件中分析 XML
        /// </summary>
        public void TestParse2()
        {
            Console.WriteLine("测试简单从 文件 中 分析 XML.");
            XElement orangeFile = XElement.Load(@"xmlSample.xml");
            Console.WriteLine(orangeFile);
        }


        /// <summary>
        /// 测试简单从 XmlReader 中分析 XML
        /// </summary>
        public void TestParse3()
        {
            Console.WriteLine("测试简单从 XmlReader  中 分析 XML.");
            XmlReader r = XmlReader.Create("xmlSample.xml");
            while (r.NodeType != XmlNodeType.Element)
                r.Read();
            XElement e = XElement.Load(r);
            Console.WriteLine(e);

        }


    }
}
