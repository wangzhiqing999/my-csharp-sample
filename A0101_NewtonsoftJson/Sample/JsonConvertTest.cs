using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Newtonsoft.Json;


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
        }


    }

}
