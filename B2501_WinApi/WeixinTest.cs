using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static B2501_WinApi.BasicFunc;


namespace B2501_WinApi
{
    internal class WeixinTest
    {



        public static void TestExists(string userName = "wang")
        {

            // 获取窗口句柄.
            IntPtr mainWnd = BasicFunc.FindWindow(null, userName);
            if (mainWnd == IntPtr.Zero)
            {
                Console.WriteLine($"{userName} 窗口不存在！");
                return;
            }

            Console.WriteLine($"{userName} 窗口存在！");



            //MyClipboardEvent.SetText("嘿嘿~");
            //Console.WriteLine($"向剪贴板填入数据！");

            string path = System.IO.Directory.GetCurrentDirectory();
            string fileName = $"{path}\\说明.txt";

            StringCollection files = new StringCollection();
            files.Add(fileName);
            Clipboard.SetFileDropList(files);

            Console.WriteLine($"向剪贴板复制文件！");

            Thread.Sleep(1000);


            /*
            Console.WriteLine($"尝试激活并显示 {userName} 窗口！");
            ShowWindow(mainWnd, SW_SHOWNORMAL);
            */

            /*
            // 尝试窗口最大化.
            Console.WriteLine($"尝试 {userName} 窗口最大化！");
            ShowWindow(mainWnd, SW_SHOWMAXIMIZED);
            */


            Console.WriteLine($"尝试 {userName} 窗口置于前台！");
            SwitchToThisWindow(mainWnd, false);






            RECT rect = new RECT();
            if (!GetWindowRect(mainWnd, ref rect))
            {
                Console.WriteLine("获取窗口位置失败");
                return;
            }

            int width = rect.Right - rect.Left; // 窗口的宽度
            int height = rect.Bottom - rect.Top; // 窗口的高度
            int x = rect.Left; // 窗口的左上角X坐标
            int y = rect.Top; // 窗口的左上角Y坐标
            Console.WriteLine($"窗口位置: ({x}, {y}), 宽度: {width}, 高度: {height}");


            // 尝试点击消息的区域.
            int msgBoxX = x + width / 2;
            int msgBoxY = y + height / 2;

            MyMouseEvent.AbsoluteMove(msgBoxX, msgBoxY);
            Console.WriteLine($"尝试鼠标移动到： ({msgBoxX}, {msgBoxY})");

            MyMouseEvent.AbsoluteLeftClick(msgBoxX, msgBoxY);
            Console.WriteLine($"尝试鼠标点击 ({msgBoxX}, {msgBoxY})");


            Thread.Sleep(1000);


            /*
            // 测试输入A
            MyKeyboardEvent.PressOneKey(MyKeyboardEvent.vbKeyA);
            Console.WriteLine($"尝试键盘输入a");
            */


            

            // 测试粘贴.
            MyKeyboardEvent.PressCtrlV();
            Console.WriteLine($"尝试键盘输入 Ctrl+V");
            Thread.Sleep(1234);



            // 测试发送.
            MyKeyboardEvent.PressAltS();
            Console.WriteLine($"尝试键盘输入 Alt+S");
            Thread.Sleep(500);


            /*
            // 获取窗体上所有控件的句柄
            EnumChildWindows(mainWnd, new CallBack(delegate (IntPtr hwnd, int lParam)
            {
                Console.WriteLine("窗体控件句柄:{0}", hwnd);
                return true;
            }), 0);
            */



            /*
            // 获取窗体上【发送(S)】 按钮的句柄
            IntPtr hwnd_button = BasicFunc.FindWindowEx(mainWnd, new IntPtr(0), null, "发送(S)");
            if(hwnd_button == IntPtr.Zero)
            {
                Console.WriteLine("找不到【发送(S)】 按钮！");
                return;
            }
            BasicFunc.SendMessage(hwnd_button, BasicFunc.WM_CLICK, mainWnd, "0");
            */


        }



    }
}
