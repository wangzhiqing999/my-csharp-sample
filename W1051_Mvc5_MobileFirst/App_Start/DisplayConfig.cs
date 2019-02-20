using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;


namespace W1051_Mvc5_MobileFirst
{
    public class DisplayConfig
    {
        /// <summary>
        /// 注册设备模式.
        /// </summary>
        /// <param name="displayModes"></param>
        public static void RegisterDisplayModes(IList<IDisplayMode> displayModes)
        {
            // 默认的 手机 模式， 没有额外的附加.
            var modeSmartphone = new DefaultDisplayMode("")
            {
                ContextCondition = (c => c.Request.IsSmartphone())
            };
            // 模式， 额外附加 .pc.
            var modeDesktop = new DefaultDisplayMode("pc")
            {
                ContextCondition = (c => c.Request.IsDesktop())
            };


            displayModes.Clear();

            // 检查顺序，先判断是不是桌面， 最后判断是不是手机            
            displayModes.Add(modeDesktop);
            displayModes.Add(modeSmartphone);
        }
    }


    /// <summary>
    /// 为 HttpRequestBase 类扩展方法，来判断设备类型.
    /// </summary>
    public static class HttpRequestBaseExtensions
    {
        public static Boolean IsDesktop(this HttpRequestBase request)
        {
            return !request.Browser.IsMobileDevice;
        }

        public static Boolean IsSmartphone(this HttpRequestBase request)
        {
            return true;            
        }
    }
}