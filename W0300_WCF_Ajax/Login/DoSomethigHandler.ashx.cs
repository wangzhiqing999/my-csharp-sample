using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading;


namespace W0300_WCF_Ajax.Login
{
    /// <summary>
    /// DoSomethigHandler 的摘要说明
    /// </summary>
    public class DoSomethigHandler : AbstractHandler<CommonHandleResult> 
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

            // 休眠3秒， 模拟一个长时间操作.
            Thread.Sleep(3000);

            result.Result = true;
            result.ResultMessage = "处理成功！";
        }



    }


}