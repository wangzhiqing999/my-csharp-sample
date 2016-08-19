using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ArxOne.MrAdvice.Advice;


namespace B1000_Fody_MrAdvice
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("测试使用 MrAdvice.Fody 来实现 AOP 的处理.");


            TestClass t = new TestClass();


            t.MyProudMethod();


            Console.ReadKey();
        }

    }



    public class TestClass
    {

        [MyProudAdvice]
        public void MyProudMethod()
        {
            Console.WriteLine("业务逻辑处理！");
        }
    }




    public class MyProudAdvice : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            // do things you want here
            Console.WriteLine("##### AOP:   业务逻辑处理之前，所做的处理！");


            context.Proceed(); // this calls the original method


            // do other things here
            Console.WriteLine("##### AOP:   业务逻辑处理之后，所做的处理！");
        }
    }


}
