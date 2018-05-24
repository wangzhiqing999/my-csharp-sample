using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using W1030_Mvc_WebApi2.ActionFilters;
using W1030_Mvc_WebApi2.Models;

namespace W1030_Mvc_WebApi2.Controllers
{

    /// <summary>
    /// 用于测试 错误消息国际化的 Web Api 控制器.
    /// </summary>
    [I18nFilter]
    public class TestI18nController : ApiController
    {


        /// <summary>
        /// 获取默认的 成功返回.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TestI18n/Success")]
        public CommonServiceResult GetDefaultSuccessResult()
        {
            return CommonServiceResult.DefaultSuccessResult;
        }


        /// <summary>
        /// 获取数据不存在的返回.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TestI18n/DataNotFound")]
        public CommonServiceResult GetDataNotFoundResult()
        {
            return CommonServiceResult.DataNotFoundResult;
        }


        /// <summary>
        /// 获取服务器异常的返回.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TestI18n/SystemException")]
        public CommonServiceResult GetSystemExceptionResult()
        {
            Exception ex = new Exception("服务器异常.");
            return new CommonServiceResult(ex);
        }

    }
}
