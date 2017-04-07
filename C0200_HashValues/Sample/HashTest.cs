using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

using C0010_SecretKeyEncryption.Util;

namespace C0200_HashValues.Sample
{
    class HashTest
    {


        public static void DoTest()
        {
            Console.WriteLine("MD5 测试！");

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            string source = "Data to Encrypt  这个是一个用于测试MD5的文本信息！";

            byte[] dataToEncrypt = ByteConverter.GetBytes(source);

            Console.WriteLine("原始文本信息：{0}", source);
            Console.WriteLine("原始数据！");
            ByteArrayOutput.Print(dataToEncrypt);



            Console.WriteLine("MD5");
            ByteArrayOutput.Print(MD5hash(dataToEncrypt));

            Console.WriteLine("SHA256");
            ByteArrayOutput.Print(SHA256hash(dataToEncrypt));

            Console.WriteLine("SHA384");
            ByteArrayOutput.Print(SHA384hash(dataToEncrypt));

            Console.WriteLine("SHA512");
            ByteArrayOutput.Print(SHA512hash(dataToEncrypt));

        }





        /// <summary>
        /// 一个  MD5 后 再  MD5 的  密码处理逻辑.
        /// </summary>
        public static void DoTest2()
        {
            ASCIIEncoding ByteConverter = new ASCIIEncoding();

            string source = "1234567890";

            byte[] step1 = ByteConverter.GetBytes(source);

            byte[] step1MD5 = MD5hash(step1);

            ByteArrayOutput.Print(step1MD5);


            string step2Str = ByteArrayOutput.Hexdigest(step1MD5);
            step2Str = step2Str + "TestString";


            Console.WriteLine(step2Str);

            byte[] step2 = ByteConverter.GetBytes(step2Str);


            byte[] step2MD5 = MD5hash(step2);


            ByteArrayOutput.Print(step2MD5);

        }




        /// <summary>
        /// 一个 HMAC-SHA1 加密的处理.
        /// </summary>
        public static void DoTest3()
        {
            string appid = "173a9608f2d411e4936600ffa64984b5";
            string expired_time = "1452663274";
            string secret_key = "aOahcMWCoX6I";
            string rawMask = appid + "_" + expired_time + "_" + secret_key;

            byte[] data = Encoding.UTF8.GetBytes(rawMask);
            byte[] key = Encoding.UTF8.GetBytes(secret_key);

            Console.WriteLine("HMAC-SHA1");
            ByteArrayOutput.Print(HMACSHA1hash(data, key));
        }



        /// <summary>
        /// 计算 MD5.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static byte[] MD5hash(byte[] data)
        {
            // This is one implementation of the abstract class MD5.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            return result;
        }



        /// <summary>
        /// 计算 SHA256 哈希值。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static byte[] SHA256hash(byte[] data)
        {
            SHA256 shaM = new SHA256Managed();
            byte[] result = shaM.ComputeHash(data);
            return result;
        }


        /// <summary>
        /// 计算 SHA384  哈希值。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static byte[] SHA384hash(byte[] data)
        {
            SHA384 shaM = new SHA384Managed();
            byte[] result = shaM.ComputeHash(data);
            return result;
        }


        /// <summary>
        /// 计算 SHA512  哈希值。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static byte[] SHA512hash(byte[] data)
        {
            SHA512 shaM = new SHA512Managed();
            byte[] result = shaM.ComputeHash(data);
            return result;
        }







        static byte[] HMACSHA1hash(byte[] data, byte[] secret)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();

            hmacsha1.Key = secret;

            byte[] result = hmacsha1.ComputeHash(data);
            return result;
        }


    }
}
