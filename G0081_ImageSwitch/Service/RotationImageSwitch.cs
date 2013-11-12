using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace G0081_ImageSwitch.Service
{
    /// <summary>
    /// 旋转图像切换处理
    /// </summary>
    public abstract class RotationImageSwitch : AbstractImageSwitch
    {

        /// <summary>
        /// 图片旋转步骤.
        /// </summary>
        protected enum RotationStep
        {
            /// <summary>
            /// 从大到小.
            /// </summary>
            LargeToSmall,

            /// <summary>
            /// 图片变换.
            /// </summary>
            ChangeImage,

            /// <summary>
            /// 从小变大.
            /// </summary>
            SmallToLarge,


            /// <summary>
            /// 完成处理.
            /// </summary>
            Finish,
        }

        /// <summary>
        /// 图片旋转步骤
        /// </summary>
        protected RotationStep rotationStep;



        /// <summary>
        /// 初始化其他数据.
        /// </summary>
        protected override void InitOtherData()
        {
            // 初始情况下，需要调整为 “从大变小”
            rotationStep = RotationStep.LargeToSmall;

            // 旋转的情况下, 前景图片需要放到前面.
            ForePictureBox.BringToFront();


            // 旋转的模式下， 需要调整图像的 显示模式.
            this.ForePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }




        /// <summary>
        /// 完成图像处理.
        /// </summary>
        /// <returns> 是否处理完毕， 返回 False 的情况下，表示还有后续处理. </returns>
        public override bool DoImageSwitch()
        {
            switch (this.rotationStep)
            {
                case RotationStep.LargeToSmall:
                    // 从大到小.
                    DoFromLargeToSmall();
                    return false;


                case RotationStep.ChangeImage:
                    // 切换图片.
                    SwitchImage();
                    // 进入下一个阶段
                    this.rotationStep = RotationStep.SmallToLarge;
                    return false;


                case RotationStep.SmallToLarge:
                    // 从小到大.
                    DoFromSmallToLarge();
                    return false;

            }

            return true;
        }



        /// <summary>
        /// 完成一次  大图片 变小的处理.
        /// </summary>
        protected abstract void DoFromLargeToSmall();


        /// <summary>
        /// 完成一次  小图片 变大的处理.
        /// </summary>
        protected abstract void DoFromSmallToLarge();




        /// <summary>
        /// 切换图片.
        /// </summary>
        protected void SwitchImage()
        {
            // 初始情况下， 是 前景图片在前面， 背景图片在后面.
            // 切换后， 需要把 背景图片放前面， 前景图片放后面.
            BackPictureBox.BringToFront();
        }



    }

}
