using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Refit;


namespace W1030_Mvc_WebApi2_Client.Api
{

    /// <summary>
    /// 演示的服务接口.
    /// 具体的实现， 是通过调用 Web Api 实现.
    /// </summary>
    public interface IMyDemoService
    {

        [Get("/api/MyDemo")]
        Task<List<MyDemo>> GetMyDemosAsync();


        [Get("/api/MyDemo/{id}")]
        Task<List<MyDemo>> GetMyDemoAsync([AliasAs("id")]string userId);






		// 注意：如果 Web API 是有 JWT 验证的. 
		// 使用下面这种方式， 来实现，请求 Web Api 时，向 Http 头中，写入 JWT 信息。
		// [Get("/api/SystemUser/GetUserInfo")]
		// Task<SystemUser> GetUserInfo([Header("Authorization")] string authorization);
		
		
		
		
		
		
		// 注意：关于 Post 请求.
		// 有时候会遇到， 用 Postman 测试， 数据请求能够正常发出去。
		// 但是用代码，服务器那里返回 “你没有传递数据” 的应答
		// 尝试在参数前面，加上特定的标签，来完成处理。
		// [Body(BodySerializationMethod.UrlEncoded)]
		// Task<CommonResponse> SendCodeSmsAsync([Body(BodySerializationMethod.UrlEncoded)] SendCodeSmsRequest request);
		// 也就是  BodySerializationMethod.Json  请求出去， 服务器方不能识别， 所以只好  BodySerializationMethod.UrlEncoded
		
    }



    public class MyDemo
    {

        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }


        /// <summary>
        /// 密码.
        /// </summary>
        public string Password { set; get; }


    }



}
