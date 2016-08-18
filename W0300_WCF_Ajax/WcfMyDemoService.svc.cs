using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

using System.Threading;


namespace W0300_WCF_Ajax
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfMyDemoService
    {


        #region 模拟查询的例子.

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



        /// <summary>
        /// 用于模拟一个 模糊查询用户名的操作.
        /// 返回用户列表.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<MyDemoUserInfo> SearchUser(string name)
        {
            if (String.IsNullOrEmpty(name))
            {

                // 模拟一个长时间操作。
                // 以观察客户端 如何显示.
                Thread.Sleep(3000);


                // 未输入条件，全部返回.
                return testUserList;
            }
            else
            {
                var query =
                    from data in testUserList
                    where data.UserName.Contains(name.ToLower())
                    select data;

                List<MyDemoUserInfo> resultList = query.ToList();

                return resultList;
            }
        }









        /// <summary>
        /// 用于模拟一个 登录的处理.
        /// 返回用户.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public MyDemoUserInfo DoLogin(string name, string password)
        {

            var query =
                from data in testUserList
                where 
                    data.UserName == name.ToLower()
                    && data.Password == password.ToLower()
                select data;

            return query.FirstOrDefault();

        }



        #endregion








        #region 模拟 CheckBox  联动的例子.


        private static List<City> CityList = new List<City>()
        {
            new City() { ID = 1, CityName = "北京市"},
            new City() { ID = 2, CityName = "天津市"},
            new City() { ID = 73, CityName = "上海市"},
            new City() { ID = 234, CityName = "重庆市"},
        };


        private static List<District> DistrictList = new List<District>()
        {
            new District() { ID = 1, CID =1, DistrictName = "东城区"},
            new District() { ID = 2, CID =1, DistrictName = "西城区"},
            new District() { ID = 3, CID =1, DistrictName = "崇文区"},
            new District() { ID = 4, CID =1, DistrictName = "宣武区"},
            new District() { ID = 5, CID =1, DistrictName = "朝阳区"},
            new District() { ID = 6, CID =1, DistrictName = "丰台区"},

            new District() { ID = 19, CID =2, DistrictName = "和平区"},
            new District() { ID = 20, CID =2, DistrictName = "河东区"},
            new District() { ID = 21, CID =2, DistrictName = "河西区"},
            new District() { ID = 22, CID =2, DistrictName = "南开区"},
            new District() { ID = 23, CID =2, DistrictName = "河北区"},
            new District() { ID = 24, CID =2, DistrictName = "红桥区"},

            new District() { ID = 2103, CID =73, DistrictName = "长宁区"},
            new District() { ID = 2104, CID =73, DistrictName = "徐汇区"},
            new District() { ID = 2105, CID =73, DistrictName = "闵行区"},
            new District() { ID = 2106, CID =73, DistrictName = "虹口区"},
            new District() { ID = 2107, CID =73, DistrictName = "黄浦区"},
            new District() { ID = 2108, CID =73, DistrictName = "静安区"},

            new District() { ID = 2007, CID =234, DistrictName = "南岸区"},
            new District() { ID = 2008, CID =234, DistrictName = "北碚区"},
            new District() { ID = 2009, CID =234, DistrictName = "万盛区"},
            new District() { ID = 2010, CID =234, DistrictName = "双桥区"},
            new District() { ID = 2011, CID =234, DistrictName = "渝北区"},
            new District() { ID = 2012, CID =234, DistrictName = "巴南区"},
        };                        




        /// <summary>
        /// 获取所有的 市.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<SelectOption> GetAllCity()
        {
            // 预期结果列表.
            List<SelectOption> resultList = new List<SelectOption>();

            // 设置返回结果.
            foreach (City data in CityList)
            {
                resultList.Add( new SelectOption(data.ID.ToString(), data.CityName));
            }


            // 返回.
            return resultList;
        }



        /// <summary>
        /// 获取 市 下面的区县.
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<SelectOption> GetCityDistrict(int cityid)
        {
            // 预期结果列表.
            List<SelectOption> resultList = new List<SelectOption>();

           
            // 查询 数据.
            var query =
                from data in DistrictList
                where data.CID == cityid
                orderby data.ID
                select data;

            // 设置返回结果.
            foreach (District data in query)
            {
                resultList.Add(new SelectOption(data.ID.ToString(), data.DistrictName));
            }
                      

            // 返回.
            return resultList;
        }



        #endregion






        #region 模拟 CheckBox  联动  Plus  的例子.


        /// <summary>
        /// 获取所有的 市.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<SelectOption> GetAllCityPlus()
        {
            // 预期结果列表.
            List<SelectOption> resultList = new List<SelectOption>();

            // 设置返回结果.
            foreach (City city in CityList)
            {
                // 首先， 仅仅加入一个市.
                resultList.Add(new SelectOption(city.ID.ToString(), city.CityName));


                // 然后，以  市-区  的方式， 依次加入数据.
                var query =
                    from data in DistrictList
                    where data.CID == city.ID
                    orderby data.ID
                    select data;

                foreach (District dist in query)
                {
                    resultList.Add(new SelectOption(
                        String.Format("{0}-{1}", city.ID, dist.ID),
                        String.Format("{0}-{1}", city.CityName, dist.DistrictName)));
                }
            }


            // 返回.
            return resultList;
        }




        #endregion

    }






    /// <summary>
    /// 用于在  Ajax 过程中， 传递的中间对象.
    /// </summary>
    [DataContract]
    public class MyDemoUserInfo
    {

        /// <summary>
        /// 用户名.
        /// </summary>
        [DataMember]
        public string UserName { set; get; }


        /// <summary>
        /// 密码.
        /// </summary>
        [DataMember]
        public string Password { set; get; }



    }






    /// <summary>
    /// 城市.
    /// </summary>
    public class City
    {
        /// <summary>
        /// 城市编号.
        /// </summary>
        public int ID { set; get; }


        /// <summary>
        /// 城市名
        /// </summary>
        public string CityName { set; get; }

    }



    /// <summary>
    /// 区县.
    /// </summary>
    public class District
    {
        /// <summary>
        /// 区县编号.
        /// </summary>
        public int ID { set; get; }


        /// <summary>
        /// 城市编号.
        /// </summary>
        public int CID { set; get; }


        /// <summary>
        /// 区县名
        /// </summary>
        public string DistrictName { set; get; }
    }



    /// <summary>
    /// 商圈.
    /// </summary>
    public class ShoppingDistrict
    {
        /// <summary>
        /// 商圈编号.
        /// </summary>
        public int ID { set; get; }


        /// <summary>
        /// 区编号.
        /// </summary>
        public int DID { set; get; }


        /// <summary>
        /// 商圈名.
        /// </summary>
        public string ShoppingDistrictName { set; get; }

    }




}
