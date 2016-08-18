using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.Autocomplete
{
    /// <summary>
    /// search 的摘要说明
    /// </summary>
    public class search : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 取得查询关键字.
            string queryKeyword = context.Request["q"];

            var query =
                from data in TestCityData.testCityList
                where data.CityKeyword.Contains(queryKeyword)
                group data by data.CityName;

            foreach (var group in query)
            {
                context.Response.Write(String.Format("{0}\n", group.Key));
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