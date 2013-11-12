using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A1040_Password.Handler;



namespace A1040_Password.ConcreteHandler
{

    /// <summary>
    /// 责任链中  检查密码中是否 “太简单” 的   具体处理者.
    /// </summary>
    public class PasswordToSimpleChecker : PasswordChecker
    {

        protected override bool DoPasswordCheck(string userName, string oldPassword, string newPassword)
        {
            // 密码不能包含用户的帐户名
            if (newPassword.ToLower().Contains(userName.ToLower()))
            {
                ErrorMessage = "密码不能包含用户的帐户名！";
                return false;
            }

            // 通过.
            return true;
        }
    }

}
