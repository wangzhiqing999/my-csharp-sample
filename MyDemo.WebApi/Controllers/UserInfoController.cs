using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;


namespace MyDemo.WebApi.Controllers
{

    [Authorize]
    public class UserInfoController : ApiController
    {

        // GET api/UserInfo
        [HttpGet]        
        public string Get()
        {

            // 这里主要的测试目标， 是通过令牌， 获取【当前登录用户】的详细信息。

            // 获取令牌内的详细信息.
            var claimsIdentity = User.Identity as ClaimsIdentity;

            // 这里能获取到哪些信息， 取决于 CustomOAuthProvider 的 SetClaimsIdentity 那里， 生成 Token 的时候， 都填写了哪些。
            var name = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            var userid = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value;

            string result = String.Format("分析 Token 信息，了解到，当前的 UserName={0}; userid={1}", name, userid);
            return result;
        }



    }
}
