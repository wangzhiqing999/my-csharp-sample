using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A3003_Office_Word.Service;


namespace A3003_Office_Word.Sample
{

    class Test
    {

        public void TestReadTable(string fileName)
        {
            Console.WriteLine("测试读取 Word 文件中的表格信息！");

            string fullPathFileName =
                System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + @"WordFiles\" + fileName;

            WordService wordService = new WordService();
            wordService.StartWord();
            wordService.OpenWordFile(fullPathFileName);



            wordService.ShowAllTable();


            wordService.CloseWordFile();
            wordService.CloseWordApp();
        }
    }

}
