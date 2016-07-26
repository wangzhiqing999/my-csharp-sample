using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5090_MovablePanel
{
    public partial class FormMovePanel : Form
    {
        public FormMovePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Panel 列表.
        /// </summary>
        private Panel[] panelArray = new Panel[5];

        /// <summary>
        /// 是否进入切换模式.
        /// </summary>
        private bool switchMode = false;

        /// <summary>
        /// 开始的 X 坐标.
        /// </summary>
        private int startX = 0;


        /// <summary>
        /// 移动超过了 100 个像素， 认为是要翻页.
        /// 否则就恢复.
        /// </summary>
        private const int minSwitchSize = 100;


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMovePanel_Load(object sender, EventArgs e)
        {
            panelArray[0] = this.panel1;
            panelArray[1] = this.panel2;
            panelArray[2] = this.panel3;
            panelArray[3] = this.panel4;
            panelArray[4] = this.panel5;


            // 初始化多个 Panel.
            for (int i = 0; i < panelArray.Length; i++)
            {

                this.panelArray[i].Size = new System.Drawing.Size(this.pnlMain.Width,  this.pnlMain.Height);
                this.panelArray[i].TabStop = false;
                this.panelArray[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
                this.panelArray[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
                this.panelArray[i].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);



                // 顶部对齐.
                panelArray[i].Top = 0;
                // 左边位置.
                panelArray[i].Left = i * panelArray[0].Width;

                // 索引.
                panelArray[i].Tag = i;
            }
        }





        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 进入 拖动模式.
            switchMode = true;

            // 记录开始移动的坐标.
            this.startX = e.X;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // 离开 拖动模式.
            switchMode = false;

            // 取得当前 的图片对象.
            Panel pnl = sender as Panel;

            // 当前图片索引.
            int currentPicIndex = (int)pnl.Tag;

            // 移动的坐标.
            int movePlaceSize = pnl.Left;

            // 移动距离大于 翻页大小.
            if (Math.Abs(movePlaceSize) > minSwitchSize)
            {
                if (movePlaceSize > 0)
                {
                    // 从左向右拉.
                    if (currentPicIndex > 0)
                    {
                        currentPicIndex--;
                    }
                }
                else
                {
                    // 从右向左拉.
                    if (currentPicIndex < panelArray.Length - 1)
                    {
                        currentPicIndex++;
                    }
                }
            }

            // 设置坐标.
            for (int i = 0; i < panelArray.Length; i++)
            {
                panelArray[i].Left = (i - currentPicIndex) * panelArray[0].Width;
            }
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!switchMode)
            {
                // 非切换模式， 忽略.
                return;
            }

            // 移动的坐标.
            int movePlaceSize = e.X - startX;

            // 移动图片.
            for (int i = 0; i < panelArray.Length; i++)
            {
                // 左边位置.
                panelArray[i].Left = panelArray[i].Left + movePlaceSize;
            }
        }

    

    }
}
