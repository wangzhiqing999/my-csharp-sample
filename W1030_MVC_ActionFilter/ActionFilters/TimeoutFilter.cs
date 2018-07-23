using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using log4net;

namespace W1030_MVC_ActionFilter.ActionFilters
{
    public class TimeoutFilter : FilterAttribute, IActionFilter
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger("TIMEOUT");

        /// <summary>
        /// 最大可接受秒数.
        /// (超过将写日志.)
        /// </summary>
        private int _MaxSeconds = 3;


        public TimeoutFilter()
        {

        }

        public TimeoutFilter(int maxSeconds)
        {
            this._MaxSeconds = maxSeconds;
        }


        /// <summary>
        /// 开始处理时间.
        /// </summary>
        private DateTime startDateTime;


        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            // 本次调用消耗的时间.
            TimeSpan useTimes = DateTime.Now - startDateTime;

            if (useTimes.TotalSeconds >= _MaxSeconds)
            {
                // 总耗时超过限制, 写日志.
                WriteTimeoutLog(filterContext, useTimes);
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            startDateTime = DateTime.Now;
        }



        private static void WriteTimeoutLog(ActionExecutedContext filterContext, TimeSpan useTimes)
        {

            var actionInfo = filterContext.ActionDescriptor;
            var controllerInfo = actionInfo.ControllerDescriptor;
            var paramInfo = actionInfo.GetParameters();

            StringBuilder buff = new StringBuilder();
            buff.AppendLine("----- TIMEOUT -----");
            buff.AppendFormat("UserAgent：{0}", filterContext.HttpContext.Request.UserAgent);
            buff.AppendLine();
            buff.AppendFormat("Url：{0}", filterContext.HttpContext.Request.RawUrl);
            buff.AppendLine();
            buff.AppendFormat("Controller：{0}", controllerInfo.ControllerName);
            buff.AppendLine();
            buff.AppendFormat("Action：{0}", actionInfo.ActionName);
            buff.AppendLine();
            foreach (var param in paramInfo)
            {
                buff.AppendFormat("Parameter：{0} = {1}", param.ParameterName, filterContext.HttpContext.Request[param.ParameterName]);                
                buff.AppendLine();
            }

            buff.AppendFormat("TotalMilliseconds：{0}", useTimes.TotalMilliseconds);
            buff.AppendLine();

            logger.Warn(buff.ToString());
        }

    }
}