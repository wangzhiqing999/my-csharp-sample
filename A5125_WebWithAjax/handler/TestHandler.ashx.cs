using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A5125_WebWithAjax.handler
{
    /// <summary>
    /// TestHandler 的摘要说明
    /// </summary>
    public class TestHandler : AbstractHandler<TestHandleResult> 
    {

        protected override TestHandleResult GetDefaultHandleResult()
        {
            return new TestHandleResult()
            {
                Result = false,
            };
        }



        protected override void DoProcess(HttpContext context, TestHandleResult result)
        {
            result.Result = true;
            result.ResultMessage = "处理成功！";


            result.UserCode = "9527";
            result.UserName = "张三";
            result.CardList = new List<string>()
            {
                "13579",
                "24680",
            };
        }


        protected override bool IsNeedLogin()
        {
            return false;
        }

    }
}