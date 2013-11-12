using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A1040_Password.Handler;


namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码中是否包含小写字母的   具体处理者.
    /// </summary>
    public class PasswordLowerCaseChecker : AbstractPasswordRangeChecker
    {

        /// <summary>
        /// 小写字母数组.
        /// </summary>
        private static readonly char[] LOWER_CASE_CHAR = "abcdefghijklmnopqrstuvwxyz".ToArray();


        protected override string GetCharRangeName()
        {
            return "大写字母";
        }

        protected override char[] GetCharRange()
        {
            return LOWER_CASE_CHAR;
        }
    }

}
