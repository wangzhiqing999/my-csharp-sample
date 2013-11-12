using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0081_ImageSwitch.Service
{

    /// <summary>
    /// 由左向右平移.
    /// </summary>
    public class MoveLeftToRightImageSwitch : MoveImageSwitch
    {


        /// <summary>
        /// 初始化.
        /// </summary>
        protected override void InitOtherData()
        {
            // 首先调用父类的初始化.
            base.InitOtherData();

            // 由左向右移动. 背景图片移动到 看不见的区域.
            this.BackPictureBox.Left = -DefaultPicWidth;
        }



        /// <summary>
        /// 完成一次  图片 移动的处理.
        /// </summary>
        protected override void DoMoving()
        {
            // 前景图左移.
            this.ForePictureBox.Left += switchStep;

            // 背景图左移.
            this.BackPictureBox.Left = Math.Min(0, this.BackPictureBox.Left + switchStep);



            // 当背景图 Left = 0 的情况下， 进入下一阶段.
            if (this.BackPictureBox.Left == 0)
            {
                this.moveStep = MoveStep.Finish;
            }
        }
    }
}
