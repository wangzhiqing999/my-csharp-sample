using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Security.Cryptography;


using C0010_SecretKeyEncryption.Util;


namespace C0020_PublicKeyEncryption.Sample
{

    /// <summary>
    /// 本例子使用  DSACryptoServiceProvider 类创建哈希值的数字签名，然后验证签名。
    /// 
    /// 
    /// RSA 允许同时进行加密和签名，但 DSA 只能用于签名，Diffie-Hellman 只能用于生成密钥。通常情况下，公钥算法比私钥算法具有更多的使用限制。
    /// </summary>
    class DSACSPSample
    {



        public static void DoTest()
        {

            Console.WriteLine("使用  DSACryptoServiceProvider 类创建哈希值的数字签名，然后验证签名的例子！");


            // 创建一个   DSA 算法的加密服务提供程序 (CSP) 实现的包装对象.
            DSACryptoServiceProvider DSA = new DSACryptoServiceProvider();

            // 需要被签名的数据.
            byte[] HashValue = { 59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135 };

            
            Console.WriteLine("初始 Hash 数据.");
            ByteArrayOutput.Print(HashValue);

            // 签名处理.
            byte[] SignedHashValue = DSASignHash(HashValue, DSA.ExportParameters(true), "SHA1");


            Console.WriteLine("使用私钥签名的数据.");
            ByteArrayOutput.Print(SignedHashValue);


            // 验证签名.
            if (DSAVerifyHash(HashValue, SignedHashValue, DSA.ExportParameters(false), "SHA1"))
            {
                Console.WriteLine("使用公钥验证 签名是有效的！");
            }
            else
            {
                Console.WriteLine("使用公钥验证 签名无效.");
            }
        }





        /// <summary>
        /// 数字签名处理.
        /// </summary>
        /// <param name="HashToSign"></param>
        /// <param name="DSAKeyInfo"></param>
        /// <param name="HashAlg"></param>
        /// <returns></returns>
        public static byte[] DSASignHash(byte[] HashToSign, DSAParameters DSAKeyInfo, string HashAlg)
        {
            try
            {
                //Create a new instance of DSACryptoServiceProvider.
                DSACryptoServiceProvider DSA = new DSACryptoServiceProvider();

                //Import the key information.   
                DSA.ImportParameters(DSAKeyInfo);

                //Create an DSASignatureFormatter object and pass it the 
                //DSACryptoServiceProvider to transfer the private key.
                DSASignatureFormatter DSAFormatter = new DSASignatureFormatter(DSA);

                //Set the hash algorithm to the passed value.
                DSAFormatter.SetHashAlgorithm(HashAlg);

                //Create a signature for HashValue and return it.
                return DSAFormatter.CreateSignature(HashToSign);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }



        /// <summary>
        /// 验证数字签名.
        /// </summary>
        /// <param name="HashValue"></param>
        /// <param name="SignedHashValue"></param>
        /// <param name="DSAKeyInfo"></param>
        /// <param name="HashAlg"></param>
        /// <returns></returns>
        public static bool DSAVerifyHash(byte[] HashValue, byte[] SignedHashValue, DSAParameters DSAKeyInfo, string HashAlg)
        {
            try
            {
                //Create a new instance of DSACryptoServiceProvider.
                DSACryptoServiceProvider DSA = new DSACryptoServiceProvider();

                //Import the key information. 
                DSA.ImportParameters(DSAKeyInfo);

                //Create an DSASignatureDeformatter object and pass it the 
                //DSACryptoServiceProvider to transfer the private key.
                DSASignatureDeformatter DSADeformatter = new DSASignatureDeformatter(DSA);

                //Set the hash algorithm to the passed value.
                DSADeformatter.SetHashAlgorithm(HashAlg);

                //Verify signature and return the result. 
                return DSADeformatter.VerifySignature(HashValue, SignedHashValue);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return false;
            }

        }

    }
}
