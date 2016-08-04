using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using C0010_SecretKeyEncryption.Sample;


namespace C0010_SecretKeyEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            // 高级加密标准 (AES) 对称算法
            new AesExample().DoTest();

            // RC2 算法
            new RC2CryptoServiceProviderExample().DoTest();

            // 数据加密标准 (DES) 算法
            new DESCryptoServiceProviderExample().DoTest();

            // Rijndael 算法的托管版本
            new RijndaelManagedExample().DoTest();

            //  TripleDES 算法的加密服务提供程序 (CSP) 版本
            new TripleDESCryptoServiceProviderExample().DoTest();

            Console.ReadLine();
        }
    }
}
