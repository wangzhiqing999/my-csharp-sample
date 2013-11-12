using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0631_EF_Inherit_TPT.Sample;


namespace A0631_EF_Inherit_TPT
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            Operator o1 = new Operator()
            {
                MemberName = "测试操作员1",
                City = "北京"
            };

            Operator o2 = new Operator()
            {
                MemberName = "测试操作员2",
                City = "上海"
            };

            Manager m1 = new Manager()
            {
                MemberName = "测试管理员1",
                SecurityLevel = 1
            };

            Manager m2 = new Manager()
            {
                MemberName = "测试管理员2",
                SecurityLevel = 2
            };


            t.SaveWorkMember(o1);
            t.SaveWorkMember(o2);
            t.SaveWorkMember(m1);
            t.SaveWorkMember(m2);


            Console.WriteLine("查询所有成员.");
            foreach (WorkMember m in t.WorkMembers)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("查询所有操作员.");
            foreach (WorkMember m in t.Operators)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("查询所有管理员.");
            foreach (WorkMember m in t.Managers)
            {
                Console.WriteLine(m);
            }

            Console.ReadLine();
        }
    }
}
