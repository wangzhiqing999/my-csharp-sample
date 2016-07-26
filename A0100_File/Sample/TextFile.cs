using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0100_File.Sample
{


    /// <summary>
    /// 用于 读写 文本文件的例子
    /// </summary>
    class TextFile
    {

        /// <summary>
        /// 用于 保存文本文件名的变量
        /// 不指定全路径的情况下，该文件将被创建在 运行时的 “当前目录”下
        /// </summary>
        public const String TEXT_FILE_NAME = "TextSample.txt";

        /// <summary>
        /// 测试向创建文本文件，并向其中写入文本信息.
        /// </summary>
        public void TestWrite()
        {
            Console.WriteLine("写入文本文件信息开始！");

            StreamWriter sw = null;

            try
            {
                // 首先判断，文件是否已经存在
                if (File.Exists(TEXT_FILE_NAME))
                {
                    // 如果文件已经存在，那么删除掉.
                    File.Delete(TEXT_FILE_NAME);
                }

                // 注意第2个参数：
                // 确定是否将数据追加到文件。如果该文件存在，并且 append 为 false，则该文件被覆盖。
                // 如果该文件存在，并且 append 为 true，则数据被追加到该文件中。否则，将创建新文件。
                // 也就是说，如果第2个参数 是 false， 可以不用写前面的 判断文件存在则删除的代码.

                // 第3个参数为编码方式， 读取和写入，尽可能使用统一的编码
                sw = new StreamWriter(TEXT_FILE_NAME, false, Encoding.UTF8);

                // 写入测试数据.
                sw.WriteLine("这是一个文本文件的 写入/读取 例子……");
                sw.WriteLine("这是第二行");
                sw.WriteLine("后面没有了……");

                // 关闭文件.
                sw.Close();

                sw = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在写入文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                {
                    try
                    {
                        sw.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视 关闭是否会发生错误了.
                    }
                }
            }

            Console.WriteLine("写入文本文件信息结束！");
        }


        /// <summary>
        /// 测试向从文本文件中读取数据，并显示到终端上.
        /// </summary>
        public void TestRead()
        {
            Console.WriteLine("读取文本文件信息开始！");


            StreamReader sr = null;

            try
            {
                // 首先判断，文件是否已经存在
                if (!File.Exists(TEXT_FILE_NAME))
                {
                    // 如果文件不存在，那么提示无法读取！
                    Console.WriteLine("文本文件{0}不存在！", TEXT_FILE_NAME);
                    return;
                }

                // 注意：
                // 这里使用了 与上面相同的编码 UTF-8

                // 如果在开发项目的时候，遇到 读取 “其他系统”的文本文件，读取出来的数据为乱码的时候
                // 或者 本系统输出的文本， 别的系统读取为乱码的时候。

                // 这种情况下，需要考察 编码方面的设置，是否一致。
                sr = new StreamReader(TEXT_FILE_NAME, Encoding.UTF8);

                // 用于暂存 文本文件数据的 行.
                String line = null;

                // 用于暂存 行号.
                int lineNo = 0;

                do
                {
                    // 一次读取一行数据.
                    line = sr.ReadLine();
                    // 行号递增.
                    lineNo++;

                    if (line != null)
                    {
                        Console.WriteLine("{0} : {1}", lineNo, line);
                    }

                } while (line != null);

                // 读取完毕，关闭.
                sr.Close();

                sr = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在读取文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                {
                    try
                    {
                        sr.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视 关闭是否会发生错误了.
                    }
                }
            }

            Console.WriteLine("读取文本文件信息结束！");
        }
    }
}
