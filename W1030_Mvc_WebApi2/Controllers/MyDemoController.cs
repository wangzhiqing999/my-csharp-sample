using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;


using W1030_Mvc_WebApi2.Models;
using W1030_Mvc_WebApi2.ActionFilters;

namespace W1030_Mvc_WebApi2.Controllers
{


    [WebApiLogFilter]
    public class MyDemoController : ApiController
    {

        /// <summary>
        /// 用于测试返回的 用户列表.
        /// </summary>
        private static List<MyDemoUserInfo> testUserList = new List<MyDemoUserInfo>()
        {
            new MyDemoUserInfo() { UserName = "zhao", Password = "123" }, 
            new MyDemoUserInfo() { UserName = "qian", Password = "456" } ,
            new MyDemoUserInfo() { UserName = "sun", Password = "789" } ,
            new MyDemoUserInfo() { UserName = "li", Password = "abc" } ,
            new MyDemoUserInfo() { UserName = "zhou", Password = "password" } ,
            new MyDemoUserInfo() { UserName = "wu", Password = "wu" } ,
            new MyDemoUserInfo() { UserName = "zhen", Password = "zhen" } ,
            new MyDemoUserInfo() { UserName = "wang", Password = "wang" } ,
        };



        // GET api/<controller>
        public IEnumerable<MyDemoUserInfo> Get()
        {
            return testUserList;
        }

        // GET api/<controller>/5
        public IEnumerable<MyDemoUserInfo> Get(string id)
        {
            return testUserList.Where(p => p.UserName.Contains(id)).ToList();
        }

        // POST api/<controller>
        public void Post([FromBody]MyDemoUserInfo value)
        {
            testUserList.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]MyDemoUserInfo value)
        {
            MyDemoUserInfo data = testUserList.FirstOrDefault(p => p.UserName == id);
            if (data != null)
            {
                data.Password = value.Password;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            MyDemoUserInfo data = testUserList.FirstOrDefault(p => p.UserName == id);
            if (data != null)
            {
                testUserList.Remove(data);
            }
        }


        // 删除.
        // DELETE api/mydemo
        public void Delete()
        {
            // 测试 Filter 能否计算操作的耗时.
            Thread.Sleep(2048);

            testUserList.Clear();
        }


    }
}