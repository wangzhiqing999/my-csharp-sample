using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0081_ImageSwitch.Service
{

    /// <summary>
    /// 由上向下平移.
    /// </summary>
    public class MoveUpToDownImageSwitch : MoveImageSwitch
    {
        /// <summary>
        /// 初始化.
        /// </summary>
        protected override void InitOtherData()
        {
            // 首先调用父类的初始化.
            base.InitOtherData();

            // 由上向下移动. 背景图片移动到 看不见的区域.
            this.BackPictureBox.Top = -DefaultPicHeight;
        }



        /// <summary>
        /// 完成一次  图片 移动的处理.
        /// </summary>
        protected override void DoMoving()
        {
            // 前景图左移.
            this.ForePictureBox.Top += switchStep;

            // 背景图左移.
            this.BackPictureBox.Top = Math.Min(0, this.BackPictureBox.Top + switchStep);



            // 当背景图 Top = 0 的情况下， 进入下一阶段.
            if (this.BackPictureBox.Top == 0)
            {
                this.moveStep = MoveStep.Finish;
            }
        }

    }

}
