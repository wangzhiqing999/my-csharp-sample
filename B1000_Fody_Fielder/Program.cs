using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace B1000_Fody_Fielder
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("测试使用 Fielder.Fody 来 根据 变量， 生成 set / get 属性.");



            DemoClass test = new DemoClass()
            {
                A = 100,
                B = 200,
                C = "Test",

                x = 1,
                y = 2,
                z = "Test"
            };


            // 对象类型.
            Type fromType = test.GetType();
            // 源对象的所有属性.
            PropertyInfo[] fromPropArray = fromType.GetProperties();


            // 遍历对象所有的属性.
            foreach (PropertyInfo fromProp in fromPropArray)
            {
                Console.WriteLine("属性 ： {0} = {1} ", fromProp.Name, fromProp.GetValue(test, null));
            }


            Console.ReadKey();
        }
    }




}
