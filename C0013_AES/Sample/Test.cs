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
            Console.WriteLine("原始处理：{0}", source);


            string step1 = des.DESEncrypt(source);
            Console.WriteLine("DES 加密后结果：{0}", step1);


            string step2 = des.DESDecrypt(step1);
            Console.WriteLine("DES 解密后结果：{0}", step2);


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
            Console.WriteLine("原始处理：{0}", source);


            string step1 = aes.AESEncrypt(source);
            Console.WriteLine("AES 加密后结果：{0}", step1);


            string step2 = aes.AESDecrypt(step1);
            Console.WriteLine("AES 解密后结果：{0}", step2);

        }



    }

}
 
