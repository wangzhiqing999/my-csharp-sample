using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0305_Iterator.Sample;


namespace P0305_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection myC = new MyCollection();

            foreach (int val in myC)
            {
                Console.WriteLine(val);
            }
            
            Console.ReadLine();
        }
    }
}
