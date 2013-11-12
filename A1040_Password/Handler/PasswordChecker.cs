using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1040_Password.Handler
{


    /// <summary>
    /// 密码检查类： 抽象处理者
    /// </summary>
    public abstract class PasswordChecker
    {

        /// <summary>
        /// 定义后继对象
        /// </summary>
        public PasswordChecker NextChecker { set; protected get; }


        /// <summary>
        /// 用于出错时返回的错误信息.
        /// </summary>
        public string ErrorMessage { protected set; get; }



        
        /// <summary>
        /// 检查密码是否满足复杂度要求.
        /// </summary>
        /// <param name="userName"> 用户名 </param>
        /// <param name="oldPassword"> 旧密码 </param>
        /// <param name="newPassword"> 新密码 </param>
        /// <returns></returns>
        public bool IsPasswordOk(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(newPassword))
            {
                // 用户名/密码 不能输入 null 或 空白.
                ErrorMessage = "用户名、密码不能为空！";
                return false;
            }

            if (!String.IsNullOrWhiteSpace(oldPassword))
            {
                // 如果 旧密码非空，那么需要检查， 新密码不能直接等于旧密码.
                if (oldPassword == newPassword)
                {
                    ErrorMessage = "新密码不能直接等于旧密码！";
                    return false;
                }
            }


            // 优先检查本项目.
            if (!this.DoPasswordCheck(userName, oldPassword, newPassword))
            {
                // 如果本 项目检查失败，那么可以直接返回，不必做后续检查了.
                return false;
            }

            // 尝试检查后续项目.
            if (this.NextChecker != null)
            {
                // 如果 后续项目不为空， 那么调用后续的检查处理.
                bool nextResult = this.NextChecker.DoPasswordCheck(userName, oldPassword, newPassword);
                if (!nextResult)
                {
                    this.ErrorMessage = this.NextChecker.ErrorMessage;
                    return false;
                }
            }

            // 如果能执行到这里， 说明 本项目检查通过， 且没有后续，那么可以返回 true 了.
            return true;
        }



        /// <summary>
        /// 抽象请求处理方法
        /// 检查密码是否满足复杂度要求.
        /// </summary>
        /// <param name="userName"> 用户名 </param>
        /// <param name="oldPassword"> 旧密码 </param>
        /// <param name="newPassword"> 新密码 </param>
        /// <returns></returns>
        protected abstract bool DoPasswordCheck(string userName, string oldPassword, string newPassword);
        

    }

}
