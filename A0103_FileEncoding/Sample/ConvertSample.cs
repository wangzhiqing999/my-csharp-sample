using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Diagnostics;



namespace A0103_FileEncoding.Sample
{
    public class ConvertSample
    {




        /// <summary>
        /// 测试向从文本文件中读取数据，并显示到终端上.
        /// </summary>
        public string TestRead(string fileName, Encoding encodeing)
        {
            Console.WriteLine("读取文本文件信息开始！");


            StringBuilder buff = new StringBuilder();

            StreamReader sr = null;

            try
            {
                // 首先判断，文件是否已经存在
                if (!File.Exists(fileName))
                {
                    // 如果文件不存在，那么提示无法读取！
                    Console.WriteLine("文本文件{0}不存在！", fileName);
                    return null ;
                }


                // 以指定编码，打开指定文件.
                sr = new StreamReader(fileName, encodeing);

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


            return buff.ToString();
        }



        /// <summary>
        /// 测试向创建文本文件，并向其中写入文本信息.
        /// </summary>
        public void TestWrite(string fileName, Encoding encodeing, string fileData)
        {
            Console.WriteLine("写入文本文件信息开始！");

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
                sw = new StreamWriter(fileName, false, encodeing);

                // 写入数据.
                sw.Write(fileData);


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
        /// 文件格式转换.
        /// </summary>
        /// <param name="sourceFilename"></param>
        /// <param name="destinationFilename"></param>
        /// <param name="sourceEncodeing"></param>
        /// <param name="destinationEncodeing"></param>
        public void FileEncodingConvert(
            string sourceFilename,
            string destinationFilename,
            Encoding sourceEncodeing,
            Encoding destinationEncodeing)
        {
            // Check 文件名.
            Debug.Assert(sourceFilename != destinationFilename, "源文件不能与目标文件一样！");


            // 读取.
            StreamReader sr = null;

            // 写入.
            StreamWriter sw = null;


            try
            {
                // 首先判断，文件是否已经存在
                if (!File.Exists(sourceFilename))
                {
                    // 如果文件不存在，那么提示无法读取！
                    Console.WriteLine("文本文件{0}不存在！", sourceFilename);
                    return;
                }


                // 以指定编码，打开 源文件.
                sr = new StreamReader(sourceFilename, sourceEncodeing);

                // 以指定编码，打开 目标文件. 
                sw = new StreamWriter(destinationFilename, false, destinationEncodeing);



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
                        // Console.WriteLine("{0} : {1}", lineNo, line);

                        // 写入数据.
                        sw.WriteLine(line);
                    }

                } while (line != null);

                // 读取完毕，关闭.
                sr.Close();

                // 写入完毕，关闭文件.
                sw.Close();


                sr = null;
                sw = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在文件转换处理的过程中，发生了异常！");
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
        }


    }
}
