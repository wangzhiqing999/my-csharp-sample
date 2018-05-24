using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using System.Net.Http;
using System.Net.Http.Headers;




namespace W1030_Mvc_WebApi2_Client
{
    class I18nTest
    {

        /// <summary>
        /// 直接访问，不带 Accept-Language
        /// </summary>
        /// <returns></returns>
        public async Task TestDefault()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:42266/");

                Console.WriteLine(await (await httpClient.GetAsync("/api/TestI18n/DataNotFound")).Content.ReadAsStringAsync());
            }
        }


        /// <summary>
        /// 测试传入特定的 AcceptLanguage.
        /// </summary>
        /// <param name="acceptLang">AcceptLanguage</param>
        /// <returns></returns>
        public async Task TestLang(string acceptLang)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:42266/");

                StringWithQualityHeaderValue lang = new StringWithQualityHeaderValue(acceptLang);
                httpClient.DefaultRequestHeaders.AcceptLanguage.Add(lang);

                Console.WriteLine(await (await httpClient.GetAsync("/api/TestI18n/DataNotFound")).Content.ReadAsStringAsync());
            }
        }


    }

}
