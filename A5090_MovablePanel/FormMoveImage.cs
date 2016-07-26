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
    public partial class FormMoveImage : Form
    {
        public FormMoveImage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 图片列表.
        /// </summary>
        private PictureBox[] picArray = new PictureBox[5];

        /// <summary>
        /// 是否进入切换模式.
        /// </summary>
        private bool switchMode = false;

        /// <summary>
        /// 开始的 X 坐标.
        /// </summary>
        private int startX = 0;


        /// <summary>
        /// 移动超过了 50 个像素， 认为是要翻页.
        /// 否则就恢复.
        /// </summary>
        private const int minSwitchSize = 50;


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTestImageSwitch_Load(object sender, EventArgs e)
        {
            picArray[0] = new PictureBox()
            {
                Image = new Bitmap("full_thumbnail_chara_27_horo.png")
            };
            picArray[1] = new PictureBox()
            {
                Image = new Bitmap("full_thumbnail_chara_49_horo.png")
            };
            picArray[2] = new PictureBox()
            {
                Image = new Bitmap("full_thumbnail_chara_56_horo.png")
            };
            picArray[3] = new PictureBox()
            {
                Image = new Bitmap("full_thumbnail_chara_96_horo.png")
            };
            picArray[4] = new PictureBox()
            {
                Image = new Bitmap("full_thumbnail_chara_100_horo.png")
            };

            // 初始化多个图片.
            for (int i = 0; i < picArray.Length; i++)
            {

                this.picArray[i].Size = new System.Drawing.Size(256, 256);
                this.picArray[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.picArray[i].TabStop = false;
                this.picArray[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
                this.picArray[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
                this.picArray[i].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);


                this.panel1.Controls.Add(picArray[i]);

                // 顶部对齐.
                picArray[i].Top = 0;
                // 左边位置.
                picArray[i].Left = i * picArray[0].Width;

                // 索引.
                picArray[i].Tag = i;
            }

            txtDebugInfo.AppendText("初始化完毕！\n");
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 进入 拖动模式.
            switchMode = true;

            // 记录开始移动的坐标.
            this.startX = e.X;

            txtDebugInfo.AppendText(
                String.Format("鼠标按下！ 位置：({0}, {1}) \n", e.X,  e.Y)
                );
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // 离开 拖动模式.
            switchMode = false;

            // 取得当前 的图片对象.
            PictureBox pic = sender as PictureBox;

            // 当前图片索引.
            int currentPicIndex = (int)pic.Tag;

            // 移动的坐标.
            int movePlaceSize = pic.Left;

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
                    if (currentPicIndex < picArray.Length - 1)
                    {
                        currentPicIndex++;
                    }
                }
            }

            // 设置坐标.
            for (int i = 0; i < picArray.Length; i++)
            {
                picArray[i].Left = (i - currentPicIndex) * picArray[0].Width;
            }


            txtDebugInfo.AppendText(
                String.Format("鼠标放开！ 位置：({0}, {1}) \n", e.X, e.Y)
                );

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
            for (int i = 0; i < picArray.Length; i++)
            {
                // 左边位置.
                picArray[i].Left = picArray[i].Left + movePlaceSize;
            }

            //txtDebugInfo.AppendText(
            //    String.Format("鼠标移动！ 位置：({0}, {1}) \n", e.X, e.Y)
            //    );
        }
    }
}
