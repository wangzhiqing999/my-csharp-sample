using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0081_ImageSwitch.Service
{
    /// <summary>
    /// 旋转图像切换处理 (上下旋转)
    /// </summary>
    public class RotationUpToDownImageSwitch : RotationImageSwitch
    {
        /// <summary>
        /// 初始化其他数据.
        /// </summary>
        protected override void InitOtherData()
        {
            // 先调用父类的初始化方法.
            base.InitOtherData();

            // 背景图片需要提前缩小.
            BackPictureBox.Top  = DefaultPicHeight / 2;
            BackPictureBox.Height = 1;
        }





        /// <summary>
        /// 完成一次  大图片 变小的处理.
        /// </summary>
        protected override void DoFromLargeToSmall()
        {
            // 从大到小.
            // 图片从上边向下移动.
            this.ForePictureBox.Top += SwitchStep;
            // 图片高度减少（相当于图片从上边向下移动.）
            this.ForePictureBox.Height -= (2 * SwitchStep);
            //this.ForePictureBox.Refresh();

            if (this.ForePictureBox.Top + SwitchStep > DefaultPicHeight / 2)
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
            this.BackPictureBox.Top = Math.Max(this.BackPictureBox.Top - SwitchStep, 0); ;
            this.BackPictureBox.Height += (2 * SwitchStep);
            this.BackPictureBox.Height = Math.Min(this.BackPictureBox.Height, DefaultPicHeight);
            //this.BackPictureBox.Refresh();

            if (this.BackPictureBox.Top == 0 && this.BackPictureBox.Height == DefaultPicHeight)
            {
                // 进入下一个阶段
                this.rotationStep = RotationStep.Finish;
            }
        }
    }

}
