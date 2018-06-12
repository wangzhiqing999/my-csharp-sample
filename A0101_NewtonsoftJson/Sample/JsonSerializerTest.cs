using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using A0101_NewtonsoftJson.Model;



namespace A0101_NewtonsoftJson.Sample
{
    class JsonSerializerTest
    {

        public static void DoTest()
        {

            Console.WriteLine("========== JsonSerializerTest ==========");

            DataObject testData = DataObject.GetDefaultTestData();

            Console.WriteLine("原始数据：");
            Console.WriteLine(testData.ToString());


            JsonSerializer serializer = new JsonSerializer();

            // 设置 时间类型的处理机制.
            serializer.Converters.Add(new JavaScriptDateTimeConverter());

            // 设置属性为 null 时， 忽略.
            serializer.NullValueHandling = NullValueHandling.Ignore;


            MemoryStream stream = new MemoryStream(20480);

            using (StreamWriter sw = new StreamWriter(stream))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, testData);

            }


            string jsonString = Encoding.UTF8.GetString(stream.ToArray());

            Console.WriteLine("对象转换为 Json 字符串：\n{0}", jsonString);




            

        }







        public static void DoTestWithSerialization()
        {
            Console.WriteLine("----- JsonSerializerTest.DoTestWithSerialization -----");

            JsonSerializer serializer = new JsonSerializer();

            Test1 t1 = new Test1()
            {
                A = 1,
                B = 2,
                C = 3
            };

            Test2 t2 = new Test2()
            {
                A = 2,
                B = 4,
                C = 6
            };

            Test3 t3 = new Test3()
            {
                A = 3,
                B = 6,
                C = 9
            };


            MemoryStream stream1 = new MemoryStream(20480);
            MemoryStream stream2 = new MemoryStream(20480);
            MemoryStream stream3 = new MemoryStream(20480);

            using (StreamWriter sw = new StreamWriter(stream1))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, t1);
                }
            }
            using (StreamWriter sw = new StreamWriter(stream2))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, t2);
                }
            }
            using (StreamWriter sw = new StreamWriter(stream3))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, t3);
                }
            }


            string jsonString1 = Encoding.UTF8.GetString(stream1.ToArray());
            Console.WriteLine("Test1 对象转换为 Json 字符串：\n{0}", jsonString1);

            string jsonString2 = Encoding.UTF8.GetString(stream2.ToArray());
            Console.WriteLine("Test2 对象转换为 Json 字符串：\n{0}", jsonString2);

            string jsonString3 = Encoding.UTF8.GetString(stream3.ToArray());
            Console.WriteLine("Test3 对象转换为 Json 字符串：\n{0}", jsonString3);
        }


    }
}
