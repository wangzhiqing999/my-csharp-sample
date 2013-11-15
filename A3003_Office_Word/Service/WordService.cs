using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Office.Interop.Word;


namespace A3003_Office_Word.Service
{

    public class WordService
    {

        /// <summary>
        /// 应用.
        /// </summary>
        Application wordApp = null;

        /// <summary>
        /// 文档.
        /// </summary>
        Document wordDoc = null;

        /// <summary>
        /// 启动Word应用.
        /// </summary>
        public void StartWord()
        {
            wordApp = new Application();

            wordApp.Visible = true;
        }

        /// <summary>
        /// 打开 Word 文件.
        /// </summary>
        public void OpenWordFile(String fileName)
        {
            wordDoc = wordApp.Documents.Open(fileName);
        }




        public void CloseWordFile()
        {
            wordDoc.Close();
        }


        public void CloseWordApp()
        {
            wordApp.Quit();
        }







        /// <summary>
        /// 读取所有的 表格.
        /// 
        /// 假如所有 重要的信息，都在表格内的情况下
        /// 
        /// 可以使用这种方法来处理/分析数据。
        /// </summary>
        public void ShowAllTable()
        {

            // 遍历当前 Word 文件中的 所有的表格.
            for (int tablePos = 1; tablePos <= wordDoc.Tables.Count; tablePos++)
            {
                // 取得单个表格.
                Table nowTable = wordDoc.Tables[tablePos];

                string tableMessage = string.Format("第{0}/{1}个表:\n", tablePos, wordDoc.Tables.Count);
                Console.WriteLine(tableMessage);

                // 遍历行.
                for (int rowPos = 1; rowPos <= nowTable.Rows.Count; rowPos++)
                {
                    // 遍历列
                    for (int columPos = 1; columPos <= nowTable.Columns.Count; columPos++)
                    {
                        String val = null;

                        try
                        {
                            val = nowTable.Cell(rowPos, columPos).Range.Text;
                            val = val.Replace("\r\a", "");

                            // 软回车 变硬回车.
                            val = val.Replace("\r", "\r\n");
                            Console.WriteLine("[{0}, {1}] : = {2}", rowPos, columPos, val);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("[{0}, {1}] : = 读取失败！", rowPos, columPos);
                        }
                    }


                    // 换行
                    Console.WriteLine("----------");
                }
            }
        }





        /// <summary>
        /// 读取全部的 元素信息
        /// 
        /// 采用此方式的时候， 表格中的信息， 被拆分了
        /// 
        /// 每一行文本， 被作为一个单位。
        /// </summary>
        public void ShowAllParagraph()
        {
            for (int i = 1; i <= wordDoc.Paragraphs.Count && i <= 100; i++)
            {
                Console.WriteLine("第{0}/{1}个Paragraph:\n", i, wordDoc.Paragraphs.Count);
                Paragraph paragraph = wordDoc.Paragraphs[i];
                Console.WriteLine(paragraph.Range.Text);
            }
        }




        public void ShowAllSentences()
        {
            for (int i = 1; i <= wordDoc.Sentences.Count && i <= 100; i++)
            {
                Console.WriteLine("第{0}/{1}个Sentence:\n", i, wordDoc.Sentences.Count);
                Range range = wordDoc.Sentences[i];
                Console.WriteLine(range.Text);
            }
        }




        /// <summary>
        /// 取得所有段落信息
        /// </summary>
        /// <returns></returns>
        public List<String> ReadAllSentences()
        {
            List<String> resultList = new List<string>();
            for (int i = 1; i <= wordDoc.Sentences.Count; i++)
            {
                Console.WriteLine("第{0}/{1}个Sentence", i, wordDoc.Sentences.Count);
                Range range = wordDoc.Sentences[i];
                resultList.Add(range.Text.Replace("\r\a", ""));
            }
            return resultList;
        }



        public String GetTableCellText(Table table, int row, int col)
        {
            String val = table.Cell(row, col).Range.Text;
            val = val.Replace("\r\a", "");
            return val;
        }



    }

}
