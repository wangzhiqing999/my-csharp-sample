using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0900_DllImport_StrCmpLogicalW.Sample;

namespace A0900_DllImport_StrCmpLogicalW
{
    class Program
    {
        static void Main(string[] args)
        {
            // 排序类.
            StringLogicalComparer sl = new StringLogicalComparer();
            
            // 数据列表.
            List<string> al = new List<string>();
            al.Add("1f");
            al.Add("1");
            al.Add("1f1a");
            al.Add("1f1");
            al.Add("1fa1");
            al.Add("1af2");
            al.Add("1ab3");
            al.Add("1ab23");
            al.Add("1b1");
            al.Add("11w");
            al.Add("2a");
            al.Add("12");
            al.Add("22");
            al.Add("21");

            // 按特定方式排序.
            al.Sort(sl);

            // 输出排序结果.
            foreach (string a in al)
            {
                Console.WriteLine(a);
            }

            Console.ReadLine();

        }
    }
}
