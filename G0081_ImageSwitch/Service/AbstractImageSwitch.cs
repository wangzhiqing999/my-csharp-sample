using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;



namespace G0081_ImageSwitch.Service
{

    /// <summary>
    /// 图像切换处理.
    /// </summary>
    public abstract class AbstractImageSwitch
    {

        /// <summary>
        /// 图片控件1.
        /// </summary>
        public PictureBox PictureBox1 { set; get; }


        /// <summary>
        /// 图片控件2.
        /// </summary>
        public PictureBox PictureBox2 { set; get; }



        /// <summary>
        /// 图片切换的像素.
        /// </summary>
        protected int switchStep = 3;


        /// <summary>
        /// 图片切换的像素
        /// (每次切换多少个像素)
        /// </summary>
        public int SwitchStep
        {
            set
            {
                switchStep = value;
            }
            get
            {
                return switchStep;
            }
        }



        /// <summary>
        /// 初始的图像宽度.
        /// </summary>
        protected int DefaultPicWidth;


        /// <summary>
        /// 初始的图像高度.
        /// </summary>
        protected int DefaultPicHeight;



        /// <summary>
        /// 当前图片.
        /// </summary>
        protected PictureBox ForePictureBox;


        /// <summary>
        /// 背后的图片.
        /// </summary>
        protected PictureBox BackPictureBox;




        /// <summary>
        /// 初始化图像切换处理.
        /// </summary>
        public void InitImageSwitch()
        {
            // 设置图像高度.
            this.DefaultPicWidth = Math.Max(PictureBox1.Width, PictureBox2.Width);
            this.DefaultPicHeight = Math.Max(PictureBox1.Height, PictureBox2.Height);


            // 判断哪一张是 前景， 哪一张是 背景.
            if (IsForePictureBox(this.PictureBox1))
            {
                this.ForePictureBox = this.PictureBox1;
                this.BackPictureBox = this.PictureBox2;
            }
            else
            {
                this.ForePictureBox = this.PictureBox2;
                this.BackPictureBox = this.PictureBox1;
            }


            // 初始化其他数据.
            InitOtherData();
        }


        /// <summary>
        /// 初始化其他数据.
        /// 此方法 由子类覆盖处理.
        /// </summary>
        protected virtual void InitOtherData()
        {
        }



        /// <summary>
        /// 完成图像处理.
        /// </summary>
        /// <returns> 是否处理完毕， 返回 False 的情况下，表示还有后续处理. </returns>
        public abstract bool DoImageSwitch();




        /// <summary>
        /// 是否是前景图片.
        /// </summary>
        /// <param name="picBox"></param>
        /// <returns></returns>
        private bool IsForePictureBox(PictureBox picBox)
        {
            // 仅仅当图片可见，并且宽度等都填满的情况下，才认为是前景.
            return (picBox.Visible
                && picBox.Top == 0
                && picBox.Left == 0
                && picBox.Height == DefaultPicHeight
                && picBox.Width == DefaultPicWidth);
        }



    }




}
