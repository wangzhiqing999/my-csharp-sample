using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0621_EF_CodeFirst.Sample;


namespace A0621_EF_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            // 测试类.
            Test p = new Test();

            MrDemoData data1 = new MrDemoData() { CityID = 1, DeptID = 1, DemoInfo = "C1_D1" };
            MrDemoData data2 = new MrDemoData() { CityID = 1, DeptID = 2, DemoInfo = "C1_D2" };
            MrDemoData data3 = new MrDemoData() { CityID = 2, DeptID = 1, DemoInfo = "C2_D1" };
            MrDemoData data4 = new MrDemoData() { CityID = 2, DeptID = 2, DemoInfo = "C2_D2" };


            Console.WriteLine("测试插入数据!");

            p.SaveMrDemoData(data1);
            p.SaveMrDemoData(data2);
            p.SaveMrDemoData(data3);
            p.SaveMrDemoData(data4);


            Console.WriteLine("测试查询!");

            var query =
                from data in p.MrDemoDataSource
                where data.CityID == 1
                select data;


            foreach (MrDemoData d in query)
            {
                Console.WriteLine(d.ToString());
            }

            data2.DemoInfo = "Update 22";
            data4.DemoInfo = "Update 44";

            Console.WriteLine("测试更新!");
            p.SaveMrDemoData(data2);
            p.SaveMrDemoData(data4);





            query =
                from data in p.MrDemoDataSource
                where
                    data.CityID == 1
                    || data.CityID == 2
                select data;

            foreach (MrDemoData d in query)
            {
                Console.WriteLine(d.ToString());
            }



            Console.WriteLine("测试删除!");
            p.DeleteMrDemoData(data1);
            p.DeleteMrDemoData(data3);

            query =
                from data in p.MrDemoDataSource
                where
                    data.CityID == 1
                    || data.CityID == 2
                select data;

            foreach (MrDemoData d in query)
            {
                Console.WriteLine(d.ToString());
            }



            p.DeleteMrDemoData(data2);
            p.DeleteMrDemoData(data4);

            Console.WriteLine("Finish!");

            Console.ReadLine();

        }
    }
}
