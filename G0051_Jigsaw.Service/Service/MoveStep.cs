using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0051_Jigsaw.Service
{

    /// <summary>
    /// 移动步骤.
    /// </summary>
    public class MoveStep
    {
        public MoveStep(int i, int j)
        {
            this.I = i;
            this.J = j;
        }

        /// <summary>
        /// I.
        /// </summary>
        public int I { set; get; }

        /// <summary>
        /// J.
        /// </summary>
        public int J { set; get; }
    }
}
