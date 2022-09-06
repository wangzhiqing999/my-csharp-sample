using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Diagnostics;

namespace W1303_LongTimeProc.Service
{

    /// <summary>
    /// 长时间处理的服务.
    /// </summary>
    public class LongTimeFuncService
    {


        public bool LongTimeFunc(Action<int> noticeAction = null)
        {
            int count = 100;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    // 这里模拟长时间操作.
                    Thread.Sleep(1000);

                    if (noticeAction != null)
                    {
                        noticeAction(i+1);
                    }
                }
                return true;
            } 
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return false;
            }
            
        }


    }
}