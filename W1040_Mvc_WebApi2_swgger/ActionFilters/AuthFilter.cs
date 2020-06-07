using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;

namespace W1040_Mvc_WebApi2_swgger.ActionFilters
{

    /// <summary>
    /// 模拟一个  需要  Auth 验证的 Filter.
    /// 
    /// </summary>
    public class AuthFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            bool isLogin = ((ApiController)actionContext.ControllerContext.Controller).User.Identity.IsAuthenticated;


            if(isLogin == false)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Redirect, "https://www.baidu.com/");
                return;
            }

            
            
        }


    }
}