using System;
using System.Text;

namespace W1030_Mvc_WebApi2.Models
{
    public class CommonServiceResult
    {

        public CommonServiceResult()
        {
        }

        public CommonServiceResult(Exception ex)
        {
            this.ResultCode = "SYSTEM_EXCEPTION";
            this.ResultMessage = ex.Message;
        }




        /// <summary>
        /// 结果码.
        /// </summary>
        public string ResultCode { set; get; }


        /// <summary>
        /// 结果消息.
        /// </summary>
        public string ResultMessage { set; get; }


        /// <summary>
        /// 结果数据.
        /// </summary>
        public dynamic ResultData { set; get; }



        /// <summary>
        /// 是否执行成功.
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return this.ResultCode == ResultCodeIsSuccess;
            }
        }


        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.AppendLine(this.ResultCode.ToString());
            buff.AppendLine(this.ResultMessage);
            return buff.ToString();
        }





        /// <summary>
        /// 处理成功.
        /// </summary>
        public const string ResultCodeIsSuccess = "0";

        /// <summary>
        /// 默认的，成功的执行结果.
        /// </summary>
        public static readonly CommonServiceResult DefaultSuccessResult = new CommonServiceResult()
        {
            ResultCode = ResultCodeIsSuccess,
            ResultMessage = "success",
        };





        /// <summary>
        /// 数据不存在.
        /// </summary>
        public const string ResultCodeIsDataNotFound = "COMMON_DATA_NOT_FOUND";

        /// <summary>
        /// 默认的，数据不存在的执行结果.
        /// </summary>
        public static readonly CommonServiceResult DataNotFoundResult = new CommonServiceResult()
        {
            ResultCode = ResultCodeIsDataNotFound,
            ResultMessage = "数据不存在！",
        };






        /// <summary>
        /// 创建默认的成功的结果.
        /// </summary>
        /// <param name="resultData"></param>
        /// <returns></returns>
        public static CommonServiceResult CreateDefaultSuccessResult(dynamic resultData)
        {
            CommonServiceResult result = new CommonServiceResult()
            {
                ResultCode = ResultCodeIsSuccess,
                ResultMessage = "success",
                ResultData = resultData
            };
            return result;
        }



    }
}
