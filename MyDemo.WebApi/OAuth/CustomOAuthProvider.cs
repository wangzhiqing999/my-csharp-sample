using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyDemo.WebApi
{
    /// <summary>
    /// created by Grissom at 2016-10-09 12:00:00
    /// 自定义 jwt oauth 的授权验证
    /// </summary>
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {


        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var username = context.UserName;
            var password = context.Password;
            string userid;
            if (!CheckCredential(username, password, out userid))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                context.Rejected();
                return Task.FromResult<object>(null);
            }
            var ticket = new AuthenticationTicket(SetClaimsIdentity(context, userid, username), new AuthenticationProperties());
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // 资源所有者密码凭据未提供客户端 ID。
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, string userid, string usercode)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Sid, userid));
            identity.AddClaim(new Claim(ClaimTypes.Name, usercode));
            return identity;
        }

        private static bool CheckCredential(string usernme, string password, out string userid)
        {
            var success = false;


            // 测试的用户  test / test2 / test3
            if (password == "123456")
            {
                switch (usernme)
                {
                    case "test":
                        userid = "1";
                        success = true;
                        break;

                    case "test2":
                        userid = "2";
                        success = true;
                        break;

                    case "test3":
                        userid = "3";
                        success = true;
                        break;

                    default:
                        userid = "";
                        break;
                }
            }
            else
            {
                userid = "";
            }
            return success;
        }
    }
}
