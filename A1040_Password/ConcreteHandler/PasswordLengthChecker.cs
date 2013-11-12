using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A1040_Password.Handler;


namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码长度的  具体处理者.
    /// </summary>
    public class PasswordLengthChecker : PasswordChecker
    {

        /// <summary>
        /// 密码最小长度.
        /// </summary>
        public int MinPasswordLength { set; get; }

        /// <summary>
        /// 密码最大长度.
        /// </summary>
        public int MaxPasswordLength { set; get; }



        protected override bool DoPasswordCheck(string userName, string oldPassword, string newPassword)
        {
            // 长度检查.
            if ( newPassword.Length < MinPasswordLength)
            {
                ErrorMessage = String.Format("密码长度不能小于 {0} ！", MinPasswordLength);
                return false;
            }

            // 长度检查.
            if (newPassword.Length > MaxPasswordLength)
            {
                ErrorMessage = String.Format("密码长度不能大于 {0} ！", MaxPasswordLength);
                return false;
            }

            // 长度没有问题.
            return true;
        }
    }
}
