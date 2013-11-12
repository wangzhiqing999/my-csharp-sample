using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0016_IMPLICIT_EXPLICIT.Sample;


namespace A0016_IMPLICIT_EXPLICIT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("首先尝试 MyList<int>  向  int[]  与  List<int> 进行转换.");

            // 测试对象.
            MyList<int> mylist1 = new MyList<int>();
            mylist1.Add(1);
            mylist1.Add(3);
            mylist1.Add(5);

            // 尝试 显式转换.
            int[] array1 = (int[])mylist1;

            // 尝试 隐式转换.
            List<int> list1 = mylist1;

            // 尝试比较.
            Console.WriteLine("mylist1 == array1 ? " + (mylist1 == array1));
            Console.WriteLine("mylist1 == list1 ? " + (mylist1 == list1));



            Console.WriteLine("然后尝试  int[]  与  List<int> 向 MyList<int> 进行转换.");
            int[] array2 = { 2, 4, 6 };
            // 尝试 显式转换.
            MyList<int> mylist2 = (MyList<int>)array2;
            // 尝试比较.
            Console.WriteLine("mylist2 == array2 ? " + (mylist2 == array2));


            List<int> list3 = new List<int>() {3,6,9};
            // 尝试 隐式转换.
            MyList<int> mylist3 = list3;
            Console.WriteLine("mylist3 == list3 ? " + (mylist3 == list3));

            Console.ReadLine();
        }
    }
}
