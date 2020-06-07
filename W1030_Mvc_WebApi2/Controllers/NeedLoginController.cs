using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using W1030_Mvc_WebApi2.ActionFilters;

namespace W1030_Mvc_WebApi2.Controllers
{

    /// <summary>
    /// 测试一个   需要登录的  WebApi 控制器.
    /// </summary>
    public class NeedLoginController : ApiController
    {



        // GET api/NeedLogin
        [AuthFilter]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


    }
}
