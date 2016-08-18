using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.AppDemo
{
    /// <summary>
    /// WeekReportHandler 的摘要说明
    /// </summary>
    public class WeekReportHandler : AbstractHandler<WeekReportHandleResult> 
    {


        protected override WeekReportHandleResult GetDefaultHandleResult()
        {
            return new WeekReportHandleResult()
            {
                Result = false,
                ResultList = new List<OneTimeReport> (),
            };
        }



        protected override void DoProcess(HttpContext context, WeekReportHandleResult result)
        {
            // 取得手机号码.
            string phone = context.Request["phone"];

            if (String.IsNullOrEmpty(phone))
            {
                result.ResultMessage = "数据异常，处理发生错误！";
                result.Result = false;
                return;
            }


            result.Result = true;

            if (phone == "13800000000")
            {
                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "001",
                    EquipmentName = "10楼南楼后勤",
                    RecordTime = "2015-01-25 08:50:01",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "001",
                    EquipmentName = "10楼南楼后勤",
                    RecordTime = "2015-01-25 18:15:05",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "001",
                    EquipmentName = "10楼南楼后勤",
                    RecordTime = "2015-01-26 08:50:33",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "001",
                    EquipmentName = "10楼南楼后勤",
                    RecordTime = "2015-01-26 18:12:10",
                });


                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "001",
                    EquipmentName = "10楼南楼后勤",
                    RecordTime = "2015-01-27 08:56:55",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "001",
                    EquipmentName = "10楼南楼后勤",
                    RecordTime = "2015-01-27 18:02:16",
                });
            }
            else
            {
                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "002",
                    EquipmentName = "9楼南楼后勤",
                    RecordTime = "2015-01-25 08:53:41",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "002",
                    EquipmentName = "9楼南楼后勤",
                    RecordTime = "2015-01-25 18:23:13",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "002",
                    EquipmentName = "9楼南楼后勤",
                    RecordTime = "2015-01-26 08:56:45",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "002",
                    EquipmentName = "9楼南楼后勤",
                    RecordTime = "2015-01-26 18:15:55",
                });


                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "002",
                    EquipmentName = "9楼南楼后勤",
                    RecordTime = "2015-01-27 08:58:45",
                });

                result.ResultList.Add(new OneTimeReport()
                {
                    EquipmentNo = "002",
                    EquipmentName = "9楼南楼后勤",
                    RecordTime = "2015-01-27 18:06:05",
                });
            }
        }
    }
}