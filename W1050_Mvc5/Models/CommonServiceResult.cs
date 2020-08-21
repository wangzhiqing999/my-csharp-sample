using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace W1050_Mvc5.Models
{

    /// <summary>
    /// 通用的服务返回结果.
    /// </summary>
    public class CommonServiceResult<T>
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
        public T ResultData { set; get; }



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
        public static readonly CommonServiceResult<T> DefaultSuccessResult = new CommonServiceResult<T>()
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
        public static readonly CommonServiceResult<T> DataNotFoundResult = new CommonServiceResult<T>()
        {
            ResultCode = ResultCodeIsDataNotFound,
            ResultMessage = "数据不存在！",
        };




        /// <summary>
        /// 数据已存在.
        /// </summary>
        public const string ResultCodeIsDataHadExists = "COMMON_DATA_HAD_EXISTS";

        /// <summary>
        /// 默认的，数据已存在的执行结果.
        /// </summary>
        public static readonly CommonServiceResult<T> DataHadExistsResult = new CommonServiceResult<T>()
        {
            ResultCode = ResultCodeIsDataHadExists,
            ResultMessage = "数据已存在！",
        };






        /// <summary>
        /// 创建默认的成功的结果.
        /// </summary>
        /// <param name="resultData"></param>
        /// <returns></returns>
        public static CommonServiceResult<T> CreateDefaultSuccessResult(T resultData)
        {
            CommonServiceResult<T> result = new CommonServiceResult<T>()
            {
                ResultCode = ResultCodeIsSuccess,
                ResultMessage = "success",
                ResultData = resultData
            };
            return result;
        }

        /// <summary>
        /// 创建失败的结果.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static CommonServiceResult<T> CreateFailResult(string code, string message)
        {
            CommonServiceResult<T> result = new CommonServiceResult<T>()
            {
                ResultCode = code,
                ResultMessage = message,
            };
            return result;
        }

        /// <summary>
        /// 复制结果.
        /// </summary>
        /// <param name="commonServiceResult"></param>
        /// <returns></returns>
        public static CommonServiceResult<T> CopyFrom(CommonServiceResult commonServiceResult)
        {
            CommonServiceResult<T> result = new CommonServiceResult<T>()
            {
                ResultCode = commonServiceResult.ResultCode,
                ResultMessage = commonServiceResult.ResultMessage
            };
            return result;
        }


    }






    public class CommonServiceResult : CommonServiceResult<dynamic> {
        public CommonServiceResult()
        {
        }

        public CommonServiceResult(Exception ex)
        {
            this.ResultCode = "SYSTEM_EXCEPTION";
            this.ResultMessage = ex.Message;
        }



        /// <summary>
        /// 默认的，成功的执行结果.
        /// </summary>
        public new static readonly CommonServiceResult DefaultSuccessResult = new CommonServiceResult()
        {
            ResultCode = ResultCodeIsSuccess,
            ResultMessage = "success",
        };

        /// <summary>
        /// 默认的，数据不存在的执行结果.
        /// </summary>
        public new static readonly CommonServiceResult DataNotFoundResult = new CommonServiceResult()
        {
            ResultCode = ResultCodeIsDataNotFound,
            ResultMessage = "数据不存在！",
        };

        /// <summary>
        /// 默认的，数据已存在的执行结果.
        /// </summary>
        public new static readonly CommonServiceResult DataHadExistsResult = new CommonServiceResult()
        {
            ResultCode = ResultCodeIsDataHadExists,
            ResultMessage = "数据已存在！",
        };


        /// <summary>
        /// 创建默认的成功的结果.
        /// </summary>
        /// <param name="resultData"></param>
        /// <returns></returns>
        public new static CommonServiceResult CreateDefaultSuccessResult(dynamic resultData)
        {
            CommonServiceResult result = new CommonServiceResult()
            {
                ResultCode = ResultCodeIsSuccess,
                ResultMessage = "success",
                ResultData = resultData
            };
            return result;
        }


        /// <summary>
        /// 创建失败的结果.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static new CommonServiceResult CreateFailResult(string code, string message)
        {
            CommonServiceResult result = new CommonServiceResult()
            {
                ResultCode = code,
                ResultMessage = message,
            };
            return result;
        }

    }

}
