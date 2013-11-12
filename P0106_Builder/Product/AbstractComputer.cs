using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0106_Builder.Product
{

    /// <summary>
    /// 这是 建造模式中的  产品。
    ///  
    /// 本例子用于 描述一台计算机 (抽象的).
    /// </summary>
    public abstract class AbstractComputer
    {
        /// <summary>
        /// 硬件.
        /// </summary>
        public string Hardward { set; get; }


        /// <summary>
        /// 软件.
        /// </summary>
        public string Software { set; get; }



        /// <summary>
        /// 打开计算机.
        /// </summary>
        public abstract void StartComputer();

    }

}
