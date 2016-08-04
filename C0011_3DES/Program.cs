using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using C0011_3DES.Sample;


namespace C0011_3DES
{
    class Program
    {

        // 注意：
        // 写这个例子的原因，是因为在某项目的文档中，有下面的描述：
        // 报文由报文头和报文体组成，用3DES加密，加密密钥是ABCDEF0123456789abcdef11

        // 而查看了一下， DESCryptoServiceProvider 类的说明。
        // 外部需要传递  byte[] desKey, byte[] desIV 这两个参数。

        // 进一步查找资料， 并对照 提供的 Java 例子代码后。
        // 了解到， 项目使用的 3DES 加密算法， 是 ECB模式




        // 因为这个例子， 是直接从网上抓下来的例子，  代码中，存在一些小问题。
        // 也就是那个 解密处理的方法， 返回的 byte 数组长度， 等于  加密的 byte 数组长度。

        // 这样会导致 某些字符串处理的情况下， 会抱错， 提示 字符串中， 包含 0x00  的字符。


        static void Main(string[] args)
        {

            Test();

            OtherTest();

            Console.ReadLine();
        }






        /// <summary>
        /// 测试
        /// </summary>
        public static void Test()
        {
            System.Console.WriteLine("3DES 加密-解密 测试， 测试目标， 明确 ECB 模式  与 CBC 模式 的区别！");


            System.Text.Encoding utf8 = System.Text.Encoding.UTF8;

            // key为abcdefghijklmnopqrstuvwx的Base64编码
            byte[] key = Convert.FromBase64String("YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4");

            // 当模式为ECB时，IV无用
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      
            byte[] iv2 = new byte[] {8, 7, 6, 5, 4, 3, 2, 1};      


            // 原文.
            byte[] data = utf8.GetBytes("中国ABCabc123");


            System.Console.WriteLine("ECB模式:");

            // 加密
            byte[] str1 = Des3.Des3EncodeECB(key, iv, data);
            System.Console.WriteLine("加密结果：{0}", Convert.ToBase64String(str1));

            // 验证，是否 ECB 模式下， IV 无用.
            byte[] strECB = Des3.Des3EncodeECB(key, iv2, data);
            System.Console.WriteLine("设置了其他的IV，加密结果为：{0}", Convert.ToBase64String(strECB));

            // 解密.
            byte[] str2 = Des3.Des3DecodeECB(key, iv, str1);            
            System.Console.WriteLine("解密后结果：{0}",System.Text.Encoding.UTF8.GetString(str2));
            System.Console.WriteLine();



            System.Console.WriteLine("CBC模式:");

            // 加密
            byte[] str3 = Des3.Des3EncodeCBC(key, iv, data);
            System.Console.WriteLine("加密结果：{0}", Convert.ToBase64String(str3));

            // 验证，是否 CBC 模式下， IV 是有用的.
            byte[] strCBC = Des3.Des3EncodeCBC(key, iv2, data);
            System.Console.WriteLine("设置了其他的IV，加密结果为：{0}", Convert.ToBase64String(strCBC));

            // 解密.
            byte[] str4 = Des3.Des3DecodeCBC(key, iv, str3);
            System.Console.WriteLine("解密后结果：{0}", utf8.GetString(str4));
            System.Console.WriteLine();
        }






        /// <summary>
        /// 其它的测试.
        /// </summary>
        public static void OtherTest()
        {
            // 待加密的 xml 字符串.
            string xml = "<?xml version=\"1.0\" encoding=\"GBK\"?><request><head><h_exch_code>208801</h_exch_code><h_bank_no>0020</h_bank_no><h_user_id>1120888233</h_user_id><h_branch_id>B00008211</h_branch_id><h_fact_date></h_fact_date>2013-03-01<h_fact_time></h_fact_time>15:58:39<h_exch_date></h_exch_date><h_serial_no>12345678</h_serial_no><h_rsp_code></h_rsp_code><h_rsp_msg></h_rsp_msg></head><body><record></record></body></request>";


            // 编码.
            System.Text.Encoding gbk = System.Text.Encoding.GetEncoding("GBK");

            // 密码.
            string pwd = "ABCDEF0123456789abcdef11";

            // 密钥字节数组.
            byte[] key = gbk.GetBytes(pwd);

            // 当模式为ECB时，IV无用
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };   

            // 明文.
            byte[] data = gbk.GetBytes(xml);


            // 加密
            byte[] str1 = Des3.Des3EncodeECB(key, iv, data);
            System.Console.WriteLine("加密结果：{0}", Convert.ToBase64String(str1));


            // 解密.
            byte[] str2 = Des3.Des3DecodeECB(key, iv, str1);
            System.Console.WriteLine("解密后结果：{0}", System.Text.Encoding.UTF8.GetString(str2));
            System.Console.WriteLine();

        }


    }
}
