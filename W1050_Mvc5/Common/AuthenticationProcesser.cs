using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using W1050_Mvc5.Models;

namespace W1050_Mvc5.Common
{

    /// <summary>
    /// 认证处理接口.
    /// </summary>
    public interface IAuthenticationProcesser
    {


        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        CommonServiceResult Login(Controller controller, string userName);


        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        CommonServiceResult Logoff(Controller controller);


        /// <summary>
        /// 是否登录
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        CommonServiceResult<string> IsLogin(Controller controller);


    }





    /// <summary>
    /// 认证处理.
    /// </summary>
    public static class AuthenticationProcesser
    {
        /// <summary>
        /// 这里根据具体的情况，  来使用哪一个 方案来完成.
        /// </summary>
        private static readonly IAuthenticationProcesser _AuthenticationProcesser = new DefaultAuthenticationProcesser();



        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static CommonServiceResult Login(Controller controller, string userName)
        {
            return _AuthenticationProcesser.Login(controller, userName);
        }

        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static CommonServiceResult Logoff(Controller controller)
        {
            return _AuthenticationProcesser.Logoff(controller);
        }


        /// <summary>
        /// 是否登录
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static CommonServiceResult<string> IsLogin(Controller controller)
        {
            return _AuthenticationProcesser.IsLogin(controller);
        }

    }





    /// <summary>
    /// 认证处理 默认实现.
    /// </summary>
    public class DefaultAuthenticationProcesser : IAuthenticationProcesser
    {

        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public CommonServiceResult Login(Controller controller, string userName)
        {
            FormsAuthentication.SetAuthCookie(userName, true);
            return CommonServiceResult.DefaultSuccessResult;
        }


        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public CommonServiceResult Logoff(Controller controller)
        {
            FormsAuthentication.SignOut();
            return CommonServiceResult.DefaultSuccessResult;
        }


        /// <summary>
        /// 是否登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public CommonServiceResult<string> IsLogin(Controller controller)
        {
            if (controller.User.Identity.IsAuthenticated == false)
            {
                return CommonServiceResult<string>.CreateFailResult("USER_NOT_LOGION", "用户未登录");
            }
            return CommonServiceResult<string>.CreateDefaultSuccessResult(controller.User.Identity.Name);
        }


    }





    /// <summary>
    /// 使用 Cookie 的实现.
    /// </summary>
    public class CookieAuthenticationProcesser : IAuthenticationProcesser
    {

        /// <summary>
        /// 用于加密/解密 的 AES 处理器.
        /// </summary>
        private static readonly AES myAes = new AES()
        {
            // 密钥
            Key = @")O[NB]6,YF}+efcaj{+oESb9d8>Z'e9M",

            // 向量
            IV = @"L+\~f4,Ir)b$=pkf"
        };



        /// <summary>
        /// 用于验证登录的 Cookie 名称.
        /// </summary>
        private const string AUTHENTICATION_COOKIE_NAME = "MY_AU";




        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public CommonServiceResult Login(Controller controller, string userName)
        {
            try
            {
                var request = controller.Request;
                var cookies = request.Cookies;

                var response = controller.Response;


                // 加密.
                string cookieValue = myAes.AESEncrypt(userName);

                HttpCookie newCookie = new HttpCookie(AUTHENTICATION_COOKIE_NAME);

                // Cookie中添加信息项：为键值对，key/value
                newCookie.Value = cookieValue;

                // 如果不设置Expires属性，即为临时Cookie，浏览器关闭即消失.
                newCookie.Expires = DateTime.Now.AddDays(1);  // 设置过期天数为1天.

                // 写入Cookies集合.
                response.AppendCookie(newCookie);

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                return new CommonServiceResult(ex);
            }
        }


        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public CommonServiceResult Logoff(Controller controller)
        {
            try
            {
                var request = controller.Request;
                var cookies = request.Cookies;

                var response = controller.Response;

                HttpCookie newCookie = new HttpCookie(AUTHENTICATION_COOKIE_NAME);

                // Cookie中添加信息项：为键值对，key/value
                newCookie.Value = string.Empty;

                // 如果不设置Expires属性，即为临时Cookie，浏览器关闭即消失.
                newCookie.Expires = DateTime.Now;  // 设置立即过期

                // 写入Cookies集合.
                response.AppendCookie(newCookie);

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                return new CommonServiceResult(ex);
            }
        }


        /// <summary>
        /// 是否登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public CommonServiceResult<string> IsLogin(Controller controller)
        {
            try
            {
                var request = controller.Request;
                var cookies = request.Cookies;
                if (!cookies.AllKeys.Contains(AUTHENTICATION_COOKIE_NAME))
                {
                    // 不包含 指定名称的 cookie.
                    return CommonServiceResult<string>.CreateFailResult("USER_NOT_LOGION", "用户未登录");
                }

                var cookie = cookies[AUTHENTICATION_COOKIE_NAME];
                string cookieValue = cookie.Value;
                if (string.IsNullOrEmpty(cookieValue))
                {
                    return CommonServiceResult<string>.CreateFailResult("USER_NOT_LOGION", "用户未登录");
                }


                // 解密.
                string userName = myAes.AESDecrypt(cookieValue);

                return CommonServiceResult<string>.CreateDefaultSuccessResult(userName);

            }
            catch (Exception ex)
            {
                return new CommonServiceResult<string>(ex);
            }
        }

    }





    /// <summary>
    /// 使用 Session 处理.
    /// </summary>
    public class SessionAuthenticationProcesser : IAuthenticationProcesser
    {


        /// <summary>
        /// 用于验证登录的 SESSION 名称.
        /// </summary>
        private const string AUTHENTICATION_SESSION_NAME = "MY_AU";






        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public CommonServiceResult Login(Controller controller, string userName)
        {
            try
            {
                var session = controller.Session;
                session[AUTHENTICATION_SESSION_NAME] = userName;
                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                return new CommonServiceResult(ex);
            }
        }


        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public CommonServiceResult Logoff(Controller controller)
        {
            try
            {
                var session = controller.Session;
                session[AUTHENTICATION_SESSION_NAME] = string.Empty;
                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                return new CommonServiceResult(ex);
            }
        }



        /// <summary>
        /// 是否登录.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public CommonServiceResult<string> IsLogin(Controller controller)
        {
            try
            {
                var session = controller.Session;
                string userName = session[AUTHENTICATION_SESSION_NAME] as string;
                if (string.IsNullOrEmpty(userName))
                {
                    return CommonServiceResult<string>.CreateFailResult("USER_NOT_LOGION", "用户未登录");
                }

                return CommonServiceResult<string>.CreateDefaultSuccessResult(userName);
            }
            catch (Exception ex)
            {
                return new CommonServiceResult<string>(ex);
            }
        }
    }


}