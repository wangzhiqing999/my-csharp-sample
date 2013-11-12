using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using G0081_ImageSwitch.Service;


namespace G0081_ImageSwitch
{
    public partial class UcImageSwitch : UserControl
    {
        public UcImageSwitch()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 背景图片1.
        /// </summary>
        public Bitmap Pic1 { set; get; }


        /// <summary>
        /// 背景图片2.
        /// </summary>
        public Bitmap Pic2 { set; get; }


        /// <summary>
        /// 画面变化幅度.（每次图片切换的像素点）
        /// </summary>
        public int Step = 3;


        /// <summary>
        /// 图片切换模式.
        /// </summary>
        public enum SwitchMode
        {
            /// <summary>
            /// 左右旋转.
            /// </summary>
            LeftRightRotation = 0,

            /// <summary>
            /// 上下旋转
            /// </summary>
            TopDownRotation = 1,


            /// <summary>
            /// 左右移动.
            /// </summary>
            LeftRightMove = 2,


            /// <summary>
            /// 上下移动.
            /// </summary>
            UpDownMove = 3,

        };


        /// <summary>
        /// 图片切换模式
        /// </summary>
        public SwitchMode PicSwitchMode { set; get; }




        /// <summary>
        /// 图片切换处理器.
        /// </summary>
        private AbstractImageSwitch imageSwitch = new RotationLeftToRightImageSwitch();




        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcImaheSwitch_Load(object sender, EventArgs e)
        {
            switch (this.PicSwitchMode)
            {
                case SwitchMode.LeftRightRotation:
                    // 左右旋转.
                    imageSwitch = new RotationLeftToRightImageSwitch();
                    break;

                case SwitchMode.TopDownRotation:
                    // 上下旋转.
                    imageSwitch = new RotationUpToDownImageSwitch();
                    break;

                case SwitchMode.LeftRightMove :
                    // 左右移动.
                    imageSwitch = new MoveLeftToRightImageSwitch();
                    break;

                case SwitchMode.UpDownMove :
                    // 上下移动.
                    imageSwitch = new MoveUpToDownImageSwitch();
                    break;
            }
        }


        /// <summary>
        /// 图片尺寸大小变更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcImageSwitch_SizeChanged(object sender, EventArgs e)
        {
            OnResize();
        }

        /// <summary>
        /// 显示图像.
        /// </summary>
        public void ShowPic()
        {
            this.picMain.Image = Pic1;
            this.picSub.Image = Pic2;
            OnResize();
        }

        /// <summary>
        /// 调整控件尺寸.
        /// </summary>
        public void OnResize()
        {
            this.picMain.Left = 0;
            this.picMain.Top = 0;
            this.picMain.Width = this.Width;
            this.picMain.Height = this.Height;

            this.picSub.Left = 0;
            this.picSub.Top = 0;
            this.picSub.Width = this.Width;
            this.picSub.Height = this.Height;


        }




        


        /// <summary>
        /// 画面切换.
        /// </summary>
        public void Switch()
        {
            // 如果定时器未启动，那么开始启动定时期.
            if (!this.timerSwitch.Enabled)
            {
                // 设置图片.
                imageSwitch.PictureBox1 = this.picMain;
                imageSwitch.PictureBox2 = this.picSub;

                // 初始化.
                imageSwitch.InitImageSwitch();

                // 启动.
                this.timerSwitch.Start();
            }
        }



        /// <summary>
        /// 定时器处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSwitch_Tick(object sender, EventArgs e)
        {
            // 处理.
            bool result = imageSwitch.DoImageSwitch();

            // 处理结束.
            if (result)
            {
                this.timerSwitch.Stop();
            }
                


        }





        /// <summary>
        /// 切换图片.
        /// </summary>
        private void SwitchImage()
        {
            if (this.picMain.Image == Pic1)
            {
                this.picMain.Image = Pic2;
            }
            else
            {
                this.picMain.Image = Pic1;
            }
        }



    }
}
