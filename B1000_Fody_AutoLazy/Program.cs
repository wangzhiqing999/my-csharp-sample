using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1000_Fody_AutoLazy
{
    class Program
    {
        static void Main(string[] args)
        {

            

            var first = MockStaticGuid.GetGuid();            
            var second = MockStaticGuid.GetGuid();

            Console.WriteLine("首次调用 GetGuid()， 结果： {0}", first);
            Console.WriteLine("二次调用 GetGuid()， 结果： {0}", second);

            Console.WriteLine("GetGuid 实际业务逻辑被执行的次数 ： {0}", MockStaticGuid.GetCount);



            first = MockStaticGuid.GuidProp;
            second = MockStaticGuid.GuidProp;

            Console.WriteLine("首次调用 GuidProp， 结果： {0}", first);
            Console.WriteLine("二次调用 GuidProp， 结果： {0}", second);

            Console.WriteLine("PropCount 实际业务逻辑被执行的次数 ： {0}", MockStaticGuid.PropCount);







            second = MockStaticGuid.GetGuid();


            var first2 = MockStaticGuid.GetGuidByKey(first);
            var second2 = MockStaticGuid.GetGuidByKey(second);

            var first3 = MockStaticGuid.GetGuidByKey(first);            
            var second3 = MockStaticGuid.GetGuidByKey(second);



            Console.WriteLine("首次调用 GetGuidByKey({0})， 结果： {1}", first, first2);
            Console.WriteLine("二次调用 GetGuidByKey({0})， 结果： {1}", first, first3);


            Console.WriteLine("首次调用 GetGuidByKey({0})， 结果： {1}", second, second2);
            Console.WriteLine("二次调用 GetGuidByKey({0})， 结果： {1}", second, second3);

            Console.WriteLine("GetGuidByKey 实际业务逻辑被执行的次数 ： {0}", MockStaticGuid.GetKeyedCount);


            Console.ReadKey();

        }



    }
}
