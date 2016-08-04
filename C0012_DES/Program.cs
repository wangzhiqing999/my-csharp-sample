using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using C0012_DES.Sample;


namespace C0012_DES
{
    class Program
    {
        static void Main(string[] args)
        {


            //string result = PasswordProcesser.PasswordEncode("230103198602230916", "123456");
            //Console.WriteLine("加密结果：{0}", result);

            //Console.WriteLine();

            //string result2 = PasswordProcesser.PasswordDecode("230103198602230916", result);
            //Console.WriteLine("解密结果：{0}", result2);




            string result = PasswordProcesser2.PasswordEncode("230103198602230916", "123456");
            Console.WriteLine("加密结果：{0}", result);

            Console.WriteLine();

            string result2 = PasswordProcesser2.PasswordDecode("230103198602230916", result);
            Console.WriteLine("解密结果：{0}", result2);




            Console.ReadLine();
        }
    }
}
