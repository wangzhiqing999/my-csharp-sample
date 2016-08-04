using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using C0900_Keys.Sample;



namespace C0900_Keys
{
    class Program
    {
        static void Main(string[] args)
        {

            // 生成  对称密钥  的例子.
            SymmetricKeysTest.DoTest();


            // 生成  非对称密钥  的例子.
            AsymmetricKeysTest.DoTest();



            // 将非对称密钥存储在密钥容器中的例子.
            StoreKey.DoTest();



            Console.ReadLine();
        }
    }
}
