using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1011_SM2
{
    internal class Program
    {


        /// <summary>
        /// 公钥.
        /// <br/>
        /// 可在网站生成一对公钥私钥.
        /// 
        /// https://lzltool.cn/SM2
        /// </summary>
        private const string _PublicKey = "04d300f5cebddb81eec359a80c810fea09158883e7724ea59b2187f6770f0fdae0fa5b2c5927b9545fecbc5d46fd5681dfdb511c2886dfc0c81c9513fce22ff6a8";


        /// <summary>
        /// 私钥.
        /// </summary>
        private const string _PrivateKey = "20da010ed7ee3308bb46d7d94d2c3568ec34109714e63679cd509beeef05517f";



        /// <summary>
        /// 老标准 C1C2C3 的密文数据顺序.
        /// </summary>
        private static SM2CryptoUtil sm2_c1c2c3 = new SM2CryptoUtil(Hex.Decode(_PublicKey), Hex.Decode(_PrivateKey), SM2CryptoUtil.Mode.C1C2C3);

        /// <summary>
        /// 新标准 C1C3C2 的密文数据顺序.
        /// </summary>
        private static SM2CryptoUtil sm2_c1c3c2 = new SM2CryptoUtil(Hex.Decode(_PublicKey), Hex.Decode(_PrivateKey), SM2CryptoUtil.Mode.C1C3C2);




        static void Main(string[] args)
        {

            // 测试 旧标准的【C1C2C3】， 自己加密，自己解密。
            string test1 = Test_01("1234567890");
            Test_02(test1);


            // 测试新标准的【C1C3C2】， 自己加密，自己解密。
            string test5 = Test_51("1234567890");
            Test_52(test5);





            // 测试 https://lzltool.cn/SM2 的旧标准的【C1C2C3】加密结果，本地能否完成解密.
            // Test_02("043dc973d15d91db43da4701ea155ba01818e9c1e4f1e780b7b07fb3107f7525943e912515cf3db068813d99f4ed8d319afa1ec1e3cb28569b17b7a4ee372633d82962019d24fb802d440cf3bcba5088f0243185aafa0153381bd289c71909705aa33b9ac1cc29944f5938");
            // 结果是解密过程发生异常.


            // 测试 https://lzltool.cn/SM2 的新标准的【C1C3C2】加密结果，本地能否完成解密.
            Test_52("04e844e45a82bbf5329815999723a39e4d0354f2092372974b8b7ad111b336245c5eb41e970e9d8af87c8aab56789555913651dec37d1fa3f23065fcf67d31ac74f4a08be41df87fe6faf8e67aa3938c6d3dc0c9ef7b912dee3b67c61bbf2121495680228b53d311dbbd79");
            // 结果是解密成功.



            Console.WriteLine("--- Finish ---");
            Console.ReadLine();
        }




        /// <summary>
        /// 老标准 C1C2C3 的 加密测试. 
        /// 
        /// 测试代码的加密结果， 在  https://lzltool.cn/SM2  网站上， 能够正确的完成解密。
        /// </summary>
        /// <param name="sourceText"></param>
        /// <returns></returns>
        static string Test_01(string sourceText)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"加密：{sourceText}");

            byte[] sourceData = Encoding.UTF8.GetBytes(sourceText);
            byte[] cipherData = sm2_c1c2c3.Encrypt(sourceData);
            string cipherText = Hex.ToHexString(cipherData);
            
            Console.WriteLine($"密文：{cipherText}");
            Console.WriteLine();
            return cipherText;
        }


        /// <summary>
        /// 老标准 C1C2C3 的 解密测试.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        static string Test_02(string cipherText)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"解密：{cipherText}");

            byte[] cipherData = Hex.Decode(cipherText);
            byte[] plainData = sm2_c1c2c3.Decrypt(cipherData);
            string plainText = Encoding.UTF8.GetString(plainData);

            Console.WriteLine($"明文：{plainText}");
            Console.WriteLine();
            return plainText;
        }




        /// <summary>
        /// 新标准 C1C3C2 的 加密测试. 
        /// 
        /// 测试代码的加密结果， 在  https://lzltool.cn/SM2  网站上， 能够正确的完成解密。
        /// </summary>
        /// <param name="sourceText"></param>
        /// <returns></returns>
        static string Test_51(string sourceText)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"加密：{sourceText}");

            byte[] sourceData = Encoding.UTF8.GetBytes(sourceText);
            byte[] cipherData = sm2_c1c3c2.Encrypt(sourceData);
            string cipherText = Hex.ToHexString(cipherData);

            Console.WriteLine($"密文：{cipherText}");
            Console.WriteLine();
            return cipherText;
        }


        /// <summary>
        /// 新标准 C1C3C2 的 解密测试. 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        static string Test_52(string cipherText)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"解密：{cipherText}");

            byte[] cipherData = Hex.Decode(cipherText);
            byte[] plainData = sm2_c1c3c2.Decrypt(cipherData);
            string plainText = Encoding.UTF8.GetString(plainData);

            Console.WriteLine($"明文：{plainText}");
            Console.WriteLine();
            return plainText;
        }

    }
}
