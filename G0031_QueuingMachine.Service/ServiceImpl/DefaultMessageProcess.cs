using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using G0031_QueuingMachine.Message;
using G0031_QueuingMachine.Service;

namespace G0031_QueuingMachine.ServiceImpl
{
    /// <summary>
    /// 消息处理.
    /// </summary>
    public class DefaultMessageProcess
    {
        /// <summary>
        /// 单例用.
        /// </summary>
        private static DefaultMessageProcess me;




        public static DefaultMessageProcess GetInstance()
        {
            if (me == null)
            {
                me = new DefaultMessageProcess();
            }
            return me;
        }



        private IQueueManager queueManager = new DefaultQueueManager();


        private DefaultMessageProcess()
        {
        }


        
        /// <summary>
        /// 分配器加入列表.
        /// </summary>
        /// <param name="workNumberManager"></param>
        public void AddNewIWorkNumberManager(IWorkNumberManager workNumberManager)
        {
            queueManager.AddNewIWorkNumberManager(workNumberManager);
        }


        


        /// <summary>
        /// 消息处理.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public QueuingMachineMessage DoMessageProcess(QueuingMachineMessage message)
        {
            QueuingMachineMessage result = new QueuingMachineMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = message.Header.CommandID + 0x80000000,
                    SequenceNo = message.Header.SequenceNo,
                },
            };


            switch (message.Header.CommandID)
            {
                case MessageHeader.QM_NewWorkNumber_Req:
                    // 申请新号码.
                    result.Body = GetNewWorkNumberRespond(message.Body as NewWorkNumberRequest);
                    break;

                case MessageHeader.QM_AskWorkNumber_Req :
                    // 需要一个号码.
                    result.Body = GetAskWorkNumberRespond(message.Body as AskWorkNumberRequest);
                    break;
            }


            // 返回.
            return result;
        }






        /// <summary>
        /// 获取 申请新号码的 反馈消息.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private NewWorkNumberRespond GetNewWorkNumberRespond(NewWorkNumberRequest request)
        {
            NewWorkNumberRespond result = new NewWorkNumberRespond()
            {
                // 请求号码
                ResultWorkNumber = queueManager.GetNewWorkNumber(request.ServiceCode),
                // 队列首号码.
                TopWorkNumber = queueManager.GetTopWorkNumber(request.ServiceCode),
                // 队列长度.
                QueueLength = queueManager.GetWorkNumberCount(request.ServiceCode),
            };
            return result;
        }



        /// <summary>
        /// 获取  叫号请求的 反馈消息.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private AskWorkNumberRespond GetAskWorkNumberRespond(AskWorkNumberRequest request)
        {
            AskWorkNumberRespond result = new AskWorkNumberRespond();

            // 取得队列长度.
            int queueCount = queueManager.GetWorkNumberCount(request.ServiceCode);

            if (queueCount == 0)
            {
                // 不存在消息.
                result.ResultStatus = AskWorkNumberRespond.ResultIsWithoutAnyWorkNumber;
                result.ResultWorkNumber = String.Empty;
            }
            else
            {
                // 存在消息.
                result.ResultStatus = AskWorkNumberRespond.ResultIsHadWorkNumber;
                result.ResultWorkNumber = queueManager.GetAskWorkNumber(request.ServiceCode);
            }


            return result;
        }

    }
}
