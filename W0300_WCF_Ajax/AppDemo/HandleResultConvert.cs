using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;



namespace W0300_WCF_Ajax.AppDemo
{


    public class HandleResultConvert
    {

        /// <summary>
        /// 将数据对象，转换为 Json 格式.
        /// </summary>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public static string ToJsonString(Object dataObj)
        {
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(dataObj.GetType());
            using (MemoryStream st = new MemoryStream())
            {
                // 写入数据流 
                dcjs.WriteObject(st, dataObj);
                // 读取流， 构造字符串.
                byte[] buff = st.ToArray();
                string jsonString = System.Text.Encoding.UTF8.GetString(buff);
                // 返回.
                return jsonString;
            }
        }





        /// <summary>
        /// 写入 数据对象结果.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dataObj"></param>
        public static void WriteResponseString(HttpContext context, Object dataObj)
        {
            // 结果字符串.
            string resultJsonString = ToJsonString(dataObj);
            // 回调函数.
            string callback = context.Request["callback"];

            context.Response.ContentType = "text/plain";
            //context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            if (String.IsNullOrEmpty(callback))
            {
                // 无回调， 简单返回.
                context.Response.Write(resultJsonString);
            }
            else
            {
                // 有回调.
                context.Response.Write(String.Format("{0}({1})", callback, resultJsonString));
            }
        }



    }


}