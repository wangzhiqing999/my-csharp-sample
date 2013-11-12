using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A1040_Password.Handler;


namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码中是否包含大写字母的   具体处理者.
    /// </summary>
    public class PasswordUpperCaseChecker : AbstractPasswordRangeChecker
    {
        /// <summary>
        /// 大写字母数组.
        /// </summary>
        private static readonly char[] UPPER_CASE_CHAR = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();


        protected override string GetCharRangeName()
        {
            return "大写字母";
        }

        protected override char[] GetCharRange()
        {
            return UPPER_CASE_CHAR;
        }
    }


}
