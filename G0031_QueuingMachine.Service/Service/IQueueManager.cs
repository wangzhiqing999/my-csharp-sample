using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.Service
{
    /// <summary>
    /// 队列管理.
    /// </summary>
    public interface IQueueManager
    {

        /// <summary>
        /// 分配器加入列表.
        /// </summary>
        /// <param name="workNumberManager"></param>
        void AddNewIWorkNumberManager(IWorkNumberManager workNumberManager);



        /// <summary>
        /// 新增一个号码.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        string GetNewWorkNumber(string prefix);


        /// <summary>
        /// 获取指定前缀的 号码.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        string GetAskWorkNumber(string prefix);




        /// <summary>
        /// 获取队列第一个号码.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        string GetTopWorkNumber(string prefix);


        /// <summary>
        /// 获取队列长度.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        int GetWorkNumberCount(string prefix);

    }

}
