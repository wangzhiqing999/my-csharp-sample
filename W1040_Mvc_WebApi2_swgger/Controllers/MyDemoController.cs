using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using W1040_Mvc_WebApi2_swgger.Models;


namespace W1040_Mvc_WebApi2_swgger.Controllers
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




        
        // GET api/<controller>
        /// <summary>
        /// 取得所有的测试数据.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MyDemoUserInfo> Get()
        {
            return testUserList;
        }


        // GET api/<controller>/5
        /// <summary>
        /// 取得指定用户的测试数据.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<MyDemoUserInfo> Get(string id)
        {
            return testUserList.Where(p => p.UserName.Contains(id)).ToList();
        }



        // POST api/<controller>
        /// <summary>
        /// 新增测试数据.
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]MyDemoUserInfo value)
        {
            testUserList.Add(value);
        }




        // PUT api/<controller>/5
        /// <summary>
        /// 更新测试数据.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(string id, [FromBody]MyDemoUserInfo value)
        {
            MyDemoUserInfo data = testUserList.FirstOrDefault(p => p.UserName == id);
            if (data != null)
            {
                data.Password = value.Password;
            }
        }




        // DELETE api/<controller>/5
        /// <summary>
        /// 删除测试数据.
        /// </summary>
        /// <param name="id"></param>
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
        /// <summary>
        /// 删除全部的测试数据.
        /// </summary>
        public void Delete()
        {
            testUserList.Clear();
        }


    }
}