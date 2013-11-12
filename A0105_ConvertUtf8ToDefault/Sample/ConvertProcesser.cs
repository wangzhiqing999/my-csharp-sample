using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Diagnostics;


namespace A0105_ConvertUtf8ToDefault.Sample
{

    /// <summary>
    /// 转换处理类.
    /// </summary>
    class ConvertProcesser
    {

        /// <summary>
        /// 需要追加的 head 文本.
        /// </summary>
        private const string OLD_HEAD_STRING = "content=\"text/html;charset=utf-8\"";
        private const string NEW_HEAD_STRING = "  <meta http-equiv=\"Content-Type\" content=\"text/html;charset=GBK\" />";


        /// <summary>
        /// html 文件 utf-8 转换为 GBK 编码.
        /// </summary>
        /// <param name="fileName"></param>
        public static void ConvertUtf8ToGBK(string fileName)
        {
            Console.WriteLine("读取{0}文件信息开始！", fileName);

            StringBuilder buff = new StringBuilder();

            StreamReader sr = null;

            try
            {
                // 首先判断，文件是否已经存在
                if (!File.Exists(fileName))
                {
                    // 如果文件不存在，那么提示无法读取！
                    Console.WriteLine("文本文件{0}不存在！", fileName);
                    return;
                }

                // 以 UTF-8 编码，打开指定文件.
                sr = new StreamReader(fileName, Encoding.UTF8);

                // 用于暂存 文本文件数据的 行.
                String line = null;

                do
                {
                    // 一次读取一行数据.
                    line = sr.ReadLine();
                    if (line != null)
                    {

                        if (line.Contains(OLD_HEAD_STRING))
                        {
                            // 检测到 charset=utf-8   本行更换为 GBK
                            buff.AppendLine(NEW_HEAD_STRING);
                            continue;
                        }


                        buff.AppendLine(line);
                        
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

                return;
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

            Console.WriteLine("读取{0}文件信息结束！", fileName);







            Console.WriteLine("写入{0}文件信息开始！", fileName);

            StreamWriter sw = null;

            try
            {
                // 首先判断，文件是否已经存在
                if (File.Exists(fileName))
                {
                    // 如果文件已经存在，那么删除掉.
                    File.Delete(fileName);
                }

                // 注意第2个参数：
                // 确定是否将数据追加到文件。如果该文件存在，并且 append 为 false，则该文件被覆盖。
                // 如果该文件存在，并且 append 为 true，则数据被追加到该文件中。否则，将创建新文件。
                // 也就是说，如果第2个参数 是 false， 可以不用写前面的 判断文件存在则删除的代码.

                // 第3个参数为编码方式， 读取和写入，尽可能使用统一的编码
                sw = new StreamWriter(fileName, false, Encoding.Default);

                // 写入数据.
                sw.Write(buff.ToString());


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


            Console.WriteLine("写入{0}文件信息结束！", fileName);

        }



    }
}
