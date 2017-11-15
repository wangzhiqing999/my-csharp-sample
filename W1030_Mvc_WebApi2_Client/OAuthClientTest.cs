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
    class OAuthClientTest
    {

        private HttpClient _httpClient;


        public OAuthClientTest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:42266/");
        }



        /// <summary>
        /// 直接访问授权的 web api.
        /// </summary>
        /// <returns></returns>
        public async Task Call_WebAPI_Without_Access_Token()
        {
            Console.WriteLine(await (await _httpClient.GetAsync("/api/values")).Content.ReadAsStringAsync());
        }


        /// <summary>
        /// 使用 Access Token 访问授权的 web api.
        /// </summary>
        /// <returns></returns>
        public async Task Call_WebAPI_By_Access_Token()
        {
            // 取得 Access Token.
            var token = await GetAccessToken();
            Console.WriteLine(token);

            // 用上一步取得的 Access Token. 去调用 Web API.
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine(await (await _httpClient.GetAsync("/api/values")).Content.ReadAsStringAsync());
        }



        /// <summary>
        /// 取得 Access Token.
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetAccessToken()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "1234");
            parameters.Add("client_secret", "5678");
            parameters.Add("grant_type", "client_credentials");

            var response = await _httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters));
            var responseValue = await response.Content.ReadAsStringAsync();

            return JObject.Parse(responseValue)["access_token"].Value<string>();
        }


    }
}
