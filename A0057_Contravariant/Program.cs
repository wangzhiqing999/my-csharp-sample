using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0056_Covariant.Sample;
using A0057_Contravariant.Sample;


namespace A0057_Contravariant
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("正常处理 : Action<父类> = Action<父类>");
            Action<object> actObject = PrintObject;
            actObject("Hello World!");


            Console.WriteLine("逆变处理 : Action<子类> = Action<父类>");
            Action<string> actString = PrintObject;
            actObject("Hello World!");



            TestParent p = new TestParent()
            {
                Name = "Parent",
            };

            TestSub s = new TestSub()
            {
                Name = "Sub",
            };




            Console.WriteLine("正常处理 : 自定义接口<父类> = 自定义接口<父类>");
            IContravariantAble<TestParent> cp = new ContravariantClass<TestParent>();
            cp.PrintData(p);
            cp.PrintData(s);


            Console.WriteLine("正常处理 : 自定义接口<子类> = 自定义接口<子类>");
            IContravariantAble<TestSub> cs = new ContravariantClass<TestSub>();
            cs.PrintData(s);


            Console.WriteLine("逆变处理 : 自定义接口<子类> = 自定义接口<父类>");
            cs = cp;
            cs.PrintData(s);


            Console.ReadLine();
        }



        static void PrintObject(object o) {
            Console.WriteLine("PrintObject : {0} !", o);
        } 

    }
}
