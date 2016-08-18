using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.AppDemo
{
    /// <summary>
    /// CommonHandler 的摘要说明
    /// </summary>
    public class CommonHandler : AbstractHandler<CommonHandleResult> 
    {


        protected override CommonHandleResult GetDefaultHandleResult()
        {
            return new CommonHandleResult()
            {
                Result = false,
            };
        }


        protected override void DoProcess(HttpContext context, CommonHandleResult result)
        {
            result.Result = true;
            result.ResultMessage = "处理成功！";
        }


        //protected override bool IsNeedLogin()
        //{
        //    return false;
        //}


    }
}