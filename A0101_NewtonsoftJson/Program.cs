using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0101_NewtonsoftJson.Sample;


namespace A0101_NewtonsoftJson
{
    class Program
    {
        static void Main(string[] args)
        {

            DataContractJsonSerializerTest.DoTestWithSerialization();


            JsonConvertTest.DoTestWithSerialization();
            JsonConvertTest.DoTest();


            JsonSerializerTest.DoTestWithSerialization();
            JsonSerializerTest.DoTest();
            


            JObjectTest.DoTest();



            JObjectTest.DoTest2();

            Console.ReadLine();
        }
    }
}
