using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0306_ChainOfResponsibility.Model;
using P0306_ChainOfResponsibility.Handler;
using P0306_ChainOfResponsibility.ConcreteHandler;


namespace P0306_ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();

            Console.WriteLine("----------责任链中增加一级-----------------");

            Test2();


            Console.ReadLine();
        }



        /// <summary>
        /// 测试初始情况.
        /// </summary>
        private static void Test1()
        {
            Approver wjzhang, gyang, jguo, meeting;
            wjzhang = new Director("张无忌");
            gyang = new VicePresident("杨过");
            jguo = new President("郭靖");
            meeting = new Congress("董事会");

            //创建职责链
            wjzhang.Successor = gyang;
            gyang.Successor = jguo;
            jguo.Successor = meeting;


            //创建采购单
            PurchaseRequest pr1 = new PurchaseRequest(45000, 10001, "购买倚天剑");
            wjzhang.processRequest(pr1);

            PurchaseRequest pr2 = new PurchaseRequest(60000, 10002, "购买《葵花宝典》");
            wjzhang.processRequest(pr2);

            PurchaseRequest pr3 = new PurchaseRequest(160000, 10003, "购买《金刚经》");
            wjzhang.processRequest(pr3);

            PurchaseRequest pr4 = new PurchaseRequest(800000, 10004, "购买桃花岛");
            wjzhang.processRequest(pr4);
        }



        /// <summary>
        /// 测试 追加的情况.
        /// </summary>
        private static void Test2()
        {
            Approver wjzhang, gyang, jguo, meeting;
            wjzhang = new Director("张无忌");
            gyang = new VicePresident("杨过");
            jguo = new President("郭靖");
            meeting = new Congress("董事会");


            Approver rhuang;
            rhuang = new Manager("黄蓉");


            //创建职责链
            // 将“黄蓉”作为“张无忌”的下家
            wjzhang.Successor = rhuang;
            // 将“杨过”作为“黄蓉”的下家
            rhuang.Successor = gyang;  

            gyang.Successor = jguo;
            jguo.Successor = meeting;


            //创建采购单
            PurchaseRequest pr1 = new PurchaseRequest(45000, 10001, "购买倚天剑");
            wjzhang.processRequest(pr1);

            PurchaseRequest pr2 = new PurchaseRequest(60000, 10002, "购买《葵花宝典》");
            wjzhang.processRequest(pr2);

            PurchaseRequest pr3 = new PurchaseRequest(160000, 10003, "购买《金刚经》");
            wjzhang.processRequest(pr3);

            PurchaseRequest pr4 = new PurchaseRequest(800000, 10004, "购买桃花岛");
            wjzhang.processRequest(pr4);
        }

    }
}
