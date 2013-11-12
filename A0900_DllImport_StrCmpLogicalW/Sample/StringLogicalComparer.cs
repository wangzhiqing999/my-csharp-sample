using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.InteropServices;


namespace A0900_DllImport_StrCmpLogicalW.Sample
{


    /// <summary>
    /// 字符串比较类.
    /// </summary>
    public class StringLogicalComparer : System.Collections.Generic.IComparer<string>
    {

        // 1、DllImport只能放置在方法声明上。
        // 2、DllImport具有单个定位参数：指定包含被导入方法的 dll 名称的 dllName 参数。
        // 3、DllImport具有五个命名参数：
　      //   a、CallingConvention 参数指示入口点的调用约定。
        //        如果未指定 CallingConvention，则使用默认值 CallingConvention.Winapi。
        // 　b、CharSet 参数指示用在入口点中的字符集。
        //        如果未指定 CharSet，则使用默认值 CharSet.Auto。
        // 　c、EntryPoint 参数给出 dll 中入口点的名称。
        //        如果未指定 EntryPoint，则使用方法本身的名称。
        // 　d、ExactSpelling 参数指示 EntryPoint 是否必须与指示的入口点的拼写完全匹配。
        //        如果未指定 ExactSpelling，则使用默认值 false。
        // 　e、PreserveSig 参数指示方法的签名应当被保留还是被转换。当签名被转换时，它被转换为一个具有 HRESULT 返回值和该返回值的一个名为 retval 的附加输出参数的签名。
        //        如果未指定 PreserveSig，则使用默认值 true。
        // 　f、SetLastError 参数指示方法是否保留 Win32"上一错误"。
        //        如果未指定 SetLastError，则使用默认值 false。
        // 4、它是一次性属性类。
        // 5、此外，用 DllImport 属性修饰的方法必须具有 extern 修饰符。


        /// <summary>
        /// StrCmpLogicalW 
        /// 资源管理器风格的排序
        /// 此算法在排序的时候，将 字符串中的 数字字符， 按照 数值 大小的方式进行排序
        /// 例如  2a  要排列在  11a 前面.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern int StrCmpLogicalW(string x, string y);




        public int Compare(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }


}
