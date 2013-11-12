using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace A0511_LINQ_XML_Query.Sample
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
  <苹果>
    <产地>中国</产地>
    <颜色>黄</颜色>
    <味道>甜</味道>
    <品质>优良</品质>
  </苹果>
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
  <苹果>
    <产地>美国</产地>
    <颜色>黄</颜色>
    <味道>甜</味道>
    <品质>优良</品质>
  </苹果>
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
  <苹果>
    <产地>日本</产地>
    <颜色>黄</颜色>
    <味道>甜</味道>
    <品质>优良</品质>
  </苹果>
  <桔子>
    <产地>日本</产地>
    <颜色>青</颜色>
    <味道>甜</味道>
    <品质>一般</品质>
  </桔子>
</水果>";



        /// <summary>
        /// 简单查询.
        /// </summary>
        public void Test1()
        {
            // 加载 XML.
            XElement contacts = XElement.Parse(xmlString);

            //foreach (XElement oneElement in contacts.Elements())
            //{
            //    // Console.WriteLine(oneElement.Elements("产地"));
            //    foreach (XElement subElement in oneElement.Elements("产地"))
            //    {
            //        Console.WriteLine(subElement.Value);
            //    }
            //}


            Console.WriteLine("从 XElement 查询出，产地为 日本 的 桔子 数据");
            // LINQ XML 说明： 
            //    这里的 from el in contacts.Elements("桔子") 表明，每一个检索单元，是在 contacts.Elements("桔子") 下面的， 也就是 一个桔子 一个单元.
            //    where (el.Elements("产地").Count() == 1) && (el.Elements("产地").First().Value == "日本")
            //      这个 el.Elements("产地").Count() == 1 表明  “桔子”下面的节点中， 有且只有一个 “产地” 的节点。
            //           el.Elements("产地").First().Value == "日本"  表示 第一个 “产地” 的节点的 数据 = 日本
            //    select e1  表明，最后的结果的 XML 格式， 是 e1 的格式， 也就是前面的 from el 的格式， 即 “桔子”
            XElement xmlTree2 = new XElement("日本桔子",
                from el in contacts.Elements("桔子")
                where (el.Elements("产地").Count() == 1) && (el.Elements("产地").First().Value == "日本")
                select el
            );
            Console.WriteLine(xmlTree2);



            
            Console.WriteLine("从 XElement 查询出，产地为 美国  颜色为红 的 数据");
            // LINQ SQL 说明：
            //     这里与上面 主要 的不同之处在于 select el.Elements()
            //     也就是说， 最后结果的 XML 格式， 是 el.Elements() 的格式， 也就是 “桔子” 下面的 一系列数据，但不包含 “桔子”
            XElement xmlTree3 = new XElement("美国红桔子",
                            from el in contacts.Elements("桔子")
                            where (el.Elements("产地").Count() == 1) && (el.Elements("产地").First().Value == "美国") &&
                                  (el.Elements("颜色").Count() == 1) && (el.Elements("颜色").First().Value == "红")
                            select el.Elements()
                        );
            Console.WriteLine(xmlTree3);


        }




    }

}
