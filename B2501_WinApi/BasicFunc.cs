using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace B2501_WinApi
{
    internal class BasicFunc
    {


        public const int WM_SETTEXT = 0x000C;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_CLICK = 0x00F5;

        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_CLOSE = 0x0010;
        public const int WM_GETTEXTLENGTH = 0x000E;


        /// <summary>
        /// Windows API函数，查找窗口句柄，在查找时不区分大小写。
        /// 关于句柄以及FindWindow函数的参数，
        /// 用法等在https://www.cnblogs.com/gyc19920704/p/5430964.html 有说明。
        /// </summary>
        /// <param name="lpClassName">spy++工具中的 类 没有则为null</param>
        /// <param name="lpWindowName">spy++工具中的 标题 没有则为null</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);




        //查找窗口内控件句柄
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);










        /// <summary>
        /// 设置指定窗口的显示状态。
        /// <br/>
        /// https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showwindow
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// 设置指定窗口的显示状态。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll ")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);




        /// <summary>
        /// 激活并显示窗口。 
        /// 如果窗口最小化、最大化或排列，系统会将其还原到其原始大小和位置。 
        /// 应用程序应在首次显示窗口时指定此标志。
        /// </summary>
        public const int SW_SHOWNORMAL = 1;

        /// <summary>
        /// 激活窗口并显示最大化的窗口。
        /// </summary>
        public const int SW_SHOWMAXIMIZED = 3;

        /// <summary>
        /// 激活窗口并以当前大小和位置显示窗口。
        /// </summary>
        public const int SW_SHOW = 5;

        /// <summary>
        /// 最小化指定的窗口，并按 Z 顺序激活下一个顶级窗口。
        /// </summary>
        public const int SW_MINIMIZE = 6;






        /// <summary>
        /// 将焦点切换到指定窗口，并将其置于前台。
        /// <br/>
        /// https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-switchtothiswindow
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        [DllImport("user32.dll ", SetLastError = true)]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);









        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; // 最左坐标
            public int Top; // 最上坐标
            public int Right; // 最右坐标
            public int Bottom; // 最下坐标
        }



        /// <summary>
        /// 检索指定窗口的边框的尺寸。 尺寸以相对于屏幕左上角的屏幕坐标提供。
        /// <br/>
        /// https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowrect
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);














        //发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, StringBuilder lParam);




        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage1(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);



        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);



        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);




        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder sb, int length);






        public delegate bool CallBack(IntPtr hwnd, int lParam);


    }
}
