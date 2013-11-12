using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0202_DefaultAdapter.Target;
using P0202_DefaultAdapter.Adapter;


namespace P0202_DefaultAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("普通的人来面试...");
            TestNormal();

            Console.WriteLine();
            Console.WriteLine("内部邀请的人来面试...");
            TestInvite();

            Console.WriteLine();
            Console.WriteLine("老板的兄弟来面试...");
            TestBossBother();


            Console.ReadLine();
        }



        private static void TestNormal()
        {
            ITarget t = new Normal();

            t.Test1();
            t.Test2();
            t.Test3();
            t.Test4();
            t.Test5();
        }



        private static void TestInvite()
        {
            ITarget t = new Invite();

            t.Test1();
            t.Test2();
            t.Test3();
            t.Test4();
            t.Test5();
        }


        private static void TestBossBother()
        {
            ITarget t = new BossBother();

            t.Test1();
            t.Test2();
            t.Test3();
            t.Test4();
            t.Test5();
        }

    }
}
