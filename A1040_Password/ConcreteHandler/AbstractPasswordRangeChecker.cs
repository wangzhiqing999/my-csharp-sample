using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A1040_Password.Handler;


namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码中是否包含 “指定范围字符”  的   抽象处理者.
    /// （子类负责提供具体的 “指定范围字符” ）
    /// </summary>
    public abstract class AbstractPasswordRangeChecker : PasswordChecker
    {


        protected override bool DoPasswordCheck(string userName, string oldPassword, string newPassword)
        {
            if (newPassword.IndexOfAny(GetCharRange()) == -1)
            {
                ErrorMessage = String.Format("密码中至少要包含一个{0}！", GetCharRangeName());
                return false;
            }

            // 密码中包含了小写字母.
            return true;
        }



        /// <summary>
        /// 取得 “指定范围字符” 的名称.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetCharRangeName();


        /// <summary>
        /// 取得 密码所要包含的  “指定范围字符”
        /// </summary>
        /// <returns></returns>
        protected abstract char[] GetCharRange();





    }


}
