using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using W1020_Mvc_WebApi.Models;


namespace W1020_Mvc_WebApi.Controllers
{
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



        // GET api/mydemo
        public IEnumerable<MyDemoUserInfo> Get()
        {
            return testUserList;
        }


        // GET api/mydemo/5
        public IEnumerable<MyDemoUserInfo> Get(string id)
        {
            return testUserList.Where(p => p.UserName.Contains(id)).ToList();
        }


        // POST api/mydemo
        public void Post([FromBody]MyDemoUserInfo mode)
        {
            testUserList.Add(mode);
        }



        // 编辑
        // PUT api/mydemo/5
        public void Put(string id, [FromBody]MyDemoUserInfo mode)
        {
            MyDemoUserInfo data = testUserList.FirstOrDefault(p => p.UserName == id);
            if (data != null)
            {
                data.Password = mode.Password;
            }
        }





        // 删除.
        // DELETE api/mydemo
        public void Delete()
        {
            testUserList.Clear();
        }



        // 删除.
        // DELETE api/mydemo/5
        public void Delete(string id)
        {
            MyDemoUserInfo data = testUserList.FirstOrDefault(p => p.UserName == id);
            if (data != null)
            {
                testUserList.Remove(data);
            }
        }
    }
}
