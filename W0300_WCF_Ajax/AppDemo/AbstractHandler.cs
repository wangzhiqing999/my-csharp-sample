using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

using log4net;





namespace W0300_WCF_Ajax.AppDemo
{


    /// <summary>
    /// 抽象处理程序.
    /// </summary>
    public abstract class AbstractHandler<T> : IHttpHandler, IRequiresSessionState
        where T : CommonHandleResult
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 获取 默认的 处理结果.
        /// </summary>
        /// <returns></returns>
        protected abstract T GetDefaultHandleResult();

        /// <summary>
        /// 处理逻辑.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        protected abstract void DoProcess(HttpContext context, T result);



        ///// <summary>
        ///// 是否需要先登录后，才能执行相关处理.
        ///// (默认要求是)
        ///// </summary>
        ///// <returns></returns>
        //protected virtual bool IsNeedLogin()
        //{
        //    return true;
        //}



        //protected const string Session_Keyword_Is_Pbulic_User = "LoginUser";



        public void ProcessRequest(HttpContext context)
        {
            T result = GetDefaultHandleResult();

            try
            {
                //if (IsNeedLogin())
                //{
                //    if (context.Session == null)
                //    {
                //        result.ResultMessage = "没有登录，请重新登录！";
                //        return;
                //    }

                //    if (context.Session[Session_Keyword_Is_Pbulic_User] == null)
                //    {
                //        result.ResultMessage = "没有登录，或会话超时，请重新登录！";
                //        return;
                //    }                    
                //}


                // 执行实际的处理.
                DoProcess(context, result);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                result.ResultMessage = "服务器忙";
            }
            finally
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("ProcessRequest Finish! Result = {0} ", result);
                }

                // 输出结果.
                HandleResultConvert.WriteResponseString(context, result);
            }

        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }



}