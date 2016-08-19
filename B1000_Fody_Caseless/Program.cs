using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1000_Fody_Caseless
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("测试 Caseless.Fody。   项目中 忽略大小写.");


            string x = "ABC";
            string y = "abc";
            string z = "AbC";


            Console.WriteLine("{0} == {1}  结果  {2}", x, y, x == y);
            Console.WriteLine("{0} == {1}  结果  {2}", x, z, x == z);
            Console.WriteLine();


            string start = "a";
            Console.WriteLine("{0} StartsWith {1}  结果 {2} ", x, start, x.StartsWith(start));
            Console.WriteLine("{0} StartsWith {1}  结果 {2} ", y, start, y.StartsWith(start));
            Console.WriteLine();


            string end = "C";
            Console.WriteLine("{0} EndsWith {1}  结果 {2} ", x, end, x.EndsWith(end));
            Console.WriteLine("{0} EndsWith {1}  结果 {2} ", y, end, y.EndsWith(end));
            Console.WriteLine();


            string mid = "b";
            Console.WriteLine("{0} Contains {1}  结果 {2} ", x, mid, x.Contains(mid));
            Console.WriteLine("{0} Contains {1}  结果 {2} ", y, mid, y.Contains(mid));
            Console.WriteLine();



            Console.WriteLine("{0} IndexOf {1}  结果 {2} ", x, mid, x.IndexOf(mid));
            Console.WriteLine("{0} IndexOf {1}  结果 {2} ", y, mid, y.IndexOf(mid));
            Console.WriteLine();



            Console.WriteLine("{0} LastIndexOf {1}  结果 {2} ", x, mid, x.LastIndexOf(mid));
            Console.WriteLine("{0} LastIndexOf {1}  结果 {2} ", y, mid, y.LastIndexOf(mid));
            Console.WriteLine();




            Console.WriteLine("注意：Replace 暂不支持！");
            Console.WriteLine("{0} Replace({1},{2})  结果 {3} ", x, mid, start, x.Replace(mid, start));
            Console.WriteLine("{0} Replace({1},{2})  结果 {3} ", y, mid, start, y.Replace(mid, start));
            Console.WriteLine();



            Console.ReadKey();
        }
    }
}
