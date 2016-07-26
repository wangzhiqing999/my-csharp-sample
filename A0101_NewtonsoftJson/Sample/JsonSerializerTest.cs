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
    }
}
