using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Security.Cryptography;


namespace C0013_AES.Sample
{



    public class AES2
    {


        /// <summary>
        /// 密钥
        /// </summary>
        public string Key { set; get; }


        /// <summary>
        /// 向量
        /// </summary>
        public string IV { set; get; }








        #region CBC模式

        // CBC模式
        // 优点： 
        // 1.不容易主动攻击,安全性好于ECB,适合传输长度长的报文,是SSL、IPSec的标准。 
        // 缺点：
        // 1.不利于并行计算； 
        // 2.误差传递； 
        // 3.需要初始化向量IV 


        /// <summary>
        /// AES加密 - CBC
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <returns>密文</returns>
        public string AESEncryptCBC(string plainStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;


            // AesManaged - 高级加密标准(AES) 对称算法的管理类
            AesManaged aes = new AesManaged();
            // 模式 ： CBC
            aes.Mode = CipherMode.CBC;


            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            aes.Clear();

            return encrypt;
        }




        /// <summary>
        /// AES解密 - CBC
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <returns>明文</returns>
        public string AESDecryptCBC(string encryptStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;


            // AesManaged - 高级加密标准(AES) 对称算法的管理类
            AesManaged aes = new AesManaged();

            // 模式 ： CBC
            aes.Mode = CipherMode.CBC;


            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            aes.Clear();

            return decrypt;
        }



        #endregion









        #region ECB模式

        // ECB模式
        // 优点:
        // 1.简单； 
        // 2.有利于并行计算； 
        // 3.误差不会被传送； 
        // 缺点: 
        // 1.不能隐藏明文的模式； 
        // 2.可能对明文进行主动攻击；


        /// <summary>
        /// AES加密 - ECB
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <returns>密文</returns>
        public string AESEncryptECB(string plainStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;


            // AesManaged - 高级加密标准(AES) 对称算法的管理类
            AesManaged aes = new AesManaged();
            // 模式 ： ECB
            aes.Mode = CipherMode.ECB;


            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            aes.Clear();

            return encrypt;
        }




        /// <summary>
        /// AES解密 - ECB
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <returns>明文</returns>
        public string AESDecryptECB(string encryptStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;


            // AesManaged - 高级加密标准(AES) 对称算法的管理类
            AesManaged aes = new AesManaged();

            // 模式 ： ECB
            aes.Mode = CipherMode.ECB;


            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            aes.Clear();

            return decrypt;
        }



        #endregion







    }




}
