using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0640_EF_Enum.Sample;

namespace A0640_EF_Enum
{
    public class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            TestData td1 = new TestData()
            {
                TestName = "已提交数据",
                StockPoolStatus = new StatusWrapper()
                { 
                    EnumValue =  StatusEnum.AskFinish
                }
            };

            TestData td2 = new TestData()
            {
                TestName = "已关闭数据",
                StockPoolStatus = new StatusWrapper()
                {
                    EnumValue = StatusEnum.CloseFinish
                }
            };

            t.SaveTestData(td1);
            t.SaveTestData(td2);

            // 查询已关闭数据.
            var query =
                from data in t.TestDatas
                where data.StockPoolStatus.Value == (int)StatusEnum.CloseFinish
                select data;

            foreach (TestData td in query)
            {
                Console.WriteLine(td);
            }
            Console.ReadLine();
        }
    }
}
