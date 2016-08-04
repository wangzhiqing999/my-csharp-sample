using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;


namespace C0020_PublicKeyEncryption.Sample
{

    /// <summary>
    /// 使用 RSACryptoServiceProvider 类将一个字符串加密为一个字节数组，然后将这些字节解密为字符串。
    /// 
    /// 
    /// RSA 允许同时进行加密和签名，但 DSA 只能用于签名，Diffie-Hellman 只能用于生成密钥。通常情况下，公钥算法比私钥算法具有更多的使用限制。
    /// </summary>
    class RSACSPSample
    {



        public static void DoTest()
        {

            Console.WriteLine("使用 RSACryptoServiceProvider 类将一个字符串加密为一个字节数组，然后将这些字节解密为字符串。");


            try
            {
                // Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();


                string source = "Data to Encrypt  这个是一个用于测试加密的文本信息！";


                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = ByteConverter.GetBytes(source);
                byte[] encryptedData;
                byte[] decryptedData;


                Console.WriteLine("原始文本信息：{0}", source);
                Console.WriteLine("原始数据！");
                ByteArrayOutput.Print(dataToEncrypt);


                // 加密服务提供程序 (CSP) 提供的 RSA 算法的实现
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                // 加密  (公钥加密).
                encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                Console.WriteLine("公钥加密后的数据！");
                ByteArrayOutput.Print(encryptedData);



                // 解密  (私钥解密)
                decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                Console.WriteLine("私钥解密后的数据！");
                ByteArrayOutput.Print(decryptedData);


                // 输出.
                Console.WriteLine("解密后的文本: {0}", ByteConverter.GetString(decryptedData));
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");

            }
        }





        /// <summary>
        /// 数据加密.
        /// </summary>
        /// <param name="DataToEncrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }



        /// <summary>
        /// 数据解密.
        /// </summary>
        /// <param name="DataToDecrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                //Import the RSA Key information. This needs
                //to include the private key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Decrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }







        /// <summary>
        /// 输出密钥的内部数据信息.
        /// </summary>
        /// <param name="RSAKeyInfo"></param>
        public static void PrintRSAParameters(RSAParameters RSAKeyInfo)
        {
            if (RSAKeyInfo.D != null)
            {
                Console.WriteLine("-----D-----");
                ByteArrayOutput.Print(RSAKeyInfo.D);
            }


            if (RSAKeyInfo.DP != null)
            {
                Console.WriteLine("-----DP-----");
                ByteArrayOutput.Print(RSAKeyInfo.DP);
            }


            if (RSAKeyInfo.DQ != null)
            {
                Console.WriteLine("-----DQ-----");
                ByteArrayOutput.Print(RSAKeyInfo.DQ);
            }

            if (RSAKeyInfo.Exponent != null)
            {
                Console.WriteLine("-----Exponent-----");
                ByteArrayOutput.Print(RSAKeyInfo.Exponent);
            }

            if (RSAKeyInfo.Modulus != null)
            {
                Console.WriteLine("-----Modulus-----");
                ByteArrayOutput.Print(RSAKeyInfo.Modulus);
            }

            if (RSAKeyInfo.InverseQ != null)
            {
                Console.WriteLine("-----InverseQ-----");
                ByteArrayOutput.Print(RSAKeyInfo.InverseQ);
            }

            if (RSAKeyInfo.P != null)
            {
                Console.WriteLine("-----P-----");
                ByteArrayOutput.Print(RSAKeyInfo.P);
            }

            if (RSAKeyInfo.Q != null)
            {
                Console.WriteLine("-----Q-----");
                ByteArrayOutput.Print(RSAKeyInfo.Q);
            }
        }



    }
}
