using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace B2501_WinApi
{
    public class MyClipboardEvent
    {


        /// <summary>
        /// 打开剪贴板以供检查，并阻止其他应用程序修改剪贴板内容。
        /// <br/>
        /// https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-openclipboard
        /// </summary>
        /// <param name="hWndNewOwner"></param>
        /// <returns></returns>
        [DllImport("User32")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);



        /// <summary>
        /// 关闭剪贴板。
        /// <br/>
        /// https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-closeclipboard
        /// </summary>
        /// <returns></returns>
        [DllImport("User32")]
        internal static extern bool CloseClipboard();


        /// <summary>
        /// 清空剪贴板并释放剪贴板中数据的句柄。 然后， 函数将剪贴板的所有权分配给当前已打开剪贴板的窗口。
        /// </summary>
        /// <returns></returns>
        [DllImport("User32")]
        internal static extern bool EmptyClipboard();



        /// <summary>
        /// 确定剪贴板是否包含指定格式的数据。
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        [DllImport("User32")]
        internal static extern bool IsClipboardFormatAvailable(int format);


        /// <summary>
        /// 从剪贴板中检索指定格式的数据。 剪贴板之前必须已打开。
        /// </summary>
        /// <param name="uFormat"></param>
        /// <returns></returns>
        [DllImport("User32")]
        internal static extern IntPtr GetClipboardData(int uFormat);


        /// <summary>
        /// 将数据以指定的剪贴板格式放置在剪贴板上。 
        /// 窗口必须是当前剪贴板所有者，并且应用程序必须已调用 OpenClipboard 函数。
        /// (响应WM_RENDERFORMAT消息时，剪贴板所有者不得在调用 SetClipboardData.)
        /// <br/>
        /// 格式参考
        /// https://learn.microsoft.com/zh-cn/windows/win32/dataxchg/standard-clipboard-formats
        /// </summary>
        /// <param name="uFormat"></param>
        /// <param name="hMem"></param>
        /// <returns></returns>
        [DllImport("User32", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetClipboardData(int uFormat, IntPtr hMem);






        public static void SetText(string text)
        {
            if (OpenClipboard(IntPtr.Zero))
            {
                EmptyClipboard();

                // 这里的 13 是
                // CF_UNICODETEXT
                // Unicode 文本格式。 每行以回车符 / 换行符(CR - LF) 组合结束。 null 字符表示数据结束。
                SetClipboardData(13, Marshal.StringToHGlobalUni(text));

                CloseClipboard();
            }
            
        }


        public static string GetText(int format)
        {
            string value = string.Empty;
            OpenClipboard(IntPtr.Zero);
            if (IsClipboardFormatAvailable(format))
            {
                IntPtr ptr = GetClipboardData(format);
                if (ptr != IntPtr.Zero)
                {
                    value = Marshal.PtrToStringUni(ptr);
                }
            }
            CloseClipboard();
            return value;
        }





    }
}
