using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0081_ImageSwitch.Service
{

    /// <summary>
    /// 旋转图像切换处理 (左右旋转)
    /// </summary>
    public class RotationLeftToRightImageSwitch : RotationImageSwitch
    {
        /// <summary>
        /// 初始化其他数据.
        /// </summary>
        protected override void InitOtherData()
        {
            // 先调用父类的初始化方法.
            base.InitOtherData();

            // 背景图片需要提前缩小.
            BackPictureBox.Left = DefaultPicWidth / 2;
            BackPictureBox.Width = 1;
        }



        /// <summary>
        /// 完成一次  大图片 变小的处理.
        /// </summary>
        protected override void DoFromLargeToSmall()
        {
            // 从大到小.
            // 图片从左边向右移动.
            this.ForePictureBox.Left += SwitchStep;
            // 图片宽度减少（相当于图片右边向左移动.）
            this.ForePictureBox.Width -= (2 * SwitchStep);
            //this.ForePictureBox.Refresh();

            if (this.ForePictureBox.Left + SwitchStep > DefaultPicWidth / 2)
            {
                // 进入下一个阶段
                this.rotationStep = RotationStep.ChangeImage;
            }
        }


        /// <summary>
        /// 完成一次  小图片 变大的处理.
        /// </summary>
        protected override void DoFromSmallToLarge()
        {
            this.BackPictureBox.Left = Math.Max(this.BackPictureBox.Left - SwitchStep, 0); ;
            this.BackPictureBox.Width += (2 * SwitchStep);
            this.BackPictureBox.Width = Math.Min(this.BackPictureBox.Width, DefaultPicWidth);
            //this.BackPictureBox.Refresh();

            if (this.BackPictureBox.Left == 0 && this.BackPictureBox.Width == DefaultPicWidth)
            {
                // 进入下一个阶段
                this.rotationStep = RotationStep.Finish;
            }

        }
    }

}
