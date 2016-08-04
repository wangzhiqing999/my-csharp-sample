using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;



namespace C0900_Keys.Sample
{
    class SymmetricKeysTest
    {

        /// <summary>
        /// 测试 生成对称密钥.
        /// </summary>
        public static void DoTest()
        {
            Console.WriteLine("##### 生成对称密钥的例子 !");


            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            Console.WriteLine("对称算法的密钥:");
            ByteArrayOutput.Print(TDES.Key);

            Console.WriteLine("对称算法的对称算法的初始化向量 (IV):");
            ByteArrayOutput.Print(TDES.IV);



            Console.WriteLine("再多生成一组密钥 !");

            TDES.GenerateIV();
            TDES.GenerateKey();


            Console.WriteLine("对称算法的密钥:");
            ByteArrayOutput.Print(TDES.Key);

            Console.WriteLine("对称算法的对称算法的初始化向量 (IV):");
            ByteArrayOutput.Print(TDES.IV);



            Console.WriteLine("再多生成一组密钥 !");

            TDES.GenerateIV();
            TDES.GenerateKey();


            Console.WriteLine("对称算法的密钥:");
            ByteArrayOutput.Print(TDES.Key);

            Console.WriteLine("对称算法的对称算法的初始化向量 (IV):");
            ByteArrayOutput.Print(TDES.IV);

        }


    }
}
