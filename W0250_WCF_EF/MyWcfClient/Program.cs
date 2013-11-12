using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (TestServiceReference.TestServiceClient service = new TestServiceReference.TestServiceClient())
            {
                Console.WriteLine("调用 service.GetData(100)， 返回：" + service.GetData(100));


                TestServiceReference.CompositeType ct = new TestServiceReference.CompositeType()
                {
                    StringValue = "Test",
                    BoolValue = true
                };


                Console.WriteLine("调用前 ct: BoolValue={0}; StringValue={1}", ct.BoolValue, ct.StringValue);

                Console.WriteLine("调用 service.GetDataUsingDataContract(ct)");

                ct = service.GetDataUsingDataContract(ct);

                Console.WriteLine("调用后 ct: BoolValue={0}; StringValue={1}", ct.BoolValue, ct.StringValue);




                Console.WriteLine("调用 service.GetTestMain()");

                TestServiceReference.test_main [] testMainArray = service.GetTestMain();

                // 遍历数据列表.
                foreach (TestServiceReference.test_main mainData in testMainArray)
                {
                    Console.WriteLine("MainID={0}; MainValue={1}",  mainData.id,    mainData.value);

                    Console.WriteLine("  调用 service.GetTestSub(mainData)");


                    TestServiceReference.test_sub [] testSubArray = service.GetTestSub(mainData);

                    // 遍历数据列表.
                    foreach (TestServiceReference.test_sub subData in testSubArray)
                    {
                        Console.WriteLine("  SubID={0}; SubValue={1}", subData.id, subData.value);
                    }
                    
                }


            }


            Console.WriteLine("按回车键结束！");
            Console.ReadLine();

        }
    }
}
