using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;


namespace W1050_Mvc5
{
    public class DisplayConfig
    {
        /// <summary>
        /// 注册设备模式.
        /// </summary>
        /// <param name="displayModes"></param>
        public static void RegisterDisplayModes(IList<IDisplayMode> displayModes)
        {
            // 默认的 桌面 模式， 没有额外的附加.
            var modeDesktop = new DefaultDisplayMode("")
            {
                ContextCondition = (c => c.Request.IsDesktop())
            };
            // 手机模式， 额外附加 .mobile.
            var modeSmartphone = new DefaultDisplayMode("mobile")
            {
                ContextCondition = (c => c.Request.IsSmartphone())
            };
            // 平板电脑模式， 额外附加 .tablet.
            var modeTablet = new DefaultDisplayMode("tablet")
            {
                ContextCondition = (c => c.Request.IsTablet())
            };

            displayModes.Clear();

            // 检查顺序，先判断是不是平板， 然后再判断是不是手机， 最后判断是不是桌面
            displayModes.Add(modeTablet);
            displayModes.Add(modeSmartphone);
            displayModes.Add(modeDesktop);
        }
    }


    /// <summary>
    /// 为 HttpRequestBase 类扩展方法，来判断设备类型.
    /// </summary>
    public static class HttpRequestBaseExtensions
    {
        public static Boolean IsDesktop(this HttpRequestBase request)
        {
            return true;
        }
        public static Boolean IsSmartphone(this HttpRequestBase request)
        {
            return request.Browser.IsMobileDevice;
        }
        public static Boolean IsTablet(this HttpRequestBase request)
        {
            return IsTabletInternal(request.UserAgent);
        }


        /// <summary>
        /// 设备是否是平板电脑.
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        private static Boolean IsTabletInternal(String userAgent)
        {
            var ua = userAgent.ToLower();
            return ua.Contains("ipad") || ua.Contains("gt-");
        }

    }

}