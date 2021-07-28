using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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









        /// <summary>
        /// 测试 遇到 对方的接口中， 存在的 数据类型是不确定的情况下，做哪些处理。
        /// </summary>
        public static void DoTestExt()
        {

            string jsonString = @"{
	""userid"":""zhangsan"",
	""name"":""张三"",
	""extattr"":{
		""attrs"":[
			{
				""name"":""工号"",
				""value"":""6666"",
				""type"":0,
				""text"":{""value"":""6666""}
			},
			{
                ""type"": 0,
                ""name"": ""文本名称"",
                ""text"": {
                    ""value"": ""文本""
                }
            },
            {
                ""type"": 1,
                ""name"": ""网页名称"",
                ""web"": {
                    ""url"": ""http://www.test.com"",
                    ""title"": ""标题""
                }
            }
		]
	}
}";

            TestExtDataObj data = JsonConvert.DeserializeObject<TestExtDataObj>(jsonString);


            Console.WriteLine(data.userid);
            Console.WriteLine(data.name);

            // Console.WriteLine(data.extattr);

            if(data.extattr != null)
            {
                JObject ext = data.extattr as JObject;
                foreach(var item in ext["attrs"])
                {
                    string name = item["name"].ToString();
                    if(name == "工号")
                    {
                        Console.WriteLine($"工号 = { item["value"] }");
                    }
                }
            }
            

        }



        /// <summary>
        /// 测试类.
        /// 接口文档中， 对于 userid、name 有明确的数据类型定义
        /// 但是对于 extattr， 则是没有明确的定义。
        /// </summary>
        public class TestExtDataObj
        {
            public string userid { set; get; }
            public string name { set; get; }


            /// <summary>
            /// 这个元素， 说明文档中，没有明确的定义。
            /// </summary>
            public JObject extattr { set; get; }
        }






    }

}
