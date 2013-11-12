using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;

namespace A5010_WinPopForm.Sample
{
    //窗体状态 
    public enum FormState
    {
        Hide = 0,
        UpToShow,
        Showing,
        DownToHide
    }

    //用于单击内容区域时执行外部方法 
    public delegate void CallBackDelegate(string text);


    public partial class PopForm : Form
    {


        #region 字段

        private const int WM_NCLBUTTONDOWN = 0x00A1;    //消息:左键点击 winuser.h 
        private const int HT_CAPTION = 0x0002;  //标题栏 

        private FormState currentState = FormState.Hide;
        private Rectangle workAreaRectangle;
        private int moveInterval = 3;  //升降速度 
        private int stopInterval = 5000;  //停留时间 
        private int savedTop;
        private int currentTop = 1;


        private Bitmap backgroundBitmap = new Bitmap(240, 150);

        private Rectangle titlebarRectangle = new Rectangle(1, 1, 240, 25);
        private Rectangle titleRectangle = new Rectangle(2, 1, 70, 25);
        private Rectangle contentRectangle = new Rectangle(15, 40, 210, 70);
        private Rectangle closeRectangle = new Rectangle(215, 1, 25, 25);

        private string titleText;
        private string contentText;
        private Color titleColor = Color.FromArgb(0, 0, 0);
        private Font titleFont = new Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        private Color contentColor = Color.FromArgb(0, 0, 0);
        private Font contentFont = new Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Pixel);

        private CallBackDelegate myDelegate;

        #endregion






        #region 属性

        /// <summary> 
        /// 窗体状态 
        /// </summary> 
        public FormState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        /// <summary> 
        /// 升降速度（毫秒） 
        /// </summary> 
        public int MoveInterval
        {
            get { return moveInterval; }
            set { moveInterval = value; }
        }

        /// <summary> 
        /// 停留时长（毫秒） 
        /// </summary> 
        public int StopInterval
        {
            get
            {
                return stopInterval;
            }
            set
            {
                stopInterval = value;
                stopTimer.Interval = stopInterval;
            }
        }

        /// <summary> 
        /// 标题颜色 
        /// </summary> 
        public Color TitleColor
        {
            get { return titleColor; }
            set { titleColor = value; }
        }

        /// <summary> 
        /// 标题字体 
        /// </summary> 
        public Font TitleFont
        {
            get { return titleFont; }
            set { titleFont = value; }
        }

        /// <summary> 
        /// 内容颜色 
        /// </summary> 
        public Color ContentColor
        {
            get { return contentColor; }
            set { contentColor = value; }
        }

        /// <summary> 
        /// 内容字体 
        /// </summary> 
        public Font ContentFont
        {
            get { return contentFont; }
            set { contentFont = value; }
        }

        #endregion




        #region Windows API

        /// <summary> 
        /// //发送消息 winuser.h 中有函数原型定义 
        /// </summary> 
        /// <param name="hWnd"></param> 
        /// <param name="Msg"></param> 
        /// <param name="wParam"></param> 
        /// <param name="lParam"></param> 
        /// <returns></returns> 
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary> 
        /// 释放鼠标捕捉 winuser.h 
        /// </summary> 
        /// <returns></returns> 
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary> 
        /// 显示窗体 winuser.h (#define SW_SHOWNOACTIVATE 4) 
        /// </summary> 
        /// <param name="hWnd"></param> 
        /// <param name="nCmdShow"></param> 
        /// <returns></returns> 
        [DllImportAttribute("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        #endregion





        #region 构造函数


        public PopForm()
        {
            InitializeComponent();

            //设置窗体状态 
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;

            //给默认背景图着色 
            using (Graphics g = Graphics.FromImage(backgroundBitmap))
            {
                g.FillRectangle(Brushes.DarkGray, new Rectangle(0, 0, backgroundBitmap.Width, backgroundBitmap.Height));
            }
        }


        #endregion




        #region 实例方法

        /// <summary> 
        /// 设置背景图与透明色 
        /// </summary> 
        /// <param name="image"></param> 
        /// <param name="transparencyColor"></param> 
        public void SetBackgroundBitmap(Image image, Color transparencyColor)
        {
            backgroundBitmap = new Bitmap(image);

            // 扫描图片，返回非透明部分区域 
            if (backgroundBitmap == null)
            {
                throw new ArgumentNullException("Image", "Image cannot be null!");
            }

            using (GraphicsPath path = new GraphicsPath())
            {
                int height = backgroundBitmap.Height;
                int width = backgroundBitmap.Width;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (backgroundBitmap.GetPixel(x, y) == transparencyColor)
                        {
                            continue;
                        }

                        int x0 = x;
                        while ((x < width) && (backgroundBitmap.GetPixel(x, y) != transparencyColor))
                        {
                            x++;
                        }

                        path.AddRectangle(new Rectangle(x0, y, x - x0, 1));
                    }
                }

                this.Region = new Region(path);
            }
        }




        /// <summary> 
        /// 标志区域 
        /// </summary> 
        /// <param name="titleRectangle"></param> 
        /// <param name="titlebarRectangle"></param> 
        /// <param name="contentRectangle"></param> 
        /// <param name="CloseRectangle"></param> 
        public void MarkRegion(Rectangle titleRectangle, Rectangle titlebarRectangle, Rectangle contentRectangle, Rectangle closeRectangle)
        {
            this.titleRectangle = titleRectangle;
            this.titlebarRectangle = titlebarRectangle;
            this.contentRectangle = contentRectangle;
            this.closeRectangle = closeRectangle;
        }



        /// <summary> 
        /// 弹出窗体 
        /// </summary> 
        /// <param name="titleText">标题</param> 
        /// <param name="contentText">内容</param> 
        /// <param name="myDelegate">单击内容区域执行的方法，可以为null</param> 
        public void Pop(string titleText, string contentText, CallBackDelegate myDelegate)
        {
            this.titleText = titleText;
            this.contentText = contentText;
            this.myDelegate = myDelegate;

            this.Width = backgroundBitmap.Width;
            this.Height = 0;

            this.workAreaRectangle = Screen.GetWorkingArea(workAreaRectangle);
            this.Top = workAreaRectangle.Height;
            this.SetBounds(workAreaRectangle.Width - this.Width, workAreaRectangle.Height - currentTop, this.Width, this.Height);

            this.currentState = FormState.UpToShow;
            this.moveTimer.Enabled = true;

            ShowWindow(this.Handle, 4); //#define SW_SHOWNOACTIVATE 4 
        }




        private void moveTimer_Tick(object sender, EventArgs e)
        {
            if (currentState == FormState.UpToShow)
            {
                this.SetBounds(workAreaRectangle.Width - this.Width, workAreaRectangle.Height - currentTop, this.Width, currentTop);
                currentTop = currentTop + moveInterval;
                if (this.Top <= workAreaRectangle.Height - backgroundBitmap.Height)
                {
                    moveTimer.Enabled = false;
                    currentState = FormState.Showing;
                    stopTimer.Enabled = true; //显示停留计时 
                    currentTop = 1;
                }
            }
            else if (currentState == FormState.DownToHide)
            {
                this.SetBounds(workAreaRectangle.Width - this.Width, savedTop + currentTop, this.Width, backgroundBitmap.Height - currentTop);
                currentTop = currentTop + moveInterval;
                if (this.Top >= workAreaRectangle.Height)
                {
                    moveTimer.Enabled = false;
                    this.Hide();
                    currentState = FormState.Hide;
                    currentTop = 1;
                }
            }
        }




        private void stopTimer_Tick(object sender, EventArgs e)
        {
            stopTimer.Enabled = false;
            currentTop = 1;
            savedTop = this.Top;
            currentState = FormState.DownToHide;
            moveTimer.Enabled = true;
        }




        private void PopForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (titlebarRectangle.Contains(e.Location)) //单击标题栏时拖动 
                {
                    ReleaseCapture();   //释放鼠标捕捉 
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);   //发送左键点击的消息至该窗体(标题栏) 
                }
                if (closeRectangle.Contains(e.Location))    //单击Close按钮关闭 
                {
                    this.Hide();
                    currentTop = 1;
                }
                if (contentRectangle.Contains(e.Location))  //单击内容区域 
                {
                    if (myDelegate != null)
                    {
                        myDelegate.Invoke(this.contentText);
                    }
                }
            }
        }




        private void PopForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (contentRectangle.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }



        /// <summary> 
        /// 画文本 
        /// </summary> 
        /// <param name="g"></param> 
        protected void DrawText(Graphics g)
        {
            if (titleText != null && titleText.Length != 0)
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                format.FormatFlags = StringFormatFlags.NoWrap;
                format.Trimming = StringTrimming.EllipsisCharacter;
                g.DrawString(titleText, titleFont, new SolidBrush(titleColor), titleRectangle, format);
            }

            if (contentText != null && contentText.Length != 0)
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
                format.Trimming = StringTrimming.Word;
                g.DrawString(contentText, contentFont, new SolidBrush(contentColor), contentRectangle, format);
            }
        }

        #endregion




        #region 方法覆盖

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;

            Bitmap tempBitmap = new Bitmap(backgroundBitmap.Width, backgroundBitmap.Height); ;
            using (Graphics tempGraphics = Graphics.FromImage(tempBitmap))
            {
                if (backgroundBitmap != null)
                {
                    tempGraphics.DrawImage(backgroundBitmap, 0, 0, backgroundBitmap.Width, backgroundBitmap.Height);
                }
                DrawText(tempGraphics);
            }

            g.DrawImage(tempBitmap, 0, 0);
        }

        #endregion
    }


}
