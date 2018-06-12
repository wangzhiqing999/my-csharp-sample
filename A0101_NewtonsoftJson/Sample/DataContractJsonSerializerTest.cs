using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using A0101_NewtonsoftJson.Model;


namespace A0101_NewtonsoftJson.Sample
{
    class DataContractJsonSerializerTest
    {

        /// <summary>
        /// 对象转换成json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject">需要格式化的对象</param>
        /// <returns>Json字符串</returns>
        public static string DataContractJsonSerialize<T>(T jsonObject)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            string json = null;
            using (var ms = new MemoryStream()) //定义一个stream用来存发序列化之后的内容
            {
                serializer.WriteObject(ms, jsonObject);
                var dataBytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(dataBytes, 0, (int)ms.Length);
                json = Encoding.UTF8.GetString(dataBytes);
                ms.Close();
            }
            return json;
        }





        public static void DoTestWithSerialization()
        {
            Console.WriteLine("----- DataContractJsonSerializerTest.DoTestWithSerialization -----");

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


            string jsonString1 = DataContractJsonSerialize<Test1>(t1);
            Console.WriteLine("Test1 对象转换为 Json 字符串：\n{0}", jsonString1);



            // 注意：这里使用微软的 DataContractJsonSerializer 来生成 Json 字符串 .
            // 可以观察到，结果的 Json 字符串中，出现 _BackingField 之类的字符串信息.
            // 解决办法是，使用 Test3 类的机制来进行处理.
            string jsonString2 = DataContractJsonSerialize<Test2>(t2);
            Console.WriteLine("Test2 对象转换为 Json 字符串：\n{0}", jsonString2);



            string jsonString3 = DataContractJsonSerialize<Test3>(t3);
            Console.WriteLine("Test3 对象转换为 Json 字符串：\n{0}", jsonString3);
        }

    }
}
