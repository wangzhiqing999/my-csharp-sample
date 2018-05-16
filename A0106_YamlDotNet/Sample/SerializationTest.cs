using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using YamlDotNet.Serialization;

using A0106_YamlDotNet.Model;


namespace A0106_YamlDotNet.Sample
{
    class SerializationTest
    {

        /// <summary>
        /// 测试.
        /// </summary>
        public static void DoTest()
        {

            Console.WriteLine("========== YamlDotNet.Serialization / Deserializer Test ==========");

            DataObject testData = DataObject.GetDefaultTestData();

            Console.WriteLine("原始数据：");
            Console.WriteLine(testData.ToString());


            string yamlString;

            using(MemoryStream stream = new MemoryStream(20480)) 
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    Serializer serializer = new Serializer();                    
                    serializer.Serialize(sw, testData);                    
                }
                yamlString = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine("对象 Serialization 为 Yaml 字符串：\n{0}", yamlString);
            }


            Deserializer deserializer = new Deserializer();
            DataObject testData2 = deserializer.Deserialize<DataObject>(yamlString);
            Console.WriteLine("字符串 Deserialize 为 对象：\n{0}", testData2);
            
        }


    }
}
