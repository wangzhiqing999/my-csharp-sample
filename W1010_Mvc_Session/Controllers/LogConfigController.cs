using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using log4net;
using log4net.Repository;
using log4net.Repository.Hierarchy;

using log4net.Appender;
using log4net.Filter;


namespace W1010_Mvc_Session.Controllers
{
    public class LogConfigController : Controller
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        //
        // GET: /LogConfig/
        public ActionResult Index()
        {

            if (!Request.IsLocal)
            {
                // 本页面仅仅允许本机访问.
                return HttpNotFound();
            }


            


            return View();
        }





        #region 设置 Root 级别的日志等级.


        [HttpGet]
        public ActionResult SetRootLevel()
        {
            // 获取当前 Root 日志级别.
            Hierarchy h = (Hierarchy)LogManager.GetRepository();
            Logger rootLogger = h.Root;
            string rootLoggerLevel = rootLogger.Level.ToString();
            ViewBag.RootLoggerLevel = rootLoggerLevel;

            return PartialView();
        }



        /// <summary>
        /// 设置 Root 级别的日志等级.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetRootLevel(string logLevel)
        {
            Hierarchy h = (Hierarchy)LogManager.GetRepository();
            Logger rootLogger = h.Root;
            rootLogger.Level = h.LevelMap[logLevel];
            return RedirectToAction("Index");
        }



        #endregion







        #region 设置 appender 的 LevelRangeFilter.


        [HttpGet]
        public ActionResult SetLevelRangeFilter()
        {
            Hierarchy h = (Hierarchy)LogManager.GetRepository();
            Logger rootLogger = h.Root;
            AppenderCollection ac = rootLogger.Appenders;

            Dictionary<string, LevelRangeFilter> resultData = new Dictionary<string, LevelRangeFilter>();            
            foreach (var a in ac)
            {                
                AppenderSkeleton appenderSkeleton = a as AppenderSkeleton;
                if (appenderSkeleton != null)
                {
                    if (appenderSkeleton.FilterHead != null && appenderSkeleton.FilterHead is LevelRangeFilter)
                    {
                        LevelRangeFilter levelRangeFilter = appenderSkeleton.FilterHead as LevelRangeFilter;
                        resultData.Add(a.Name, levelRangeFilter);
                    }
                }                                
            }

            return PartialView(model: resultData);
        }


        [HttpPost]
        public ActionResult SetLevelRangeFilter(string name, string min, string max)
        {
            Hierarchy h = (Hierarchy)LogManager.GetRepository();
            Logger rootLogger = h.Root;
            AppenderCollection ac = rootLogger.Appenders;

            foreach (var a in ac)
            {
                if (a.Name == name)
                {

                    AppenderSkeleton appenderSkeleton = a as AppenderSkeleton;
                    LevelRangeFilter levelRangeFilter = appenderSkeleton.FilterHead as LevelRangeFilter;

                    levelRangeFilter.LevelMin = h.LevelMap[min];
                    levelRangeFilter.LevelMax = h.LevelMap[max];
                }
            }

            return RedirectToAction("Index");
        }


        #endregion






        #region 测试输出 Log



        [HttpGet]
        public ActionResult TestLog() {
            return PartialView();
        }




        [HttpPost]
        public JsonResult TestLog(string message)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug(message);
            }

            if (logger.IsInfoEnabled)
            {
                logger.Info(message);
            }

            if (logger.IsWarnEnabled)
            {
                logger.Warn(message);
            }

            if (logger.IsErrorEnabled)
            {
                logger.Error(message);
            }

            return Json("OK");
        }

        #endregion


    }
}
