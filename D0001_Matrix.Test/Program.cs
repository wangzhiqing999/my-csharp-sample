using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using D0001_Matrix.Model;



namespace D0001_Matrix.Test
{
    class Program
    {

        static void Main(string[] args)
        {

            Matrix<Int32> val1 = new SparseMatrix<int>(3, 4);
            val1[0, 0] = 3;
            val1[0, 3] = 7;
            val1[1, 3] = -1;
            val1[2, 1] = 2;


            Matrix<Int32> val2 = new SparseMatrix<int>(4, 2);
            val2[0, 0] = 4;
            val2[0, 1] = 1;
            val2[2, 0] = 1;
            val2[2, 1] = -1;
            val2[3, 1] = 2;


            Matrix<Int32> val3 = val1 * val2;


            Console.WriteLine(val1);
            Console.WriteLine("*");
            Console.WriteLine(val2);
            Console.WriteLine("=");
            Console.WriteLine(val3);




            Console.WriteLine("本项目是一个 Nunit 的单元测试，请通过 Nunit 来运行本程序！");
            Console.ReadLine();

        }
    }
}
