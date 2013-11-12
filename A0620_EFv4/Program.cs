using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0620_EFv4.Sample;



namespace A0620_EFv4
{

    class Program
    {
        static void Main(string[] args)
        {
            // 测试类.
            Test p = new Test();



            mr_demo_data data1 = new mr_demo_data() { city_id = 1, dept_id = 1, demo_info = "C1_D1" };
            mr_demo_data data2 = new mr_demo_data() { city_id = 1, dept_id = 2, demo_info = "C1_D2" };
            mr_demo_data data3 = new mr_demo_data() { city_id = 2, dept_id = 1, demo_info = "C2_D1" };
            mr_demo_data data4 = new mr_demo_data() { city_id = 2, dept_id = 2, demo_info = "C2_D2" };


            Console.WriteLine("测试插入数据!");

            p.SaveMrDemoData(data1);
            p.SaveMrDemoData(data2);
            p.SaveMrDemoData(data3);
            p.SaveMrDemoData(data4);


            Console.WriteLine("测试查询!");

            var query =
                from data in p.MrDemoDataSource
                where data.city_id == 1
                select data;


            foreach (mr_demo_data d in query)
            {
                Console.WriteLine(d.ToString());
            }

            data2.demo_info = "Update 22";
            data4.demo_info = "Update 44";


            Console.WriteLine("测试更新!");
            p.SaveMrDemoData(data2);
            p.SaveMrDemoData(data4);


            query =
                from data in p.MrDemoDataSource
                where
                    data.city_id == 1
                    || data.city_id == 2
                select data;

            foreach (mr_demo_data d in query)
            {
                Console.WriteLine(d.ToString());
            }



            Console.WriteLine("测试删除!");
            p.DeleteMrDemoData(data1);
            p.DeleteMrDemoData(data3);

            query =
                from data in p.MrDemoDataSource
                where
                    data.city_id == 1
                    || data.city_id == 2
                select data;

            foreach (mr_demo_data d in query)
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
