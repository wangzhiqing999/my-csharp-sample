using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0081_ImageSwitch.Service
{
    /// <summary>
    /// 平移图像切换处理
    /// </summary>
    public abstract class MoveImageSwitch : AbstractImageSwitch
    {

        /// <summary>
        /// 图片移动步骤.
        /// </summary>
        protected enum MoveStep
        {
            /// <summary>
            /// 移动中.
            /// </summary>
            OnMoving,

            /// <summary>
            /// 完成处理.
            /// </summary>
            Finish,
        }


        /// <summary>
        /// 图片移动步骤
        /// </summary>
        protected MoveStep moveStep;


        /// <summary>
        /// 初始化.
        /// </summary>
        protected override void InitOtherData()
        {
            // 初始化状态.
            moveStep = MoveStep.OnMoving;
        }



        /// <summary>
        /// 完成图像处理.
        /// </summary>
        /// <returns> 是否处理完毕， 返回 False 的情况下，表示还有后续处理. </returns>
        public override bool DoImageSwitch()
        {
            switch (this.moveStep)
            {
                case MoveStep.OnMoving :
                    // 移动中.
                    DoMoving();
                    return false;
                case  MoveStep.Finish :
                    // 完成.
                    return true;
            }

            return true;
        }



        /// <summary>
        /// 完成一次  图片 移动的处理.
        /// </summary>
        protected abstract void DoMoving();

    }

}
