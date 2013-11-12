using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


using System.Drawing.Printing;



namespace A1010_Print
{


    public partial class FormTestPrint : Form
    {
        public FormTestPrint()
        {
            InitializeComponent();

            // 初始化.
            Init();
        }



        #region 打印功能所需要的 基本的变量定义.


        // 下面 4个 可以在设计画面， 直接将控件拖动到 画面中
        // 这里是为了 复制粘贴方便，而直接写代码来设置.


        /// <summary>
        /// 打印文档.
        /// </summary>
        private System.Drawing.Printing.PrintDocument printDocument1;

        /// <summary>
        /// 页面设置对话框.
        /// </summary>
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;

        /// <summary>
        /// 打印对话框.
        /// </summary>
        private System.Windows.Forms.PrintDialog printDialog1;

        /// <summary>
        /// 打印预览对话框.
        /// </summary>
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;


        #endregion



        #region 翻页过程所需要的变量.

        /// <summary>
        /// 每页打印 5 行.
        /// </summary>
        private const int LINES_PRE_PAGE = 5;


        /// <summary>
        /// 行读取器.
        /// </summary>
        private StringReader reader;


        /// <summary>
        /// 定义默认的 打印字体.
        /// </summary>
        private Font defaultFont = new Font("宋体", 12);

        /// <summary>
        /// 定义默认的 单色 黑色 画笔.
        /// </summary>
        private Brush defaultBrush = new SolidBrush(Color.Black); 


        #endregion




        /// <summary>
        /// 打印变量的基础定义.
        /// </summary>
        private void Init()
        {
            // 初始化 打印文档.
            printDocument1 = new PrintDocument();
            // 定义 打印文档的事件.
            printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.BeginPrint);
            printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.EndPrint);
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintPage);

            // 定义打印文档的附加信息.
            printDocument1.DocumentName = "打印测试";


            // 初始化 页面设置对话框.
            pageSetupDialog1 = new PageSetupDialog();
            pageSetupDialog1.Document = printDocument1;

            // 初始化 打印预览对话框.
            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;

            // 初始化 打印对话框.
            printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;

        }




        #region 打印文档所需要实现的方法.


        /// <summary>
        /// 开始打印.
        /// 这里写 打印前的初始化的处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginPrint(object sender, PrintEventArgs e)
        {
            // 初始化需要打印的文本信息.
            reader = new StringReader(this.textBox1.Text);
        }


        /// <summary>
        /// 打印的方法.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="av"></param>
        public void PrintPage(Object Sender, PrintPageEventArgs e)
        {
            // 读取到的行信息.
            string line = null;

            for (int i = 0; i < LINES_PRE_PAGE; i++)
            {
                // 读取一行.
                line = reader.ReadLine();

                if (line == null)
                {
                    // 读取结束了.
                    break;
                }

                // 输出信息.
                e.Graphics.DrawString(line, defaultFont, defaultBrush, 40, 40 + i * 40);
            }

            if (line == null)
            {
                // 读取结束了.
                e.HasMorePages = false;
            }
            else
            {
                // 读取未结束.
                e.HasMorePages = true;
            }
        }


        /// <summary>
        /// 打印处理结束.
        /// 这里写 打印后的释放资源的处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndPrint(object sender, PrintEventArgs e)
        {
            reader.Close();
            reader = null;
        }


        #endregion



        /// <summary>
        /// 页面设置.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        /// <summary>
        /// 打印预览.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog(this);
        }


        /// <summary>
        /// 打印.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                printDocument1.Print();
            }
        }





    }


}
