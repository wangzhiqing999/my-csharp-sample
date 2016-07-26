using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Runtime.InteropServices; 



namespace A6000_ImportExe_Main
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.cboFormBorderStyle.SelectedIndex = 0;
        }






        #region 普通的外部 Exe.


        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// 外部 Exe 的进程.
        /// </summary>
        System.Diagnostics.Process normalP;


        /// <summary>
        /// 加载普通 Exe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadExe_Click(object sender, EventArgs e)
        {
            // 这里启动外部的  记事本 程序.
            normalP = System.Diagnostics.Process.Start("notepad");

            normalP.WaitForInputIdle();

            // 程序启动后， 放在 pnlExe 的 容器里面。
            SetParent(normalP.MainWindowHandle, this.pnlExe.Handle);

            ShowWindowAsync(normalP.MainWindowHandle, 3); 
           
        }

        /// <summary>
        /// 窗口关闭时，判断，是否需要关闭已打开的外部程序.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (normalP != null)
            {
                try
                {
                    normalP.Kill();
                    normalP.Close();
                }
                catch (Exception)
                {
                    // 忽略关闭异常.
                }
            }
        }



        #endregion 普通的外部 Exe.









        #region .NET 的外部 Exe。

        // 需要在当前项目， 引用 目标 Exe.


        /// <summary>
        /// 目标 exe 的 主窗口.
        /// </summary>
        private A6010_ImportExe_Sub.FormMain frmEmbed = new A6010_ImportExe_Sub.FormMain();


        /// <summary>
        /// 加载 .NET Exe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadDotNetExe_Click(object sender, EventArgs e)
        {

            if (frmEmbed != null)
            {
                // 无边框
                frmEmbed.FormBorderStyle = (FormBorderStyle)Enum.Parse(typeof(FormBorderStyle), this.cboFormBorderStyle.Text, true);
                // 不是最顶层窗体
                frmEmbed.TopLevel = false;

                // 添加到 Panel中
                this.pnlDotNetExe.Controls.Add(frmEmbed);

                // 显示
                frmEmbed.Show();     
            }

        }


        #endregion .NET 的外部 Exe

        

    }
}
