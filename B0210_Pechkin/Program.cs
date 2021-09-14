using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pechkin;
using System.Drawing.Printing;

namespace B0210_Pechkin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test1();

            Test2();


            Console.WriteLine("Finish!");
            Console.ReadLine();
        }





        /// <summary>
        /// 最基础的 Hello World 测试.
        /// </summary>
        static void Test1()
        {
            Console.WriteLine("----- Test1 -----");

            byte[] pdfBuf = new SimplePechkin(new GlobalConfig()).Convert("<html><body><h1>Hello world!</h1></body></html>");

            File.WriteAllBytes("test1.pdf", pdfBuf);
        }




        static void Test2()
        {
            Console.WriteLine("----- Test2 -----");

            // create global configuration object
            GlobalConfig gc = new GlobalConfig();

            //// set it up using fluent notation
            //gc.SetMargins(new Margins(300, 100, 150, 100))
            //  .SetDocumentTitle("Test document")
            //  .SetPaperSize(PaperKind.Letter);
            //... etc

            // create converter
            IPechkin pechkin = new SimplePechkin(gc);

            // create document configuration object
            ObjectConfig oc = new ObjectConfig();

            // and set it up using fluent notation too
            oc.SetCreateExternalLinks(false)
              // .SetFallbackEncoding(Encoding.ASCII)
              // .SetLoadImages(false)
              .SetPageUri("https://www.baidu.com/");
            //... etc


            // convert document
            byte[] pdfBuf = pechkin.Convert(oc);


            File.WriteAllBytes("test2.pdf", pdfBuf);
        }



    }
}
