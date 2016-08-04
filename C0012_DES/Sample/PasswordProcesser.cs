using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Security.Cryptography;



namespace C0012_DES.Sample
{

    public class PasswordProcesser
    {



        private static ASCIIEncoding byteConverter = new ASCIIEncoding();


        private static MD5 md5 = new MD5CryptoServiceProvider();



        /// <summary>
        /// 空的 IV.
        /// (当模式为ECB时，IV无用)
        /// </summary>
        private static byte[] emptyIV = new byte[] { };



        public static string GetDisplayByteArrayData(byte[] data)
        {
            StringBuilder buff = new StringBuilder();
            foreach (var b in data)
            {
                buff.AppendFormat("{0:X2}", b);
            }
            return buff.ToString();
        }


        /// <summary>
        /// 加密处理.
        /// 将身份证进行MD5加密作为DES加密的密钥，然后进行BASE64加密
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string PasswordEncode(string idCardNo, string password)
        {


            Console.WriteLine("尝试使用身份证 {0}，  对 {1} 进行加密！", idCardNo, password);
            


            // 步骤1. 计算 身份证进行MD5.

            // 源字符串转换为 byte数组.
            byte[] idCardNoData = byteConverter.GetBytes(idCardNo);

            // MD5 处理.
            byte[] md5Result = md5.ComputeHash(idCardNoData);


            string md5String = GetDisplayByteArrayData(md5Result);
            Console.WriteLine(@"步骤1：
计算身份证 {0} 的MD5 
结果: {1} ", idCardNo, md5String);
            




            // 步骤2. DES 加密.

            byte[] passwordData = byteConverter.GetBytes(password);


       
            byte[] desKey = new byte[8];
            Array.Copy(sourceArray: md5Result, destinationArray: desKey, sourceIndex: 0, destinationIndex: 0, length: 8);

            byte[] desIv = new byte[8];
            Array.Copy(sourceArray: md5Result, destinationArray: desIv, sourceIndex: 8, destinationIndex: 0, length: 8);

            byte[] des3Result = DESEncrypt(desKey, desIv, passwordData);

            
            Console.WriteLine(@"步骤2：
将 {0} 作为DES加密的密钥 Key
将 {1} 作为DES加密的密钥 Iv
对密码 {2} 进行加密
结果: {3} ",
                    GetDisplayByteArrayData(desKey),
                    GetDisplayByteArrayData(desIv),
                    GetDisplayByteArrayData(passwordData),
                    GetDisplayByteArrayData(des3Result));
            
     


            // byte[] des3Result = DESEncrypt(md5Result, md5Result, passwordData);



            // 步骤3. BASE64 加密.

            string base64Result = Convert.ToBase64String(des3Result);


            
            Console.WriteLine(@"步骤3： 
将 {0} 作 BASE64 加密
结果: {1}",
                    GetDisplayByteArrayData(des3Result),
                    base64Result);
            

            return base64Result;
        }








        /// <summary>
        /// 解密处理.
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string PasswordDecode(string idCardNo, string passwordString)
        {

            Console.WriteLine("尝试使用身份证 {0}，  对 {1} 进行解密！", idCardNo, passwordString);

            // 步骤1. 计算 身份证进行MD5.

            // 源字符串转换为 byte数组.
            byte[] idCardNoData = byteConverter.GetBytes(idCardNo);

            // MD5 处理.
            byte[] md5Result = md5.ComputeHash(idCardNoData);

            string md5String = GetDisplayByteArrayData(md5Result);
            Console.WriteLine(@"步骤1：
计算身份证 {0} 的MD5 
结果: {1} ", idCardNo, md5String);
            



            // 步骤2. BASE64 解密.
            byte[] base64Data = Convert.FromBase64String(passwordString);

            Console.WriteLine(@"步骤2：
将字符串 {0}  Base64 解密
结果: {1} ", passwordString, GetDisplayByteArrayData(base64Data));
            


          
            byte[] desKey = new byte[8];
            Array.Copy(sourceArray: md5Result, destinationArray: desKey, sourceIndex: 0, destinationIndex: 0, length: 8);

            byte[] desIv = new byte[8];
            Array.Copy(sourceArray: md5Result, destinationArray: desIv, sourceIndex: 8, destinationIndex: 0, length: 8);


            // 步骤3. DES 解密.
            byte[] des3Result = DESDecrypt(desKey, desIv, base64Data);

            Console.WriteLine(@"步骤3：
将 {0} 作为DES加密的密钥 Key
将 {1} 作为DES加密的密钥 Iv
对数据 {2} 进行解密
结果: {3} ",
                    GetDisplayByteArrayData(desKey),
                    GetDisplayByteArrayData(desIv),
                    GetDisplayByteArrayData(base64Data),
                    GetDisplayByteArrayData(des3Result));

         

            //byte[] des3Result = DESDecrypt(md5Result, md5Result, base64Data);


            string result = byteConverter.GetString(des3Result);


            return result;

        }








        #region DES 加密/解密


        /// <summary>
        /// DES加密
        /// </summary>
        /// <returns></returns>
        public static byte[] DESEncrypt(byte[] key, byte[] iv, byte[] data)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            // java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
            cryptoProvider.Mode = CipherMode.ECB;

            
            cryptoProvider.Key = key;
            cryptoProvider.IV = iv;

            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cst.Write(data, 0, data.Length);
            cst.FlushFinalBlock();

            return ms.ToArray();
        }


        /// <summary>
        /// DES解密
        /// </summary>
        /// <returns></returns>
        public static byte[] DESDecrypt(byte[] key, byte[] iv, byte[] data)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            // java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
            cryptoProvider.Mode = CipherMode.ECB;

            
            cryptoProvider.Key = key;
            cryptoProvider.IV = iv;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();

            return ms.ToArray();
        }



        #endregion






    }


}
