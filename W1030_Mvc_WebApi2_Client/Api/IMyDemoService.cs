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
