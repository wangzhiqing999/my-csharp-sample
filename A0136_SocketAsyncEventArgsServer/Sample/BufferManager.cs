using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;


namespace A0136_SocketAsyncEventArgsServer.Sample
{
    // This class creates a single large buffer which can be divided up 
    // and assigned to SocketAsyncEventArgs objects for use with each 
    // socket I/O operation.  
    // This enables bufffers to be easily reused and guards against 
    // fragmenting heap memory.
    // 
    // The operations exposed on the BufferManager class are not thread safe.
    class BufferManager
    {

        /// <summary>
        /// the total number of bytes controlled by the buffer pool
        /// 
        /// buffer大小
        /// </summary>
        int m_numBytes;


        /// <summary>
        /// the underlying byte array maintained by the Buffer Manager
        /// </summary>
        byte[] m_buffer;

        /// <summary>
        /// 管理池(栈操作)  
        /// </summary>
        Stack<int> m_freeIndexPool;


        int m_currentIndex;
        int m_bufferSize;



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="totalBytes"> buffer池大小(字节数)  </param>
        /// <param name="bufferSize"> 每个Buff单元的大小 </param>
        public BufferManager(int totalBytes, int bufferSize)
        {
            // buffer大小(字节数)
            m_numBytes = totalBytes;

            // 当前使用的索引.
            m_currentIndex = 0;

            // 每个Buff单元的大小
            m_bufferSize = bufferSize;

            // 用于 重用的 缓冲堆栈.
            m_freeIndexPool = new Stack<int>();
        }



        // Allocates buffer space used by the buffer pool
        /// <summary>
        /// 初始化缓冲.
        /// </summary>
        public void InitBuffer()
        {
            // create one big large buffer and divide that 
            // out to each SocketAsyncEventArg object
            m_buffer = new byte[m_numBytes];
        }




        // 为上下文对象分配内存；  
        // 若栈中有数据则表明有内存曾今被回收过，则新的上下文对象就用这块内存  
        // 否则就连续进行分配，直到内存满为止 

        // Assigns a buffer from the buffer pool to the 
        // specified SocketAsyncEventArgs object
        //
        // <returns>true if the buffer was successfully set, else false</returns>
        public bool SetBuffer(SocketAsyncEventArgs args)
        {

            // 当有  重用的 缓冲堆栈 的， 先去用  重用的部分.
            if (m_freeIndexPool.Count > 0)
            {

                // 设置要用于异步套接字方法的数据缓冲区。
                args.SetBuffer(m_buffer, m_freeIndexPool.Pop(), m_bufferSize);
            }
            else
            {
                // 没有可重用的，从 buffer池中分配一块新的区域.

                // 如果  (buffer池大小 - 每个Buff单元的大小) < 当前使用的索引.
                if ((m_numBytes - m_bufferSize) < m_currentIndex)
                {
                    // 内存不足.
                    return false;
                }

                // 设置要用于异步套接字方法的数据缓冲区。
                // 缓存池的起始位置为 当前使用的索引
                args.SetBuffer(m_buffer, m_currentIndex, m_bufferSize);

                // 当前使用的索引 递增.
                m_currentIndex += m_bufferSize;
            }
            return true;
        }


        //从上下文中释放的内存都将放入管理池(栈)中  
        // Removes the buffer from a SocketAsyncEventArg object.  
        // This frees the buffer back to the buffer pool
        public void FreeBuffer(SocketAsyncEventArgs args)
        {
            // 将当前的 起始地址， 存储到 重用的 缓冲堆栈中.
            m_freeIndexPool.Push(args.Offset);
            // 取消对 buffer池 中指定区域内存的使用.
            args.SetBuffer(null, 0, 0);
        }

    }

}
