using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace C0013_AES.Sample
{
    class Test
    {



        public void TestDes()
        {

            DES des = new DES()
            {
                // 密钥
                Key = @"P@+#wG+Z",

                // 向量
                IV = @"L%n67}G\Mk@k%:~Y"
            };


            string source = "测试 DES 加密处理！";
            Console.WriteLine("原始字符：{0}", source);


            string step1 = des.DESEncrypt(source);
            Console.WriteLine("DES 加密后结果：{0}", step1);


            string step2 = des.DESDecrypt(step1);
            Console.WriteLine("DES 解密后结果：{0}", step2);


            Console.WriteLine();

        }






        public void TestAes()
        {
            AES aes = new AES()
            {
                // 密钥
                Key = @"1234567890123456",

                // 向量
                IV = @"1234567890123456"
            };



            // 这个是用于测试 使用同样的 Key+IV.
            // Java 的加密、解密。
            // 是否与 C# 的结果一致。
            string source = "13000000000";
            Console.WriteLine("原始字符：{0}", source);


            string step1 = aes.AESEncrypt(source);
            Console.WriteLine("AES 加密后结果：{0}", step1);


            string step2 = aes.AESDecrypt(step1);
            Console.WriteLine("AES 解密后结果：{0}", step2);


            Console.WriteLine("---------- AES : ECB ----------");


            source = "13000000000";
            Console.WriteLine("原始字符：{0}", source);


            step1 = aes.AESEncryptECB(source);
            Console.WriteLine("AES 加密后结果：{0}", step1);


            step2 = aes.AESDecryptECB(step1);
            Console.WriteLine("AES 解密后结果：{0}", step2);






            Console.WriteLine("---------- AES : ECB （长度为12的 Key/IV）----------");


            AES aes2 = new AES()
            {
                // 密钥
                Key = @"ab.cd.efg.hi",

                // 向量
                IV = @"ab.cd.efg.hi"
            };


            source = "测试 AES 加密处理！";
            Console.WriteLine("原始字符：{0}", source);


            step1 = aes2.AESEncryptECB(source);
            Console.WriteLine("AES 加密后结果：{0}", step1);


            step2 = aes2.AESDecryptECB(step1);
            Console.WriteLine("AES 解密后结果：{0}", step2);


            
            Console.WriteLine();
        }








        public void TestAes2()
        {
            AES2 aes = new AES2()
            {
                // 密钥
                Key = @")O[NB]6,YF}+efcaj{+oESb9d8>Z'e9M",

                // 向量
                IV = @"L+\~f4,Ir)b$=pkf"
            };



            Console.WriteLine("---------- AES : CBC ----------");

            string source = "测试 AES 加密处理！";
            Console.WriteLine("原始字符：{0}", source);


            string step1 = aes.AESEncryptCBC(source);
            Console.WriteLine("AES 加密后结果：{0}", step1);


            string step2 = aes.AESDecryptCBC(step1);
            Console.WriteLine("AES 解密后结果：{0}", step2);








            // 注意： 
            // 如果在开发过程中， 遇到   指定的初始化向量(IV)与此算法的块大小不匹配。
            // 而这个 IV 又是对方提供的，自己不能修改的。
            // 这种情况下， 大概率是使用 ECB 模式进行处理。


            Console.WriteLine("---------- AES : ECB ----------");


            source = "测试 AES 加密处理！";
            Console.WriteLine("原始字符：{0}", source);


            step1 = aes.AESEncryptECB(source);
            Console.WriteLine("AES 加密后结果：{0}", step1);


            step2 = aes.AESDecryptECB(step1);
            Console.WriteLine("AES 解密后结果：{0}", step2);



            Console.WriteLine("---------- AES : ECB （长度为12的 Key/IV）----------  这个类会报错， 提示 Key 不符合。");

        }








        public void TestMySql()
        {

            Console.WriteLine();
            Console.WriteLine("----- C# 与 Mysql 的 AES_ENCRYPT. -----");

            AES2 aes = new AES2()
            {
                // 密钥
                Key = @"0123456789ABCDEF",

                // 向量
                IV = @"0000000000000000"
            };


            // MySQL 可以通过block_encryption_mode参数，控制块加密模式，默认值为：aes-128-ecb。
            // 可配置的形式为：aes - keylen–mode。
            // 其中：
            // keylen可配置为128, 192, 256
            // mode可配置为ECB, CBC, CFB1, CFB8, CFB128, OFB




            // SET block_encryption_mode = 'aes-128-ecb';
            // 
            // SELECT 
            //   HEX(AES_ENCRYPT('C0013_AES.Sample', '0123456789ABCDEF', '0000000000000000')) AS hex,
            //   to_base64(AES_ENCRYPT('C0013_AES.Sample', '0123456789ABCDEF', '0000000000000000')) as base64;
            // 
            // 
            // 616ADDD573E60A22F3C539696DBFDA1234AF336C9F031B3556738C63E61EA2F6	
            // YWrd1XPmCiLzxTlpbb/aEjSvM2yfAxs1VnOMY+YeovY=



            // SET block_encryption_mode = 'aes-128-cbc';
            // 
            // SELECT
            //  HEX(AES_ENCRYPT('C0013_AES.Sample', '0123456789ABCDEF', '0000000000000000')) AS hex,
            //  to_base64(AES_ENCRYPT('C0013_AES.Sample', '0123456789ABCDEF', '0000000000000000')) as base64;

            // 3ACFAC228A24D3964A05C0CF835DBBFC88E362999FCD9960602CB78C2B349B4C
            // Os+sIook05ZKBcDPg127/IjjYpmfzZlgYCy3jCs0m0w =







            string source = "C0013_AES.Sample";
            Console.WriteLine("原始字符：{0}", source);


            string step1 = aes.AESEncryptECB(source);
            Console.WriteLine("AES-128-ECB 加密后结果：{0}", step1);

            byte[] data = Convert.FromBase64String(step1);
            foreach(var d in data)
            {
                Console.Write("{0:X2}", d);
            }
            Console.WriteLine();


            string step2 = aes.AESDecryptECB(step1);
            Console.WriteLine("AES-128-ECB 解密后结果：{0}", step2);
            Console.WriteLine();




            step1 = aes.AESEncryptCBC(source);
            Console.WriteLine("AES-128-CBC 加密后结果：{0}", step1);

            data = Convert.FromBase64String(step1);
            foreach (var d in data)
            {
                Console.Write("{0:X2}", d);
            }
            Console.WriteLine();


            step2 = aes.AESDecryptCBC(step1);
            Console.WriteLine("AES-128-CBC 解密后结果：{0}", step2);

        }



    }

}
 
