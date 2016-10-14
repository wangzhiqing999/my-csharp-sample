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
                Key = @")O[NB]6,YF}+efcaj{+oESb9d8>Z'e9M",

                // 向量
                IV =@"L+\~f4,Ir)b$=pkf"
            };




            string source = "测试 AES 加密处理！";
            Console.WriteLine("原始字符：{0}", source);


            string step1 = aes.AESEncrypt(source);
            Console.WriteLine("AES 加密后结果：{0}", step1);


            string step2 = aes.AESDecrypt(step1);
            Console.WriteLine("AES 解密后结果：{0}", step2);


            Console.WriteLine("---------- AES : ECB ----------");


            source = "测试 AES 加密处理！";
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




    }

}
 
