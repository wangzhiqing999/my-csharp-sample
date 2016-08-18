using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.AppDemo
{

    /// <summary>
    /// 例子： 
    /// 
    /// 用于模拟每日检查今天是否打卡了.
    /// </summary>
    public class DailyCheckHandler : AbstractHandler<CommonHandleResult> 
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
            // 取得手机号码.
            string phone = context.Request["phone"];

            if (String.IsNullOrEmpty(phone))
            {
                result.ResultMessage = "数据异常，处理发生错误！";
                result.Result = false;
                return;
            }


            result.Result = true;

            if (phone == "13800000000")
            {                                
                result.ResultMessage = "您今天已打卡，上午8:50, 下午18:10。";
            }
            else
            {
                result.ResultMessage = "您今天尚未打卡！";
            }

        }


    }
}