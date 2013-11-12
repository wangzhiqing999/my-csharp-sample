using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A1040_Password.Handler;


namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码中是否包含数字的   具体处理者.
    /// </summary>
    public class PasswordNumberChecker : AbstractPasswordRangeChecker
    {
        /// <summary>
        /// 大写字母数组.
        /// </summary>
        private static readonly char[] NUMBER_CHAR = "0123456789".ToArray();


        protected override string GetCharRangeName()
        {
            return "数字";
        }

        protected override char[] GetCharRange()
        {
            return NUMBER_CHAR;
        }
    }

}
