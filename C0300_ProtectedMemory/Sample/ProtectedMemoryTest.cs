using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;



namespace C0300_ProtectedMemory.Sample
{
    class ProtectedMemoryTest
    {

        public static void DoTest()
        {

            Console.WriteLine("测试使用 ProtectedMemory 来完成  内存中的数据加密/解密 的处理.");


            // 注意： 那个  MemoryProtectionScope  参数很重要！
            // 成员名称         说明
            // SameProcess      只有与调用 Protect 方法的代码在相同的进程中运行的代码才能取消对内存的保护。
            // CrossProcess     任何进程中的任何代码均可使用 Protect 方法取消对受保护内存的保护。
            // SameLogon        只有与调用 Protect 方法的代码在相同的用户上下文中运行的代码才能取消对内存的保护。

            // Create the original data to be encrypted (The data length should be a multiple of 16).
            byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes("ThisIsSomeData16");



            Console.WriteLine("原始数据：" + UnicodeEncoding.ASCII.GetString(toEncrypt));
            Console.WriteLine("开始加密...");

            // Encrypt the data in memory.
            EncryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon);

            Console.WriteLine("加密数据: " + UnicodeEncoding.ASCII.GetString(toEncrypt));


            Console.WriteLine("开始解密...");

            // Decrypt the data in memory.
            DecryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon);

            Console.WriteLine("解密后的数据: " + UnicodeEncoding.ASCII.GetString(toEncrypt));


        }





        /// <summary>
        /// 加密内存中的数据.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="Scope"></param>
        public static void EncryptInMemoryData(byte[] Buffer, MemoryProtectionScope Scope)
        {
            if (Buffer.Length <= 0)
                throw new ArgumentException("Buffer");
            if (Buffer == null)
                throw new ArgumentNullException("Buffer");


            // Encrypt the data in memory. The result is stored in the same same array as the original data.
            ProtectedMemory.Protect(Buffer, Scope);

        }


        /// <summary>
        /// 解密内存中的数据.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="Scope"></param>
        public static void DecryptInMemoryData(byte[] Buffer, MemoryProtectionScope Scope)
        {
            if (Buffer.Length <= 0)
                throw new ArgumentException("Buffer");
            if (Buffer == null)
                throw new ArgumentNullException("Buffer");


            // Decrypt the data in memory. The result is stored in the same same array as the original data.
            ProtectedMemory.Unprotect(Buffer, Scope);

        }

    }
}
