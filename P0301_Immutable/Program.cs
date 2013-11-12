using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0301_Immutable.Sample;


namespace P0301_Immutable
{
    class Program
    {
        static void Main(string[] args)
        {

            MySequence mySeq = new MySequence();
            Console.WriteLine(mySeq.ToString());

            Console.WriteLine("不变模式暂无太多例子可供演示......");

            Console.ReadLine();
        }
    }
}
