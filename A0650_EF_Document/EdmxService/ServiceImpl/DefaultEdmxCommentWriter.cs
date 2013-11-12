using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using EdmxService.Model;
using EdmxService.Service;

namespace EdmxService.ServiceImpl
{
    public class DefaultEdmxCommentWriter : IEdmxCommentWriter
    {


        public void EdmxCommentWriter(string edmxFileName, List<TableOrViewInfo> tableInfoList)
        {

            if (!File.Exists(edmxFileName))
            {
                Console.WriteLine("源文件不存在");
                return;
            }



            // 首先，读取文件.
            List<string> edmxLineList = ReadEdmxLineList(edmxFileName);

            // 然后，备份文件.
            File.Copy(edmxFileName, edmxFileName + "_" + DateTime.Today.ToString("yyyyMMdd") + ".bak");

            // 然后， 更新文件.
            WriteEdmx(edmxFileName, edmxLineList, tableInfoList);
        }



        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="edmxFileName"></param>
        /// <returns></returns>
        private List<string> ReadEdmxLineList(string edmxFileName)
        {
            //  预期结果.
            List<string> resultList = new List<string>();


            StreamReader sr = null;
            try
            {
                sr = new StreamReader(edmxFileName, Encoding.UTF8);

                // 用于暂存 文本文件数据的 行.
                String line = null;


                do
                {
                    // 一次读取一行数据.
                    line = sr.ReadLine();

                    if (line != null)
                    {
                        resultList.Add(line);
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

            return resultList;
        }







        /// <summary>
        /// 开始标记.
        /// </summary>
        private const string StartMark = "<edmx:ConceptualModels>";


        /// <summary>
        /// 结束标记.
        /// </summary>
        private const string FinishMark = "</edmx:ConceptualModels>";

        /// <summary>
        /// 分割用的 字符数组.
        /// </summary>
        private static readonly char[] DivCharArray = new char[] { ' '};


        /// <summary>
        /// 写入文件.
        /// </summary>
        /// <param name="edmxLineList"></param>
        /// <param name="tableInfoList"></param>
        private void WriteEdmx(string edmxFileName, List<string> edmxLineList, List<TableOrViewInfo> tableInfoList)
        {

            StreamWriter sw = null;

            try
            {
                // 首先判断，文件是否已经存在
                if (File.Exists(edmxFileName))
                {
                    // 如果文件已经存在，那么删除掉.
                    File.Delete(edmxFileName);
                }

                // 如果该文件存在，并且 append 为 false，则该文件被覆盖。
                sw = new StreamWriter(edmxFileName, false, Encoding.UTF8);



                // 处理标志： 
                // 0 ：未进入处理阶段
                // 1 : 进入到处理阶段.
                // 2 : 离开处理阶段.
                int processFlag = 0;



                // 表信息.
                TableOrViewInfo tabInfo = null;


                for (int i = 0; i < edmxLineList.Count; i++)
                {
                    

                    if (edmxLineList[i].Contains(StartMark))
                    {
                        // 进入到处理阶段.
                        processFlag = 1;
                    }
                    else if (edmxLineList[i].Contains(StartMark))
                    {
                        // 离开处理阶段.
                        processFlag = 2;
                    }



                    if (processFlag == 0 || processFlag == 2)
                    {
                        // 原始方式写入.
                        sw.WriteLine(edmxLineList[i]);
                    }
                    else if (processFlag == 1)
                    {
                        // 仅仅在 处理阶段 以内，才做处理.

                        if (edmxLineList[i].Contains("<EntityType Name="))
                        {
                            // 原始方式写入.
                            sw.WriteLine(edmxLineList[i]);


                            // 可能需要做 处理了.
                            string tableName = edmxLineList[i].Replace("<EntityType Name=", "");
                            tableName = tableName.Replace('>', ' ');
                            tableName = tableName.Replace('\"', ' ');
                            tableName = tableName.Trim();

                            // 检索表信息.
                            tabInfo = tableInfoList.FirstOrDefault(p => p.Name == tableName);

                            if (tabInfo != null)
                            {
                                // 追加 表的 备注信息.
                                sw.WriteLine("          <Documentation>");
                                sw.WriteLine("            <Summary>{0}</Summary>", tabInfo.Comment);
                                sw.WriteLine("          </Documentation>");
                            }
                        }
                        else if (edmxLineList[i].Contains("<Property "))
                        {
                            string line = edmxLineList[i];
                            line = line.Replace("/", "");

                            //  不关闭方式写入
                            sw.WriteLine(line);


                            line = line.Replace("<", "");
                            line = line.Replace(">", "");
                            line = line.Trim();

                            // 可能需要做 处理了.
                            string[] tmpArray = line.Split(DivCharArray);


                            string columnName = tmpArray.FirstOrDefault(p => p.Contains("Name="));
                            columnName = columnName.Replace("\"", "");
                            columnName = columnName.Substring(5);

                            if (tabInfo != null && tabInfo.ColumnList != null)
                            {
                                ColumnInfo colInfo = tabInfo.ColumnList.FirstOrDefault(p => p.Name == columnName);

                                if (colInfo != null)
                                {
                                    // 追加 列的 备注信息.
                                    sw.WriteLine("            <Documentation>");
                                    sw.WriteLine("            <Summary>{0}</Summary>", colInfo.Comment);
                                    sw.WriteLine("            </Documentation>");
                                }
                            }

                            //  关闭写入
                            sw.WriteLine("          </Property>");
                        }
                        else
                        {
                            // 其他情况

                            // 原始方式写入.
                            sw.WriteLine(edmxLineList[i]);
                        }

                    }

                }




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

        }



    }

}
