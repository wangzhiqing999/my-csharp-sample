using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using A0101_NewtonsoftJson.Model;



namespace A0101_NewtonsoftJson.Sample
{
    class JObjectTest
    {


        public static void DoTest()
        {

            Console.WriteLine("========== JObjectTest ==========");



            DataObject testData = DataObject.GetDefaultTestData();
            string jsonString = JsonConvert.SerializeObject(testData);


            JObject o = JObject.Parse(jsonString);


            Console.WriteLine("JObject.Parse 源：\n{0}", jsonString);
            Console.WriteLine("JObject.Parse 结果：");

            Console.WriteLine("UserName = {0}", o["UserName"]);
            Console.WriteLine("FirendList = {0}", o["FirendList"]);
            Console.WriteLine("UserType = {0}", o["UserType"]);
            Console.WriteLine("TestDateTime = {0}", o["TestDateTime"]);
            Console.WriteLine("TestNullValue = {0}", o["TestNullValue"]);

            Console.WriteLine();



            string jsonString2 = @"{
    ""PUXT"": {
        ""REQ_HEADER"": {
            ""CLT_VERSION"": ""1.0.0"",
            ""CLT_TIMESTAMP"": ""10000000"",
            ""CLT_SEQ"": 1
        },
        ""REQ_BODY"": {
            ""CUSTOMERNO"": """",
            ""PHONE"": """",
            ""SMSTYPE"": ""00""
        }
    }
}";

            JObject o2 = JObject.Parse(jsonString2);


            Console.WriteLine("Source Json String : \n{0}", jsonString2);

            Console.WriteLine("PUXT = {0}", o2["PUXT"]);

            Console.WriteLine("PUXT.REQ_HEADER = {0}", o2["PUXT"]["REQ_HEADER"]);

            Console.WriteLine("PUXT.REQ_HEADER.CLT_VERSION = {0}", o2["PUXT"]["REQ_HEADER"]["CLT_VERSION"]);

            Console.WriteLine();




            string jsonString3 = @"{	
	""result"":{
		""hasNext"":true,
		""resultList"":[
			{""id"":78,""name"":""黄浦区""},
			{""id"":2813,""name"":""徐汇区""},
			{""id"":2815,""name"":""长宁区""},
			{""id"":2817,""name"":""静安区""},
			{""id"":2820,""name"":""闸北区""},
			{""id"":2822,""name"":""虹口区""},
			{""id"":2823,""name"":""杨浦区""},
			{""id"":2824,""name"":""宝山区""},
			{""id"":2825,""name"":""闵行区""},
			{""id"":2826,""name"":""嘉定区""},
			{""id"":2830,""name"":""浦东新区""},
			{""id"":2833,""name"":""青浦区""},
			{""id"":2834,""name"":""松江区""},
			{""id"":2835,""name"":""金山区""},
			{""id"":2837,""name"":""奉贤区""},
			{""id"":2841,""name"":"" 普陀区""},
			{""id"":2919,""name"":""崇明区""}
		]
	}
}";
            JObject o3 = JObject.Parse(jsonString3);

            Console.WriteLine("Source Json String : \n{0}", jsonString3);


            var query =
                from data in o3["result"]["resultList"]
                select data;

            foreach(var item in query)
            {
                Console.WriteLine("id = {0}, name = {1}", item["id"], item["name"]);
            }

            Console.WriteLine();

        }

    }
}
