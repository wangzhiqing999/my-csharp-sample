using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;


namespace B2501_WinApi
{


    /// <summary>
    /// 鼠标事件.
    /// </summary>
    public class MyMouseEvent
    {

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, int extraInfo);

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }


        /// <summary>
        /// 绝对地址移动.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AbsoluteMove(int x, int y)
        {
            // 移动到需要点击的位置
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, 
                x * 65535 / 1600, y * 65535 / 900, 0, 0);
        }


        /// <summary>
        /// 绝对地址 鼠标左键点击.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AbsoluteLeftClick(int x, int y)
        {
            // 左键按下.
            mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.Absolute, 
                x * 65535 / 1600, y * 65535 / 900, 0, 0);
            // 左键抬起.
            mouse_event(MouseEventFlag.LeftUp | MouseEventFlag.Absolute, 
                x * 65535 / 1600, y * 65535 / 900, 0, 0);            
        }


        /// <summary>
        /// 绝对地址 鼠标右键点击.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AbsoluteRightClick(int x, int y)
        {
            // 右键按下.
            mouse_event(MouseEventFlag.RightDown | MouseEventFlag.Absolute,
                x * 65535 / 1600, y * 65535 / 900, 0, 0);
            // 右键抬起.
            mouse_event(MouseEventFlag.RightUp | MouseEventFlag.Absolute,
                x * 65535 / 1600, y * 65535 / 900, 0, 0);
        }

    }
}
