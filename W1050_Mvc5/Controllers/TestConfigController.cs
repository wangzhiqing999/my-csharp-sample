using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

using System.Data.SqlClient;


namespace W1050_Mvc5.Controllers
{
    public class TestConfigController : Controller
    {


        // GET: TestConfig
        public ActionResult Index()
        {
            return View();
        }




        /// <summary>
        /// 测试更新 Web.Config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult TestUpdateConfig(string key, string value)
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

                // config.AppSettings.Settings.Remove(key);
                // config.AppSettings.Settings.Add(key, value);

                config.AppSettings.Settings[key].Value = value;

                config.Save();

                return Json(new { ResultCode = "0", ResultMessage = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { ResultCode = "SYSTEM_ERROR", ResultMessage = ex.Message });
            }
        }



        /// <summary>
        /// 测试连接.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="db"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult TestConnect(string server, string db, string uid, string pwd)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.InitialCatalog = db;
                builder.UserID = uid;
                builder.Password = pwd;

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    // 打开连接.
                    conn.Open();
                    // 创建一个 Command.
                    SqlCommand testCommand = conn.CreateCommand();
                    // 定义需要执行的SQL语句.
                    testCommand.CommandText = "SELECT GETDATE()";
                    var result = testCommand.ExecuteScalar();
                }

                // 执行到这里，没有出错， 认为是连接成功.
                return Json(new { ResultCode = "0", ResultMessage = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { ResultCode = "SYSTEM_ERROR", ResultMessage = ex.Message });
            }
        }


        /// <summary>
        /// 测试更新连接字符串.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="db"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult TestUpdateConnectString(string server, string db, string uid, string pwd)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.InitialCatalog = db;
                builder.UserID = uid;
                builder.Password = pwd;


                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                config.ConnectionStrings.ConnectionStrings["MyTestConfig"].ConnectionString = builder.ConnectionString;
                config.Save();

                return Json(new { ResultCode = "0", ResultMessage = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { ResultCode = "SYSTEM_ERROR", ResultMessage = ex.Message });
            }
        }


    }
}