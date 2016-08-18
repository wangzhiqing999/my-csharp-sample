using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W1005_MVC_Sub.Common
{
    public class AppPath
    {

        public static string GetAppPath(HttpRequestBase request, string ajaxPath)
        {
            string appPath = String.Format("{0}/{1}", request.ApplicationPath, ajaxPath);
            if (appPath.Contains("//"))
            {
                appPath = appPath.Replace("//", "/");
            }

            return appPath;
        }

    }
}