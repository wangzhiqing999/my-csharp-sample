using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using C0020_PublicKeyEncryption.Sample;


namespace C0020_PublicKeyEncryption
{
    class Program
    {
        static void Main(string[] args)
        {

            // 使用  DSACryptoServiceProvider 类创建哈希值的数字签名，然后验证签名。
            DSACSPSample.DoTest();


            // 使用 RSACryptoServiceProvider 类将一个字符串加密为一个字节数组，然后将这些字节解密为字符串。
            RSACSPSample.DoTest();


            // 使用 RSACryptoServiceProvider 类将一个字符串加密为一个字节数组，然后将这些字节解密为字符串。
            RSACSPSampleByHand.DoTestByHand();



            RSACSPSampleByXml.DoTestByXml();


            Console.ReadLine();
        }
    }
}
