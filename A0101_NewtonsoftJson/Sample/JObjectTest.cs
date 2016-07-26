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
        }

    }
}
