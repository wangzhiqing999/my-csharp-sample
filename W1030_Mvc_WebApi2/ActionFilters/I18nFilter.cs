using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

using System.Globalization;

using W1030_Mvc_WebApi2.Models;
using W1030_Mvc_WebApi2.Resource;


// 注意：这个 Filter 是 WebApi 的 Filter.  
// 上面是 using System.Web.Http.Filters;
// 如果写成 using System.Web.Mvc;
// 那么在 Web Api 中，将没有任何效果。

namespace W1030_Mvc_WebApi2.ActionFilters
{
    public class I18nFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            
            base.OnActionExecuting(actionContext);
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {           
            var context = actionExecutedContext.Response.Content;

            // 如果返回的结果，是通用的服务结果.
            if (context is ObjectContent<CommonServiceResult>)
            {
                // 结果转换.
                ObjectContent<CommonServiceResult> result = (ObjectContent<CommonServiceResult>)context;

                // 获取结果数据.
                CommonServiceResult resultData = (CommonServiceResult)result.Value;

                if (!resultData.IsSuccess)
                {
                    // 仅仅在失败的情况下， 才尝试从资源文件中获取错误信息.

                    // 获取客户端的语言请求.
                    CultureInfo cultureInfo = GetCultureInfo(actionExecutedContext.Request);

                    // 设置错误信息.
                    resultData.ResultMessage = MyResource.ResourceManager.GetString(resultData.ResultCode, cultureInfo);
                }

                
            }


            base.OnActionExecuted(actionExecutedContext);
        }




        private CultureInfo GetCultureInfo(HttpRequestMessage request)
        {
            var lang = request.Headers.AcceptLanguage;
            var langItem = lang.FirstOrDefault();

            if (langItem != null)
            {
                string langStr = langItem.Value;
                CultureInfo result = new CultureInfo(langStr);
                return result;
            }

            // http 头中，未定义 AcceptLanguage， 返回默认值.
            return CultureInfo.DefaultThreadCurrentCulture;
        }


    }
}