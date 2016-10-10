using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity;

using System.Threading;



namespace W1050_Mvc5.Controllers
{
    public class TestGlimpseController : Controller
    {
        // GET: TestGlimpse
        public ActionResult Index()
        {
            return View();
        }








        #region 测试多个分布视图.


        /// <summary>
        /// 测试分布视图的主页面.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPartial()
        {
            // 主页面，耗时 500 毫秒.
            Thread.Sleep(500);

            return View();
        }


        /// <summary>
        /// 测试分布视图的主页面.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPartialAjax()
        {
            // 主页面，耗时 500 毫秒.
            Thread.Sleep(500);

            return View();
        }



        /// <summary>
        /// 测试分布视图1.
        /// </summary>
        /// <returns></returns>
        public ActionResult Partial1()
        {
            // 分布视图1， 耗时1秒.
            Thread.Sleep(1000);

            return PartialView();
        }

        /// <summary>
        /// 测试分布视图2.
        /// </summary>
        /// <returns></returns>
        public ActionResult Partial2()
        {
            // 分布视图2， 耗时2秒.
            Thread.Sleep(2000);

            return PartialView();
        }

        /// <summary>
        /// 测试分布视图3.
        /// </summary>
        /// <returns></returns>
        public ActionResult Partial3()
        {
            // 分布视图3， 耗时3秒.
            Thread.Sleep(3000);

            return PartialView();
        }


        #endregion














        #region 测试 EF 执行语句的检测.






        public ActionResult TestEf()
        {

            List<MyTestData> dataList;

            using (MyTestContext context = new MyTestContext())
            {

                MyTestData newData = new MyTestData()
                {
                    TestInfo = Guid.NewGuid().ToString()
                };

                context.MyTestDatas.Add(newData);
                context.SaveChanges();



                var query =
                    from data in context.MyTestDatas
                    select data;


                dataList = query.ToList();
            }


            return View(model: dataList);
        }



        #endregion





    }





    #region 用于测试 EF 的相关代码.

    /// <summary>
    ///  测试数据.
    /// </summary>
    [Table("my_test_data")]
    public class MyTestData
    {

        /// <summary>
        /// Key 表示主键.
        /// </summary>
        [Key]
        [Column("id")]
        [Display(Name = "ID")]
        public int ID { set; get; }


        /// <summary>
        /// 测试数据信息.
        /// </summary>
        [Column("test_info")]
        [StringLength(128)]
        [Display(Name = "数据")]
        public string TestInfo { set; get; }
    }



    public class MyTestContext : DbContext
    {
        public MyTestContext()
            : base("name=MyTestContext")
        {
        }


        /// <summary>
        /// 测试数据.
        /// </summary>
        public DbSet<MyTestData> MyTestDatas { get; set; }

    }

    #endregion 用于测试 EF 的相关代码.



}