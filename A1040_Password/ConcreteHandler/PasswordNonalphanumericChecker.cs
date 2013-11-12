using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码中是否包含 非字母字符(例如 !、$、#、%) 的   具体处理者.
    /// </summary>
    public class PasswordNonalphanumericChecker : AbstractPasswordRangeChecker
    {

        /// <summary>
        /// 非字母字符数组.
        /// </summary>
        private static readonly char[] NONALPHANUMERIC_CHAR = "~!@#$%^&*()_+{}|:\"<>?`-=[]\\;',./".ToArray();


        protected override string GetCharRangeName()
        {
            return "非字母字符(例如 !、$、#、%)";
        }

        protected override char[] GetCharRange()
        {
            return NONALPHANUMERIC_CHAR;
        }
    }


}
