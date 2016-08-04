using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;



namespace C0900_Keys.Sample
{
    class AsymmetricKeysTest
    {


        /// <summary>
        /// 测试 生成非对称密钥.
        /// </summary>
        public static void DoTest()
        {
            // Generate a public/private key pair.
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            // 每当创建不对称算法类的新实例时，都生成一个公钥/私钥对。创建该类的新实例后，可以用以下两种方法之一提取密钥信息：
            // ToXMLString 方法，它返回密钥信息的 XML 表示形式。
            Console.WriteLine("仅仅包含公钥的情况！");
            Console.WriteLine(RSA.ToXmlString(false));

            Console.WriteLine("同时包含公钥与私钥的情况！");
            Console.WriteLine(RSA.ToXmlString(true));


            // ExportParameters 方法，它返回保存密钥信息的 RSAParameters 结构。
            // 将使用 RSACryptoServiceProvider 创建的密钥信息导出为 RSAParameters 对象。
            RSAParameters RSAKeyInfo = RSA.ExportParameters(false);




            // 取得目标的  公钥的  XML 信息.
            string xmlString = RSA.ToXmlString(false);



            // Create a UnicodeEncoder to convert between byte array and string.
            UnicodeEncoding ByteConverter = new UnicodeEncoding();


            string source = "Data to Encrypt  这个是一个用于测试加密的文本信息！";


            //Create byte arrays to hold original, encrypted, and decrypted data.
            byte[] dataToEncrypt = ByteConverter.GetBytes(source);
            byte[] encryptedData;
            


            Console.WriteLine("原始文本信息：{0}", source);
            Console.WriteLine("原始数据！");
            ByteArrayOutput.Print(dataToEncrypt);




            // 这里创建一个新的  RSACryptoServiceProvider
            RSACryptoServiceProvider RSA2 = new RSACryptoServiceProvider();

            // 通过 XML 字符串中的密钥信息初始化 RSA 对象。
            RSA2.FromXmlString(xmlString);

            // 公钥加密.
            encryptedData = RSAEncrypt(dataToEncrypt, RSA2.ExportParameters(false), false);

            Console.WriteLine("公钥加密后的数据！");
            ByteArrayOutput.Print(encryptedData);



            byte[] decryptedData;

            // 解密
            decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

            Console.WriteLine("私钥解密后的数据！");
            ByteArrayOutput.Print(decryptedData);


            // 输出.
            Console.WriteLine("私钥解密后的文本: {0}", ByteConverter.GetString(decryptedData));
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


    }
}
