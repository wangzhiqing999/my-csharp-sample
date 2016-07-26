using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A1070_Image_Process.Sample;


namespace A1070_Image_Process
{
    class Program
    {
        static void Main(string[] args)
        {

            // 两张图片合并成一张.
            TwoImageInOne.DoImageProc();


            // 变更图片尺寸.
            ImageResize.DoImageProc();



            Console.WriteLine("Finish!");
            Console.ReadKey();

        }
    }
}
