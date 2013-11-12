using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace A0211_DataTableCompute
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            Console.WriteLine(dt.Compute("125+568-567*95/81-6/958", ""));
            Console.ReadLine();
        }
    }
}
