using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;



namespace W0300_WCF_Ajax.Autocomplete
{
    /// <summary>
    /// JsonSearch 的摘要说明
    /// </summary>
    public class JsonSearch : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 取得查询关键字.
            // 这里的  q  是 typeahead 的参数那里手工设定的， 可以根据需要修改.
            string queryKeyword = context.Request["q"];



            // Jquery UI 传递的参数名称是  term 
            // 这个  term  是默认值， 不需要手工指定.
            if (String.IsNullOrEmpty(queryKeyword))
            {
                queryKeyword = context.Request["term"];
            }


            var query =
                from data in TestCityData.testCityList
                where data.CityKeyword.Contains(queryKeyword)
                group data by data.CityName;



            List<string> result = query.Select(p=>p.Key).ToList();
            // 构造 序列化类.
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(result.GetType());
            using (MemoryStream st = new MemoryStream())
            {
                // 写入数据流 
                dcjs.WriteObject(st, result);
                // 读取流， 并输出.
                byte[] buff = st.ToArray();
                string jsonString = System.Text.Encoding.UTF8.GetString(buff);
                context.Response.Write(jsonString);
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