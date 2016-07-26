using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;

namespace A0136_SocketAsyncEventArgsServer.Sample
{

    /// <summary>
    /// 该类定义可用的上下文对象集合 
    /// </summary>
    class SocketAsyncEventArgsPool
    {
        Stack<SocketAsyncEventArgs> m_pool;

        // Initializes the object pool to the specified size
        //
        // The "capacity" parameter is the maximum number of 
        // SocketAsyncEventArgs objects the pool can hold
        /// <summary>
        /// 初始化对象池
        /// </summary>
        /// <param name="capacity">最大连接数量</param>
        public SocketAsyncEventArgsPool(int capacity)
        {
            m_pool = new Stack<SocketAsyncEventArgs>(capacity);
        }



        // Add a SocketAsyncEventArg instance to the pool
        //
        //The "item" parameter is the SocketAsyncEventArgs instance 
        // to add to the pool
        public void Push(SocketAsyncEventArgs item)
        {
            if (item == null) { throw new ArgumentNullException("Items added to a SocketAsyncEventArgsPool cannot be null"); }
            lock (m_pool)
            {
                m_pool.Push(item);
            }
        }

        // Removes a SocketAsyncEventArgs instance from the pool
        // and returns the object removed from the pool
        public SocketAsyncEventArgs Pop()
        {
            lock (m_pool)
            {
                return m_pool.Pop();
            }
        }

        // The number of SocketAsyncEventArgs instances in the pool
        public int Count
        {
            get { return m_pool.Count; }
        }

    }
}
