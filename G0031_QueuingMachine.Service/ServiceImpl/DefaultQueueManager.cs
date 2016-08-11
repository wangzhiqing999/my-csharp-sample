using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using G0031_QueuingMachine.Service;

namespace G0031_QueuingMachine.ServiceImpl
{

    public class DefaultQueueManager : IQueueManager
    {

        /// <summary>
        /// 排队号码分配列表.
        /// </summary>
        private Dictionary<string, IWorkNumberManager> workNumberManagerDictionary = new Dictionary<string, IWorkNumberManager>();

        /// <summary>
        /// 分配器加入列表.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="workNumberManager"></param>
        public void AddNewIWorkNumberManager(IWorkNumberManager workNumberManager)
        {
            workNumberManagerDictionary.Add(workNumberManager.WorkNumberPrefix, workNumberManager);
        }



        /// <summary>
        /// 排队号码队列.
        /// </summary>
        private Dictionary<string, Queue<string>> workNumberQueueDictionary = new Dictionary<string, Queue<string>>();


        /// <summary>
        /// 新增一个号码.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string GetNewWorkNumber(string prefix)
        {
            if (!workNumberManagerDictionary.ContainsKey(prefix))
            {
                throw new ArgumentException("无法识别的号码前缀！");
            }
            // 取得号码生成器.
            IWorkNumberManager workNumberManager = workNumberManagerDictionary[prefix];

            // 生成新的号码.
            string newCode = workNumberManager.GetNextWorkNumber();


            // 如果队列不存在，那么创建之.
            if (!workNumberQueueDictionary.ContainsKey(prefix))
            {
                workNumberQueueDictionary.Add(prefix, new Queue<string>());
            }

            // 取得队列.
            Queue<string> workNumberQueue = workNumberQueueDictionary[prefix];

            // 新号码， 加入队列.
            workNumberQueue.Enqueue(newCode);

            // 将新号码返回.
            return newCode;
        }



        /// <summary>
        /// 获取队列第一个号码.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string GetTopWorkNumber(string prefix)
        {
            if (!workNumberManagerDictionary.ContainsKey(prefix))
            {
                throw new ArgumentException("无法识别的号码前缀！");
            }
            // 取得队列.
            Queue<string> workNumberQueue = workNumberQueueDictionary[prefix];

            // 有数据情况下， 返回队首元素.
            if (workNumberQueue.Count != 0)
            {
                return workNumberQueue.Peek();
            }
            // 无数据情况下，返回空白.
            return String.Empty;
        }



        /// <summary>
        /// 获取队列长度.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public int GetWorkNumberCount(string prefix)
        {
            if (!workNumberManagerDictionary.ContainsKey(prefix))
            {
                throw new ArgumentException("无法识别的号码前缀！");
            }

            if (!workNumberQueueDictionary.ContainsKey(prefix))
            {
                // 队列尚未初始化.
                return 0;
            }

            // 取得队列.
            Queue<string> workNumberQueue = workNumberQueueDictionary[prefix];

            // 返回队列长度.
            return workNumberQueue.Count;            
        }



        /// <summary>
        /// 获取指定前缀的 号码.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string GetAskWorkNumber(string prefix)
        {
            if (workNumberQueueDictionary.ContainsKey(prefix))
            {
                // 取得队列.
                Queue<string> workNumberQueue = workNumberQueueDictionary[prefix];

                if (workNumberQueue.Count > 0)
                {
                    // 队列中有元素.
                    return workNumberQueue.Dequeue();
                }
            }

            // 队列尚不存在.  或者 队列中没有元素.
            return String.Empty;
        }

    }

}
