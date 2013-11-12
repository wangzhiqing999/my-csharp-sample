using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A1040_Password.Handler;


namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中   按照微软的密码复杂度实现的   具体处理者.
    /// 
    /// 如果启用此策略，密码必须符合下列最低要求:
    /// 
    /// 不能包含用户的帐户名，不能包含用户姓名中超过两个连续字符的部分
    /// 
    /// 至少有六个字符长
    /// 
    /// 包含以下四类字符中的三类字符:
    /// 英文大写字母(A 到 Z)
    /// 英文小写字母(a 到 z)
    /// 10 个基本数字(0 到 9)
    /// 非字母字符(例如 !、$、#、%)
    /// 
    /// 
    /// </summary>
    public class MsPasswordChecker : PasswordChecker
    {

        /// <summary>
        /// 密码复杂度检查的 根节点.
        /// </summary>
        private static PasswordChecker rootPasswordChecker = new PasswordLengthChecker()
        {
            // 至少 6 个字符.
            MinPasswordLength = 6,

            // 最多 15
            MaxPasswordLength = 15,

            // 后续检查项目: 不能太简单.
            NextChecker = new PasswordToSimpleChecker()
        };



        /// <summary>
        /// 密码检查数组.
        /// </summary>
        private static PasswordChecker[] checkerArray = {
                                                            // 数字检查.
                                                            new PasswordNumberChecker(),
                                                            // 大写字母检查.
                                                            new PasswordUpperCaseChecker(),
                                                            // 小写字母检查.
                                                            new PasswordLowerCaseChecker(),
                                                            // 非字母字符检查.
                                                            new PasswordNonalphanumericChecker(),
                                                         };



        protected override bool DoPasswordCheck(string userName, string oldPassword, string newPassword)
        {
            if (!rootPasswordChecker.IsPasswordOk(userName, oldPassword, newPassword))
            {
                // 长度检查失败 或者太简单， 直接返回.
                this.ErrorMessage = rootPasswordChecker.ErrorMessage;
                return false;
            }

            // 检查通过次数.
            int checkPassTimes = 0;
            foreach (PasswordChecker checker in checkerArray)
            {
                if (checker.IsPasswordOk(userName, oldPassword, newPassword))
                {
                    checkPassTimes++;
                }
            }

            if (checkPassTimes < 3)
            {
                this.ErrorMessage = @"密码必须要包含以下四类字符中的三类字符:
英文大写字母(A 到 Z)
英文小写字母(a 到 z)
10 个基本数字(0 到 9)
非字母字符(例如 !、$、#、%)";
                return false;
            }


            // 检查通过
            return true;
        }



    }



}
