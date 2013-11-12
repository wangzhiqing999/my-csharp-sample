using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A1040_Password.Handler;


namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码中是否包含字母的   具体处理者.
    /// </summary>
    public class PasswordLettersChecker : AbstractPasswordRangeChecker
    {

        /// <summary>
        /// 字母数组.
        /// </summary>
        private static readonly char[] LETTER_CHAR = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();


        protected override string GetCharRangeName()
        {
            return "字母";
        }

        protected override char[] GetCharRange()
        {
            return LETTER_CHAR;
        }
    }

}
