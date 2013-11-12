using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0076_AOPDynamicObject.Sample;



namespace A0076_AOPDynamicObject
{

    class Program
    {

        static void Main(string[] args)
        {

            #region 首先以正常方式调用.



            Console.WriteLine("普通方式调用！！！");


            ObjectClass test1 = new ObjectClass();

            test1.Test1();
            test1.Test2("Real Obj!");
            test1.Test3(100);

            int paramY = 0;
            int paramZ = 0;

            test1.TestX();

            test1.TestY(ref paramY);
            test1.TestZ(out paramZ);

            Console.WriteLine("Y={0}, Z={1}", paramY, paramZ);


            #endregion




            
            
            
            #region 然后以 动态代理方式调用.

            
            Console.WriteLine();

            Console.WriteLine("动态代理方式调用！！！");


            dynamic test2 = new DynamicProxy(new ObjectClass());

            test2.Test1();
            test2.Test2("Real Obj!");
            test2.Test3(100);


            try
            {
                test2.TestX();
            }
            catch (Exception)
            {
                Console.WriteLine("动态处理  可变参数的处理发生错误!");
            }


            paramY = 0;
            paramZ = 0;


            test2.TestY(ref paramY);

            test2.TestZ(out paramZ);

            Console.WriteLine("动态处理的 ref, out参数存在一定问题  Y={0}, Z={1}", paramY, paramZ);


            #endregion




            Console.ReadLine();


        }


    }


}
