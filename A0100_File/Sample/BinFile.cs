using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0100_File.Sample
{


    /// <summary>
    /// 用于 读写 二进制文件的例子
    /// </summary>
    class BinFile
    {

        /// <summary>
        /// 用于 保存二进制文件名的变量
        /// 不指定全路径的情况下，该文件将被创建在 运行时的 “当前目录”下
        /// </summary>
        private const String BIN_FILE_NAME = "BinSample.dat";

        /// <summary>
        /// 测试向创建二进制文件，并向其中写入二进制信息.
        /// </summary>
        public void TestWrite()
        {
            Console.WriteLine("写入二进制文件信息开始！");
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                // 首先判断，文件是否已经存在
                if (File.Exists(BIN_FILE_NAME))
                {
                    // 如果文件已经存在，那么删除掉.
                    File.Delete(BIN_FILE_NAME);
                }
                // 注意第2个参数：
                // FileMode.Create 指定操作系统应创建新文件。如果文件已存在，它将被覆盖。
                fs = new FileStream(BIN_FILE_NAME, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);

                // 写入测试数据.
                bw.Write(0x20);
                bw.Write(1024.567d);
                bw.Write(1024);

                // 注意，二进制写入 字符串信息的时候
                // 带长度前缀的字符串通过在字符串前面放置一个包含该字符串长度的字节或单词，来表示该字符串的长度。
                // 此方法首先将字符串长度作为一个四字节无符号整数写入，然后将这些字符写入流中。

                // 这里将先写入一个 0x07， 然后再写入 abcdefg
                bw.Write("abcdefg");

                // 关闭文件.
                bw.Close();
                fs.Close();

                bw = null;
                fs = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在写入文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (bw != null)
                {
                    try
                    {
                        bw.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视 关闭是否会发生错误了.
                    }
                }
                if (fs != null)
                {
                    try
                    {
                        fs.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视 关闭是否会发生错误了.
                    }
                }
            }
            Console.WriteLine("写入二进制文件信息结束！");
        }


        /// <summary>
        /// 测试向从二进制文件中读取数据，并显示到终端上.
        /// </summary>
        public void TestRead()
        {
            Console.WriteLine("读取二进制文件信息开始！");
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                // 首先判断，文件是否已经存在
                if (!File.Exists(BIN_FILE_NAME))
                {
                    // 如果文件不存在，那么提示无法读取！
                    Console.WriteLine("二进制文件{0}不存在！", BIN_FILE_NAME);
                    return;
                }


                fs = new FileStream(BIN_FILE_NAME, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);


                int a = br.ReadInt32();
                double b = br.ReadDouble();
                int c = br.ReadInt32();

                byte len = br.ReadByte();

                char[] d = br.ReadChars(len);

                Console.WriteLine("第一个数据:{0}", a);
                Console.WriteLine("第二个数据:{0}", b);
                Console.WriteLine("第三个数据:{0}", c);
                Console.WriteLine("第四个数据 (长度为{0}):", len);
                foreach (char ch in d)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
                
                // 读取完毕，关闭.
                br.Close();
                fs.Close();

                br = null;
                fs = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在读取文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (br != null)
                {
                    try
                    {
                        br.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视 关闭是否会发生错误了.
                    }
                }

                if (fs != null)
                {
                    try
                    {
                        fs.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视 关闭是否会发生错误了.
                    }
                }
            }

            Console.WriteLine("读取二进制文件信息结束！");
        }
    }
}
