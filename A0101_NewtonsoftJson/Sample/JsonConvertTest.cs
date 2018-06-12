using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


using A0101_NewtonsoftJson.Model;



namespace A0101_NewtonsoftJson.Sample
{

    class JsonConvertTest
    {

        public static void DoTest()
        {

            Console.WriteLine("========== JsonConvertTest ==========");


            DataObject testData = DataObject.GetDefaultTestData();

            Console.WriteLine("原始数据：");
            Console.WriteLine(testData.ToString());



            string jsonString = JsonConvert.SerializeObject(testData);
            Console.WriteLine("对象转换为 Json 字符串：\n{0}", jsonString);

            DataObject testData2 = JsonConvert.DeserializeObject<DataObject>(jsonString);
            Console.WriteLine("Json 字符串 转换为 对象：\n{0}", testData2);



            Console.WriteLine("------ 定义额外的设置 ------");

            JsonSerializerSettings setting = new JsonSerializerSettings();
            
            // 使得序列化使用驼峰式大小写风格序列化属性
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // 将枚举类型在序列化时序列化字符串
            setting.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            // 将日期类型，生成为  JavaScript 的日期.
            setting.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());


            jsonString = JsonConvert.SerializeObject(testData, setting);
            Console.WriteLine("对象转换为 Json 字符串：\n{0}", jsonString);

            testData2 = JsonConvert.DeserializeObject<DataObject>(jsonString, setting);
            Console.WriteLine("Json 字符串 转换为 对象：\n{0}", testData2);

        }



        public static void DoTestWithSerialization()
        {
            Console.WriteLine("----- JsonConvertTest.DoTestWithSerialization -----");

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


            string jsonString1 = JsonConvert.SerializeObject(t1);
            Console.WriteLine("Test1 对象转换为 Json 字符串：\n{0}", jsonString1);

            string jsonString2 = JsonConvert.SerializeObject(t2);
            Console.WriteLine("Test2 对象转换为 Json 字符串：\n{0}", jsonString2);

            string jsonString3 = JsonConvert.SerializeObject(t3);
            Console.WriteLine("Test3 对象转换为 Json 字符串：\n{0}", jsonString3);
        }



    }

}
