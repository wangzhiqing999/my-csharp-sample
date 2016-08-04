using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;


namespace C0010_SecretKeyEncryption.Sample
{

    public abstract class CommonService
    {


        protected abstract string GetServiceName();


        protected abstract SymmetricAlgorithm GetService();




        public void DoTest()
        {

            Console.WriteLine("#####  访问 {0} 算法的测试！！！#####", GetServiceName());


            try
            {

                string original = "Here is some data to encrypt!  这里是一些需要被加密的数据...";


                Console.WriteLine("原始数据:   {0}", original);


                // 注意：这个构造函数， 每次会初始化不同的 密钥（Key） 与 初始化向量 (IV)
                // 实际开发过程中， 密钥（Key） 与 初始化向量 (IV) 需要保存在本地系统中。
                // 加密/解密以前， 设置一下 Key 和 IV。
                // 不能简单地 加密的时候 new 一个  解密的时候，再 new 一个  
                SymmetricAlgorithm service = GetService();


                // 私钥加密的缺点是它假定双方已就密钥和 IV 达成协议，并且互相传达了密钥和 IV 的值。 
                // 一般认为，IV 并不安全，且可以在消息的纯文本中传输。 
                // 但是，密钥必须对未经授权的用户保密。 
                // 由于存在这些问题，因此通常将私钥加密与公钥加密配合使用，以秘密地传达密钥和 IV 的值。

                // 假定 Alice 和 Bob 是希望在非安全信道上通信的双方，
                // 他们可以按如下方式使用私钥加密：Alice 和 Bob 同意对特定的密钥和 IV 应用一种特定的算法（例如 AES）。 
                // Alice 撰写一条消息并创建要在其上发送该消息的网络流（可能是一个命名管道或网络电子邮件）。
                // 接下来，她使用该密钥和 IV 加密文本，并通过 Intranet 向 Bob 发送该加密消息和 IV。 
                // Bob 在收到该加密文本后，可使用 IV 和预先商定的密钥对它进行解密。
                // 即使传输的内容被人截获，截获者也无法恢复原始消息，因为他并不知道密钥。
                // 在此方案中，只有密钥必须保密。


                Console.WriteLine("对称算法的密钥:");
                ByteArrayOutput.Print(service.Key);

                Console.WriteLine("对称算法的对称算法的初始化向量 (IV):");
                ByteArrayOutput.Print(service.IV);


                Console.WriteLine("开始做加密处理......");
                byte[] encrypted = EncryptStringToBytes(service, original);


                Console.WriteLine("加密后的内容:");
                ByteArrayOutput.Print(encrypted);




                Console.WriteLine("开始做解密处理......");
                string roundtrip = DecryptStringFromBytes(service, encrypted);


                Console.WriteLine("解密后的数据: {0}", roundtrip);
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

        }








        /// <summary>
        /// 加密数据.
        /// </summary>
        /// <param name="service"> 加密处理的服务 </param>
        /// <param name="plainText"> 加密的文本 </param>
        /// <returns> 加密后的字节数组 </returns>
        public byte[] EncryptStringToBytes(SymmetricAlgorithm service, string plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");

            // 用于存储加密后的结果信息.
            byte[] encrypted;

            // 创建对称加密器对象.
            ICryptoTransform encryptor = service.CreateEncryptor();
            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            // 返回内存中的加密结果.
            return encrypted;
        }


        /// <summary>
        /// 解密数据.
        /// </summary>
        /// <param name="service"> 解密处理的服务 </param>
        /// <param name="cipherText"> 被加密的字节数组 </param>
        /// <returns> 解密后的文本信息 </returns>
        public string DecryptStringFromBytes(SymmetricAlgorithm service, byte[] cipherText)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");

            // 预期返回的结果.
            string plaintext = null;

            // 创建对称解密器对象。
            ICryptoTransform decryptor = service.CreateDecryptor();

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            // 返回.
            return plaintext;

        }




    }

}
