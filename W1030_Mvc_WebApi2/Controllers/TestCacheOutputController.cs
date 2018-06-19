using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi.OutputCache.V2;



namespace W1030_Mvc_WebApi2.Controllers
{

    /// <summary>
    /// 测试在 在ASP.NET WebAPI 中使用缓存.
    /// 
    /// 安装 PM>Install-Package Strathweb.CacheOutput.WebApi2
    /// 
    /// </summary>
    public class TestCacheOutputController : ApiController
    {


        /// <summary>
        /// 无参数的缓存测试.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TestCacheOutput/TestGet")]
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public string TestGet()
        {
            return DateTime.Now.ToString();
        }



        /// <summary>
        /// 有参数的缓存测试.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TestCacheOutput/TestGetByKey")]
        [CacheOutput(ServerTimeSpan = 60, ExcludeQueryStringFromCacheKey = true)]
        public string TestGetByKey(string id)
        {
            return DateTime.Now.ToString();
        }


    }
}
